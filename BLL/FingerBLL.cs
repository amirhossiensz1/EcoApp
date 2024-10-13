using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DBLayer;
using Model;
using Newtonsoft.Json;
using zkemkeeper;
using Message = Model.Message;

namespace BLL
{
    public class FingerBLL
    {
        private readonly PersianCalendar _perCalendar = new PersianCalendar();
        private CZKEMClass _czkem = new CZKEMClass();
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        public int EnrollFinger(Device device, int id, int fingerNum)
        {
            try
            {
                var message = new Message();
                var deviceBll = new DeviceBLL();
                var clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientsocket.ReceiveBufferSize = 2000;

                var ping = new Ping();
                byte[] enrollFingerReq =
                {
                    69, 78, 82, 79, 76, 76, 95, 70, 73, 78, 71, 95, 82, 69, 81, 32, 32, 13, 10,
                    13, 10
                };

                var pingOptions = new PingOptions(16, true);
                var buffer = new byte[32];

                if (!deviceBll.Ping(device.IP, device.Port))
                    return 2;


                message.Data = Encoding.ASCII.GetString(enrollFingerReq);
                message.DistinationIp = device.IP;
                message.DistinationPort = device.Port;
                message.SourceIp = device.ServerIP;
                message.SourcePort = 8000;
                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                clientsocket.Connect(device.ServerIP, message.SourcePort);

                enrollFingerReq = Encoding.ASCII.GetBytes(json);

                clientsocket.Send(enrollFingerReq);

                var inStream = new byte[2000];

                clientsocket.ReceiveTimeout = 20000;

                clientsocket.Receive(inStream);


                var fingerResponse = Encoding.ASCII.GetString(inStream);


                clientsocket.Close();

                if (fingerResponse.Contains("Scan Canceled By User"))
                {
                    return 6;
                }

                if (fingerResponse.Contains("OFFLINE_LOG") || fingerResponse.Contains("ONLINE_LOG"))
                {
                    return 5;
                }
                if (fingerResponse.Contains("Error Code"))
                {
                    return 4;
                }
                if (fingerResponse.Contains("Not Match"))
                {
                    return 3;
                }

                if (fingerResponse.Contains("Scan Timeout"))
                {
                    return 1;
                }

                var fingerDb = new FingerDB();
                var data = new byte[860];
                for (var i = 0; i < inStream.Length + 59; i++)
                {
                    data[i] = inStream[i + 59];
                    if (i == 860 - 1)
                    {
                        break;
                    }
                }
                string md5;
                using (var md5Hash = MD5.Create())
                {
                    md5 = GetMd5Hash(md5Hash, data);
                }
                var finger = new Finger
                {
                    Data = data,
                    EmpID = id,
                    FingerNum = fingerNum,
                    Md5 = md5,
                    DataLength = data.Length,
                    EnrollTime = GetTodayMiladiDate() + GetNowTime(),
                    fingerQuality = 95
                };
                fingerDb.InsertFinger(finger);
                return 0;
            }
            catch (SocketException e)
            {
                return 7;
                throw e;
            }
            catch (Exception e)
            {
                return 5;
                throw e;
            }
        }

        private string getFingerData(string fingerResponse)
        {
            var bodyDataIndex = fingerResponse.IndexOf("\r\n\r\n", StringComparison.Ordinal);
            var bodyData = fingerResponse.Substring(bodyDataIndex + 8);

            return bodyData;
        }

        public void Deletefingers(int id)
        {
            var fingerDb = new FingerDB();
            fingerDb.Deletefingers(id);
        }

        public void Deletefingers(List<Employee> employees)
        {
            var fingerDb = new FingerDB();

            foreach (var employee in employees)
            {
                fingerDb.Deletefingers(employee.ID);
            }
        }

        public void DeleteOneFingerEmployee(int id, int fingerNum)
        {
            var fingerDb = new FingerDB();
            fingerDb.DeleteOneFingerEmployee(id, fingerNum);
        }

        public List<Finger> SelectFingersEmployee(int id)
        {
            try
            {
                var fingerDb = new FingerDB();
                return fingerDb.SelectFingersEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool SelectOneFinger(int id)
        {
            var fingerDb = new FingerDB();
            return fingerDb.SelectOneFinger(id);
        }

        public Finger SelectOneFinger(int id, int fingerNum)
        {
            var fingerDb = new FingerDB();
            return fingerDb.SelectOneFinger(id, fingerNum);
        }

        public bool GenerateSyncFile(int fingerId, int? fingerNum, Device device)
        {
            try
            {
                var fileName = "\\Sync.txt";

                // ReSharper disable once AssignNullToNotNullAttribute
                var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync\\" + device.IP);

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(fingsPath))
                    Directory.CreateDirectory(fingsPath);

                using (var file =
                    new StreamWriter(fingsPath + fileName, true))
                {
                    file.WriteLine(fingerId + fingerNum);
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool GenerateSyncFile(int fingerId, int? fingerNum)
        {
            try
            {
                var fileName = "\\Sync.txt";

                // ReSharper disable once AssignNullToNotNullAttribute
                var syncPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Sync");


                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(syncPath))
                    Directory.CreateDirectory(syncPath);

                using (var file =
                    new StreamWriter(syncPath + fileName, true))
                {
                    file.WriteLine(fingerId + fingerNum);
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool GenerateFinger(string fingsPath, byte[] header, byte[] fingerData, int employeeId, int? fingerNum)
        {
            try
            {
                var finger = new byte[924];
                var j = 0;
                var fileName = employeeId + fingerNum + ".txt";


                for (var i = 0; i < finger.Length; i++)
                {
                    if (i < 64)
                        finger[i] = header[i];
                    else
                    {
                        finger[i] = fingerData[j++];
                    }
                }

                File.WriteAllBytes(fingsPath + "\\" + fileName, finger);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public byte[] GenarateHeader(byte[] fingerData, int employeeId, Finger finger)
        {
            byte[] head;
            string md5;
            using (var md5Hash = MD5.Create())
            {
                md5 = GetMd5Hash(md5Hash, fingerData);
            }
            var header = "feff";
            header += md5; //md5
            header += ConvertToHex("eft"); //filetype
            header += ChangeLSbtoMSB(string.Format("{0:x}", fingerData.Length)); //length

            var timeString = GetTodayMiladiDate() + GetNowTime();
            //  String timeString = GetTodayShamsiDate() + GetNowTime();
            header += ConvertToHex(timeString); //stringTime
            header += ConvertToHex("00000010"); //pdpID
            header += ConvertToHex("0"); //security Level
            header += ChangeLSbtoMSB(string.Format("{0:X}", Convert.ToInt32(employeeId.ToString() + finger.FingerNum)));
            if (finger.EnrollTime == null)
                header += ConvertToHex("960101120001"); //time date enroll
            else
            {
                header += ConvertToHex(finger.EnrollTime); //time date enroll
            }
            if (finger.fingerQuality == null)
                header += string.Format("{0:X}", finger.fingerQuality);
            else
            {
                header += string.Format("{0:X}", finger.fingerQuality);
            }

            header += "0" + finger.FingerNum;

            head = ConvertHexStringToByteArray(header);

            return head;
        }

        private string GetTodayMiladiDate()
        {
            var time = DateTime.Now;
            var year = time.Year.ToString();
            var month = time.Month.ToString();
            var day = time.Day.ToString();
            year = (year.Length == 1) ? "0" + year : year;
            month = (month.Length == 1) ? "0" + month : month;
            day = (day.Length == 1) ? "0" + day : day;
            return year.Substring(2, 2) + month + day;
        }

        private string GetNowTime()
        {
            var time = DateTime.Now;
            var hour = time.Hour.ToString();
            var minute = time.Minute.ToString();
            var second = time.Second.ToString();
            hour = (hour.Length == 1) ? "0" + hour : hour;
            minute = (minute.Length == 1) ? "0" + minute : minute;
            second = (second.Length == 1) ? "0" + second : second;
            return hour + minute + second;
        }


        public string GetTodayShamsiDate()
        {
            var year = _perCalendar.GetYear(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            var month = _perCalendar.GetMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            var day = _perCalendar.GetDayOfMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            day = (day.Length == 1) ? "0" + day : day;
            month = (month.Length == 1) ? "0" + month : month;
            return year.Substring(2, 2) + month + day;
            // return ConvertDate((year + month + day));
        }


        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length%2 != 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                    "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            var HexAsBytes = new byte[hexString.Length/2];
            for (var index = 0; index < HexAsBytes.Length; index++)
            {
                var byteValue = hexString.Substring(index*2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }


        private string ConvertToHex(string str)
        {
            var ba = Encoding.Default.GetBytes(str);
            str = BitConverter.ToString(ba);
            str = str.Replace("-", "");

            return str;
        }

        private string ChangeLSbtoMSB(string str)
        {
            var ch = new char[8];
            var j = 0;

            for (var i = 0; i < ch.Length; i++)
            {
                if (i < ch.Length - str.Length)
                    ch[i] = '0';
                else
                {
                    ch[i] = str[j++];
                }
            }
            str = string.Empty;
            for (var i = 1; i <= ch.Length; i += 2)
            {
                str += ch[ch.Length - (i + 1)] + ch[ch.Length - (i)];
            }
            return str;
        }

        private string GetMd5Hash(MD5 md5Hash, byte[] fingerData)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(fingerData);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length/sizeof (char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        private byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length*sizeof (char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        public void InsertFingerToDb(Finger finger)
        {
            var fingerDb = new FingerDB();


            fingerDb.InsertFinger(finger);
        }

        public bool SelectFingerMd5(int employeeId, string md5)
        {
            var fingerDb = new FingerDB();
            return fingerDb.SelectFingerMd5(employeeId, md5);
        }

        public void Upadate(Finger finger)
        {
            var fingerDb = new FingerDB();
            fingerDb.Update(finger);
        }

        public int GetFingerTmpFromZK(Device device, string fingerEmpId, int fingerNum)
        {
            try
            {
                string data;
                int length;
                var result = false;
                DeviceBLL deviceBll = new DeviceBLL();
                var fingerDb = new FingerDB();
                var employeeBll = new EmployeeBLL();

                if (!deviceBll.Ping(device.IP, device.Port))
                    return 2;
                var connect = ConnectToDevice(device.IP, device.Port);

                if (connect)
                {
                    var res = _czkem.StartEnrollEx(fingerEmpId, fingerNum + (9 - (2 * fingerNum)),1);

                    res = _czkem.StartIdentify();
                    //Stopwatch stopwatch = new Stopwatch();
                    //stopwatch.Start();
                    //for (int i = 0; i <= 90000; i++)
                    //{
                    //    if (stopwatch.Elapsed > TimeSpan.FromSeconds(5))
                    //        break;
                    //    Console.WriteLine(i);
                    //    Thread.Sleep(1000);
                    //}
                    Thread.Sleep(10000);

                    result = _czkem.SSR_GetUserTmpStr(iMachineNumber, fingerEmpId, fingerNum + (9 - (2 * fingerNum)), out data, out length);
                  //  _czkem.Disconnect();
                }
                else
                {
                    return 7;
                }

                if (result)
                {
                    var finger = new Finger()
                    {
                        FingerNum = fingerNum,
                        DataLength = length,
                        DataStr = data,
                        EmpID = employeeBll.SelectOneEmployees(fingerEmpId).ID,
                        PdpID = device.ID.ToString()
                    };
                    fingerDb.InsertFinger(finger);
                    return 0;
                }
                else
                {
                    return 8;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }


        private bool ConnectToDevice(string Ip, int? port)
        {
            bIsConnected = _czkem.Connect_Net(Ip, (int)port);
            if (bIsConnected)
                return true;
            return false;
        }
    }
}