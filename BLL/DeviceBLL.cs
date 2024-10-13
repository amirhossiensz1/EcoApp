using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using DBLayer;
using Model;
using Newtonsoft.Json;
using zkemkeeper;

namespace BLL
{
    public class DeviceBLL
    {
        public static ConcurrentDictionary<string, bool> pingStatus = new ConcurrentDictionary<string, bool>();


        public Socket _clientSocket;

        private AsyncCallback _pfnCallBack;
        private IAsyncResult _result;
        private Socket clientSocket;

        private string CurrentIp = string.Empty;

        public EndPoint EndPoint;

        public bool flag;
        public bool RefreshFlag;


        private Socket ClientSocket { get; set; }


        public List<Device> SelectDevices()
        {
            return new DeviceDB().SelectDevice();
        }

        public List<Device> SelectDevices(object[] result)
        {
            var devices = new List<Device>();

            // ReSharper disable once LoopCanBeConvertedToQuery

            foreach (int index in result)
            {
                devices.Add(SelectOneDevices(index));
            }
            return devices;
        }


        public List<DeviceType> SelectDevicesType()
        {
            var deviceDb = new DeviceDB();
            return deviceDb.SelectDeviceType();
        }


        public bool Ping(string ipAddress, int? port)
        {
            var ping = new Ping();
            var pingOptions = new PingOptions(16, true);
            var buffer = new byte[32];
            var reply = ping.Send(ipAddress, 16, buffer, pingOptions);

            if (reply != null && reply.Status != IPStatus.Success)
                return false;

            return true;
        }


        public bool Ping(Socket skt, string ipAddress, int port, string serverIp)
        {
            try
            {
                var message = new Message();
                //  skt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                skt.ReceiveBufferSize = 1000;
                _clientSocket = skt;
                var ping = new Ping();

                byte[] pingHeaderBytes = {80, 73, 78, 71, 32, 32, 13, 10, 13, 10};
                var pingOptions = new PingOptions(16, true);
                var buffer = new byte[32];


                var reply = ping.Send(ipAddress, 10, buffer, pingOptions);
                if (reply.Status != IPStatus.Success)
                {
                    skt.Close();
                    return false;
                }

                message.Data = Encoding.ASCII.GetString(pingHeaderBytes);
                message.DistinationIp = ipAddress;
                message.DistinationPort = port;
                message.SourceIp = serverIp;
                message.SourcePort = 8000;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                pingHeaderBytes = Encoding.ASCII.GetBytes(json);


                if (!skt.Connected)
                {
                    skt.Connect(message.SourceIp, message.SourcePort);
                }

                skt.Send(pingHeaderBytes);


                var inStream = new byte[1000];

                skt.ReceiveTimeout = 5000;
                skt.Receive(inStream);

                var returndata = Encoding.ASCII.GetString(inStream);

                // skt.Close();

                if (returndata.Contains("PONG 0.1 0.1 1"))
                {
                    return true;
                }
            }
            catch (ArgumentNullException e2)
            {
                Console.WriteLine("ArgumentNullException: {0}", e2);
            }
            catch (SocketException e3)
            {
                Console.WriteLine("ArgumentNullException: {0}", e3);
                skt.Close();
                skt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (IOException)
            {
                skt.Close();
            }
            catch (PingException)
            {
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }


        public bool Ping(string ipAddress, int? port, string serverIp)
        {
            try
            {
                var message = new Message();
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.ReceiveBufferSize = 1000;

                var ping = new Ping();

                byte[] pingHeaderBytes = {80, 73, 78, 71, 32, 32, 13, 10, 13, 10};
                var pingOptions = new PingOptions(16, true);
                var buffer = new byte[32];


                var reply = ping.Send(ipAddress, 10, buffer, pingOptions);
                if (reply.Status != IPStatus.Success)
                    return false;
                //                if (!Ping(ipAddress, port, serverIp))
                //                    return false;

                message.Data = Encoding.ASCII.GetString(pingHeaderBytes);
                message.DistinationIp = ipAddress;
                message.DistinationPort = port;
                message.SourceIp = serverIp;
                message.SourcePort = 8000;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                pingHeaderBytes = Encoding.ASCII.GetBytes(json);


                clientSocket.Connect(message.SourceIp, message.SourcePort);

                clientSocket.Send(pingHeaderBytes);
                //                serverStream.Write(pingHeaderBytes, 0, pingHeaderBytes.Length);
                //                serverStream.Flush();

                var inStream = new byte[1000];

                clientSocket.ReceiveTimeout = 5000;
                clientSocket.Receive(inStream);
                //                serverStream.Read(inStream, 0, (int) _clientSocket.ReceiveBufferSize);

                var returndata = Encoding.ASCII.GetString(inStream);

                //
                //                serverStream.Close();
                clientSocket.Close();

                if (returndata.Contains("PONG 0.1 0.1 1"))
                {
                    return true;
                }
            }
            catch (ArgumentNullException e2)
            {
                Console.WriteLine("ArgumentNullException: {0}", e2);
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public void DeleEmployeeFingerFromZK(CZKEMClass czkem, string personalNum)
        {
            for (int i = 0; i < 10; i++)
            {
                czkem.SSR_DelUserTmp(1, personalNum, i);
            }
            
        }

        public void Close()
        {
            try
            {
                _clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public bool IpReserved(IPAddress ipAddress)
        {
            var Devices = SelectDevices();

            foreach (var device in Devices)
            {
                if (device.IP == ipAddress.ToString())
                {
                    return true;
                }
            }
            return false;
        }


        public void AddDevice(Device device)
        {
            var deviceDb = new DeviceDB();
            deviceDb.AddDevice(device);
        }

        public void DeleteOneDevice(object id)
        {
            var deviceDb = new DeviceDB();
            deviceDb.DeleteOneDevice(id);
        }

        public Device SelectOneDevices(int id)
        {
            var deviceDb = new DeviceDB();
            var device = new Device();
            device = deviceDb.SelectOneDevice(id);
            return device;
        }

        public Device SelectOneDevices(string ip)
        {
            var deviceDb = new DeviceDB();
            var device = new Device();
            device = deviceDb.SelectOneDevice(ip);
            return device;
        }


        public void UpdateDevice(Device device)
        {
            var deviceDb = new DeviceDB();

            deviceDb.UpdateDevice(device);
        }


//        ****************************
//          tftp send file
//        ***************************


        private byte[] GetByteOfFile(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private long GetPacketCount(Stream str)
        {
            try
            {
                if (str.Length == 0)
                    return 0;

                return (str.Length/512) + 1;
            }
            catch (Exception e)
            {
                throw new Exception(MethodBase.GetCurrentMethod() + ": " + e.Message, e);
            }
        }

        private byte[] GetWriteRequestPacket(string sourceFile, int size)
        {
            try
            {
                const string modeString = "octet";
                const string tsize = "tsize";

                var data = sourceFile + char.MinValue + modeString + char.MinValue
                           + tsize + char.MinValue + size +
                           char.MinValue;

                var diagram = new byte[data.Length + 2];
                diagram[0] = 0x00;
                diagram[1] = 0x02;

                Encoding.ASCII.GetBytes(data, 0, data.Length, diagram, 2);

                return diagram;
            }
            catch (Exception e)
            {
                throw new Exception(MethodBase.GetCurrentMethod() + ": " + e.Message, e);
            }
        }

        private byte[] GetNextPacket(int packetid, Stream ms)
        {
            try
            {
                var h = Convert.ToByte(packetid/256);
                var l = Convert.ToByte(packetid - (packetid/256*256));

                var x = new byte[516];
                x[0] = 0x00;
                x[1] = 0x03;
                x[2] = h;
                x[3] = l;

                ms.Position = (packetid - 1)*512;

                if (ms.Position + 512 >= ms.Length)
                {
                    var lastPacket = new byte[ms.Length - ms.Position + 4];
                    lastPacket[0] = 0x00;
                    lastPacket[1] = 0x03;
                    lastPacket[2] = h;
                    lastPacket[3] = l;
                    ms.Read(lastPacket, 4, lastPacket.Length - 4);
                    return lastPacket;
                }

                ms.Read(x, 4, 512);

                return x;
            }
            catch (Exception e)
            {
                throw new Exception(MethodBase.GetCurrentMethod() + ": " + e.Message, e);
            }
        }

        private byte[] GetReadRequestPacket(string sourceFile, int size)
        {
            try
            {
                const string modeString = "octet";
                const string tsize = "tsize";

                var data = sourceFile + char.MinValue + modeString + char.MinValue;
//                    + tsize + char.MinValue + size +
//                              char.MinValue;

                var diagram = new byte[data.Length + 2];
                diagram[0] = 0x00;
                diagram[1] = 0x01;

                Encoding.ASCII.GetBytes(data, 0, data.Length, diagram, 2);

                return diagram;
            }
            catch (Exception e)
            {
                throw new Exception(MethodBase.GetCurrentMethod() + ": " + e.Message, e);
            }
        }

        public int SendTftp(string dbDir, string desDir, string ipaddress, int port)
        {
            //Error Activation 
            byte[] activationError = {0, 5, 0, 13, 48, 197};
            //Error user & pass 
            byte[] userAndPassError = {0, 5, 0, 11, 0, 0};
            //Error time 
            byte[] timeError = {0, 5, 0, 10, 0, 0};
            //Error App Serial 
            byte[] serialError = {0, 5, 0, 12, 0, 0};
            var result = new byte[516];
            try
            {
                try
                {
                    EndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipaddress), port);

                    EndPoint = ipEndPoint;
                    ClientSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
                    {
                        SendBufferSize = 516,
                        ReceiveBufferSize = 516
                    };

                    ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    ClientSocket.ReceiveTimeout = 2000;
                    ClientSocket.SendTimeout = 2000;
                }
                catch (Exception e)
                {
                    throw new Exception(MethodBase.GetCurrentMethod() + ": " + e.Message, e);
                }


                var dataToSend = GetByteOfFile(dbDir);
                dataToSend = dataToSend ?? Encoding.ASCII.GetBytes("   ");
                var memoryStr = new MemoryStream(dataToSend);
                var countPacket = GetPacketCount(memoryStr);
                var writePacket = GetWriteRequestPacket(desDir, dataToSend.Length);


                var packetid = 1;

                var tryToSend = 5;

                while (tryToSend > 0)
                {
                    try
                    {
                        try
                        {
                            ClientSocket.SendTo(writePacket, SocketFlags.None, EndPoint);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("can not send file " + dbDir + "to pdp " +
                                                ((IPEndPoint) EndPoint).Address + " trying number: " + tryToSend +
                                                "\r\n" +
                                                e.Message);
                        }
                        try
                        {
                            ClientSocket.ReceiveFrom(result, ref EndPoint);
                            var a = new char[result.Length];

                            if (result[3] == 13)
                                return 13;
                            if (result[3] == 12)
                                return 12;
                            if (result[3] == 11)
                                return 11;
                            if (result[3] == 10)
                                return 10;
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Pdp " + ((IPEndPoint) EndPoint).Address + "not Response to send file " +
                                                dbDir + " trying number: " + tryToSend + "\r\n" +
                                                e.Message);
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(10);
                        tryToSend = tryToSend - 1;
                        if (tryToSend == 0)
                            throw new Exception(e.Message, e);
                    }
                }
                var sendDataPort = EndPoint;
                var maxTry = 5;
                while (packetid <= countPacket)
                {
                    var packet = GetNextPacket(packetid, memoryStr);
                    try
                    {
                        try
                        {
                            ClientSocket.SendTo(packet, SocketFlags.None, sendDataPort);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("can not send file " + dbDir + "to pdp " +
                                                ((IPEndPoint) EndPoint).Address + " trying number: " + maxTry + "\r\n" +
                                                e.Message);
                        }
                        try
                        {
                            ClientSocket.ReceiveFrom(result, ref EndPoint);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Pdp " + ((IPEndPoint) EndPoint).Address + "not Response to send file " +
                                                dbDir + " trying number: " + maxTry + "\r\n" +
                                                e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(20);
                        maxTry--;
                        if (maxTry < 0)
                            throw new Exception(e.Message, e);
                        continue;
                    }

                    if (result[1] == 0x04 && result[2] == packet[2] && result[3] == packet[3])
                    {
                        packetid++;
                        maxTry = 5;
                    }
                    else if (maxTry > 0)
                    {
                        Thread.Sleep(50);
                        maxTry--;
                    }
                    else
                    {
                        throw new Exception("Pdp " + ((IPEndPoint) EndPoint).Address + " Error Ack :" +
                                            Encoding.ASCII.GetString(result));
                    }
                }

                ClientSocket.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + ex.Message, ex);
                return 1;
            }
            finally
            {
                ClientSocket.Close();
            }
        }


        public byte[] GetFile(string sourceFile, string ipaddress, int? port)
        {
            try
            {
                //Error Activation 
                byte[] activationError = {0, 5, 0, 13, 48, 197};
                //Error user & pass 
                byte[] userAndPassError = {0, 5, 0, 11, 0, 0};
                //Error time 
                byte[] timeError = {0, 5, 0, 10, 0, 0};
                //Error App Serial 
                byte[] serialError = {0, 5, 0, 12, 0, 0};

                if (port != null)
                {
                    EndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipaddress), (int) port);

                    EndPoint = ipEndPoint;
                    ClientSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
                    {
                        SendBufferSize = 516,
                        ReceiveBufferSize = 516
                    };
                }

                ClientSocket.Bind(new IPEndPoint(IPAddress.Any, 60000));
                ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                ClientSocket.ReceiveTimeout = 2000;
                ClientSocket.SendTimeout = 2000;

                var diagram = GetReadRequestPacket(sourceFile, 0);
                var finalData = new List<byte>();

                var result = new byte[516];

                var tryToSend = 5;
                var recvLen = 0;
                while (tryToSend > 0)
                {
                    try
                    {
                        ClientSocket.SendTo(diagram, 0, diagram.Length, SocketFlags.None, EndPoint);
                        recvLen = ClientSocket.ReceiveFrom(result, ref EndPoint);
                        break;
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(10);
                        tryToSend = tryToSend - 1;
                        if (tryToSend == 0)
                        {
                            var time = DateTime.Now;
                            var message = "dont response server for send this file: " + sourceFile +
                                          " in this ip: " + ((IPEndPoint) EndPoint).Address + " " + e.Message;
                            ClientSocket.Close();
                            return null;
                        }
                    }
                }

                if (recvLen != 516 && result[1] != 3)
                {
                    ClientSocket.Close();
                    if (result[3] == 13)
                        return activationError;
                    if (result[3] == 12)
                        return serialError;
                    if (result[3] == 11)
                        return userAndPassError;
                    if (result[3] == 10)
                        return timeError;
                    return result;
                }

                var ack = new byte[4];

                for (var i = 4; i < recvLen; i++)
                    finalData.Add(result[i]);

                if (recvLen < 516 && result[1] == 3)
                {
                    ack[0] = 0x00;
                    ack[1] = 0x04;
                    ack[2] = Convert.ToByte(result[2]);
                    ack[3] = Convert.ToByte(result[3]);

                    ClientSocket.SendTo(ack, SocketFlags.None, EndPoint);

                    ClientSocket.Close();
                    return finalData.ToArray();
                }

                while (true)
                {
                    ack[0] = 0x00;
                    ack[1] = 0x04;
                    ack[2] = Convert.ToByte(result[2]);
                    ack[3] = Convert.ToByte(result[3]);

                    ClientSocket.SendTo(ack, SocketFlags.None, EndPoint);


                    recvLen = ClientSocket.ReceiveFrom(result, ref EndPoint);

                    if (recvLen != 516 && result[1] != 3)
                    {
                        ClientSocket.Close();
                        return null;
                    }

                    for (var i = 4; i < recvLen; i++)
                        finalData.Add(result[i]);

                    if (recvLen < 516 && result[1] == 3)
                    {
                        ClientSocket.Close();
                        return finalData.ToArray();
                    }
                }
            }
            catch (Exception)
            {
                ClientSocket.Close();
                return null;
            }
        }


        //*********************
        //tftpclient
        //*********************


        //        ****************************
        //          Encryption......
        //        ***************************


        private string GetComputerSystemProductUuid()
        {
            var mos = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            var moc = mos.Get();
            string uuid = null;

            if (moc.Count > 0)
            {
                foreach (ManagementObject mo in moc)
                {
                    uuid = (string) mo["UUID"];
                }
            }
            return uuid;
        }

        private byte[] Base64UrlDecode(string arg)
        {
            var s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length%4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    s += "==";
                    break; // Two pad chars
                case 3:
                    s += "=";
                    break; // One pad char
                default:
                    throw new Exception(
                        "Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

        private byte[] GenarateKey(Device device)
        {
            if (device.ActivationCode == null)
                return null;
            var all = Base64UrlDecode(device.ActivationCode);
            var iv = new byte[16];
            Array.Copy(all, all.Length - 16, iv, 0, 16);

            //  string sys = GetComputerSystemProductUuid();
            var sys = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA";
            var b = Encoding.Default.GetBytes(sys);
            var d = new byte[1 + b.Length/2];

            for (var i = 0; i < d.Length; i++)
            {
                d[i] = (byte) (b[(2*i)%b.Length] ^ 0xDC);
            }
            byte[] dec = null;

            using (var aes = Rijndael.Create())
            {
                aes.Padding = PaddingMode.None;
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Mode = CipherMode.CBC;
                aes.IV = iv;

                using (var md5 = MD5.Create())
                {
                    aes.Key = md5.ComputeHash(d);
                    using (var decrypt = aes.CreateDecryptor())
                    {
                        dec = decrypt.TransformFinalBlock(all, 0, all.Length - 16);
                    }
                }
            }

            if (dec != null && dec.Length == 32 && ((dec[0] & 0xFF) == 0x96) && ((dec[17] & 0xFF) == 0xA5))
            {
                using (var md5 = MD5.Create())
                {
                    var sysCode = md5.ComputeHash(b);
                    for (var i = 0; i < 10; i++)
                    {
                        if (sysCode[i] != dec[22 + i])
                        {
                            return null;
                        }
                    }
                }

                //check device code ... 
                for (var i = 0; i < 4; i ++)
                {
                    if ((dec[18 + i] & 0xFF) !=
                        int.Parse(device.RegistrationCode.Substring(2*i, 2), NumberStyles.AllowHexSpecifier))
                    {
                        return new byte[0];
                    }
                }
                return dec;
            }
            return null;
        }

        private byte[] CreateEcoFileName(Device device, string sourceDir, string destinationDir)
        {
            var ecofileName = new byte[64]; // ReSharper disable once RedundantAssignment
            var webUserPass = new byte[16]; // ReSharper disable once RedundantAssignment
            var random = new byte[4]; // ReSharper disable once RedundantAssignment
            var fileCheckSum = new byte[4]; // ReSharper disable once RedundantAssignment
            var timeDiff = new byte[4]; // ReSharper disable once RedundantAssignment
            var fileSize = new byte[4]; // ReSharper disable once RedundantAssignment
            var remoteFilePath = new byte[30]; // ReSharper disable once RedundantAssignment
            var messagepad = new byte[2];

            webUserPass = GetEcoWebUser(device.ID);
            random = CreateRandomNumber();
            fileCheckSum = GetfileCheckSum(sourceDir);
            timeDiff = GetTimeDiff();
            fileSize = GetFileSize(sourceDir);
            remoteFilePath = GetremoteFilePath(destinationDir);
            messagepad = CreateMessagePad();

            Buffer.BlockCopy(webUserPass, 0, ecofileName, 0, webUserPass.Length);
            Buffer.BlockCopy(random, 0, ecofileName, webUserPass.Length, random.Length);
            Buffer.BlockCopy(fileCheckSum, 0, ecofileName, webUserPass.Length + random.Length, fileCheckSum.Length);
            Buffer.BlockCopy(timeDiff, 0, ecofileName, webUserPass.Length + random.Length + fileCheckSum.Length,
                timeDiff.Length);
            Buffer.BlockCopy(fileSize, 0, ecofileName,
                webUserPass.Length + random.Length + fileCheckSum.Length + timeDiff.Length, fileSize.Length);
            Buffer.BlockCopy(remoteFilePath, 0, ecofileName,
                webUserPass.Length + random.Length + fileCheckSum.Length + timeDiff.Length + fileSize.Length,
                remoteFilePath.Length);
            Buffer.BlockCopy(messagepad, 0, ecofileName,
                webUserPass.Length + random.Length + fileCheckSum.Length + timeDiff.Length + fileSize.Length +
                remoteFilePath.Length, messagepad.Length);

            return ecofileName;
        }

        private byte[] GetremoteFilePath(string destinationDir)
        {
            try
            {
                var result = new byte[30];
                var remoteFilePath = Encoding.ASCII.GetBytes(destinationDir);
                Buffer.BlockCopy(remoteFilePath, 0, result, 0, remoteFilePath.Length);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] EncryptedFileName(Device device, string sourceDir, string destinationDir)
        {
            byte[] dest;

            using (var aes = Rijndael.Create())
            {
                aes.BlockSize = 128;
                aes.KeySize = 128;

                aes.IV = Encoding.UTF8.GetBytes("JDEcoManagerInfo");

                aes.Key = KeyGenarator(device);

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;
                using (var encrypt = aes.CreateEncryptor())
                {
                    var ecoFileName = CreateEcoFileName(device, sourceDir, destinationDir);
                    dest = encrypt.TransformFinalBlock(ecoFileName, 0, ecoFileName.Length);
                }
            }

            return dest;
        }

        private byte[] KeyGenarator(Device device)
        {
            var key = new byte[16];

            var b = GenarateKey(device);

            if (b == null)
            {
                return null;
            }

            key[0] = b[6];
            key[1] = b[9];
            key[2] = b[15];
            key[3] = b[14];
            key[4] = b[8];
            key[5] = b[2];
            key[6] = b[7];
            key[7] = b[16];
            key[8] = b[1];
            key[9] = b[10];
            key[10] = b[5];
            key[11] = b[12];
            key[12] = b[13];
            key[13] = b[3];
            key[14] = b[11];
            key[15] = b[4];

            return key;
        }

        public string CreateRequestFileName(Device device, string sourceDir, string destinationDir)
        {
            try
            {
                var requestfilename = new byte[80];
                var aes = new AesCryptoServiceProvider();

                aes.IV = Encoding.UTF8.GetBytes("JDEcoManagerInfo");

                var encryptedfilename = EncryptedFileName(device, sourceDir, destinationDir);

                Buffer.BlockCopy(encryptedfilename, 0, requestfilename, 0, encryptedfilename.Length);


                Buffer.BlockCopy(aes.IV, 0, requestfilename, encryptedfilename.Length, aes.IV.Length);

                var stringEncrypted = "";

                for (var k = 0; k < requestfilename.Length; k++)
                    stringEncrypted += string.Format("{0:X2}", requestfilename[k]);


                return stringEncrypted;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return null;
            }
        }

        private byte[] CreateMessagePad()
        {
            var messagepad = new byte[2];
            messagepad[0] = 0;
            messagepad[1] = Encoding.ASCII.GetBytes("@")[0];
            return messagepad;
        }

        private byte[] GetEcoWebUser(int deviceId)
        {
            var result = new byte[16];
            var test = new byte[16];
            var device = new DeviceBLL();
            var webUserPass = device.SelectOneDevices(deviceId).webUser + device.SelectOneDevices(deviceId).webPass;

            for (var i = 0; i < webUserPass.Length; i++)
            {
                test[i] = Convert.ToByte(webUserPass[i]);
            }
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(webUserPass), 0, result, 0,
                Encoding.ASCII.GetBytes(webUserPass).Length);
            return result;
        }


        private byte[] GetTimeDiff()
        {
            var result = new byte[4];
            var year = DateTime.Now.Year;
            var firstDateTime = new DateTime(year, 1, 1, 0, 0, 0);
            // DateTime seconDateTime = DateTime.Now;
            //Get Time from Server
            var seconDateTime = GetTimeFromService();
            var timeDiff = seconDateTime - firstDateTime;
            var timediff = BitConverter.GetBytes((int) timeDiff.TotalSeconds);
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = timediff[(result.Length - i) - 1];
            }
            return result;
        }

        private DateTime GetTimeFromService()
        {
            try
            {
                var deviceDb = new DeviceDB();
                var timeServer = deviceDb.GetTimeFromServer();
                return timeServer;
            }
            catch (Exception exception)
            {
                return DateTime.MinValue;
                throw;
            }
        }


        private byte[] CreateRandomNumber()
        {
            var rnd = new Random();
            var random = BitConverter.GetBytes(rnd.Next(1000, 10000));
            return random;
        }


        private byte[] GetfileCheckSum(string sourceDir)
        {
            var fileBytes = GetByteOfFile(sourceDir);
            long sum = 0;
            var result = new byte[4];

            foreach (var filebyte in fileBytes)
            {
                sum += filebyte;
            }

            var checkSum = BitConverter.GetBytes(sum);

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = checkSum[(result.Length - i) - 1];
            }
            return result;
        }


        private byte[] GetFileSize(string sourceDir)
        {
            var result = new byte[4];
            var fileBytes = GetByteOfFile(sourceDir);

            var size = BitConverter.GetBytes(fileBytes.Length);

            for (var i = 0; i < size.Length; i++)
            {
                result[i] = size[(result.Length - i) - 1];
            }

            return result;
        }


        public bool ExistSerial(string serial)
        {
            var deviceDb = new DeviceDB();
            return deviceDb.ExistSerial(serial);
        }


        //*************//
        //**************//


        public void getMessage()
        {
            var clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket = clientsocket;
            _clientSocket.ReceiveBufferSize = 1000;
            var deviceBll = new DeviceBLL();

            var serverIp = deviceBll.SelectDevices()[0].ServerIP;


            var ipEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), 6035);
            // clientsocket.Connect(ipEndPoint);

            //   byte[] inStream = new byte[1000];

            _clientSocket.Connect(ipEndPoint);

            //  inStream = Encoding.ASCII.GetBytes("Im Online Pc");

            if (_clientSocket.Connected)
            {
                //  _clientSocket.Send(inStream);
                WaitForData();
            }
        }

        private void WaitForData()
        {
            try
            {
                if (_pfnCallBack == null)
                {
                    _pfnCallBack = OnDataReceived;
                }
                var theSocPkt = new CSocketPacketClient {ThisSocket = _clientSocket};
                _result = _clientSocket.BeginReceive(theSocPkt.DataBuffer,
                    0, theSocPkt.DataBuffer.Length,
                    SocketFlags.None,
                    _pfnCallBack,
                    theSocPkt);
            }
            catch (Exception)
            {
                _clientSocket.Close();
            }
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                var theSockId = (CSocketPacketClient) asyn.AsyncState;
                var iRx = theSockId.ThisSocket.EndReceive(asyn);
                var chars = new char[iRx + 1];
                var d = Encoding.UTF8.GetDecoder();
                var charLen = d.GetChars(theSockId.DataBuffer, 0, iRx, chars, 0);
                var szData = new string(chars);
                var dataRecive = szData;
                ProcessRecivesDataOfServer(dataRecive);
                WaitForData();
            }
            catch (ObjectDisposedException oe)
            {
                Console.WriteLine(oe);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ProcessRecivesDataOfServer(string dataRecive)
        {
            if (dataRecive.Contains("Refresh"))
                RefreshFlag = true;

            if (dataRecive.Contains("PONG 0.1 0.1 1"))
            {
                flag = true;
                pingStatus.TryUpdate(CurrentIp, true, false);
            }
        }


        public void NewPing(Socket clientsocket, Device device)
        {
            clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket = clientsocket;
            _clientSocket.ReceiveBufferSize = 1000;
            var deviceBll = new DeviceBLL();
            CurrentIp = device.IP;


            var ipEndPoint = new IPEndPoint(IPAddress.Parse(device.ServerIP), 8000);
            // clientsocket.Connect(ipEndPoint);

            var inStream = new byte[1000];

            _clientSocket.Connect(ipEndPoint);


            if (_clientSocket.Connected)
            {
                WaitForData();
            }
        }

        public string SendForceOpen1(Device device)
        {
            try
            {
                var message = new Message();
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var deviceBll = new DeviceBLL();
                //  var hexString = BitConverter.ToString(Encoding.Default.GetBytes("4010000000000000050A"));
                //   string resetCmd = hexString.Replace("-", "");

                byte[] fo1Cmd =
                {
                    64, 04, 00, 00, 00, 00, 00, 00, 05, 010
                };
                if (!deviceBll.Ping(device.IP, device.Port))
                    return "2";

                message.Data = Encoding.ASCII.GetString(fo1Cmd);
                message.DistinationIp = device.IP;
                message.DistinationPort = 6034;
                message.SourceIp = device.ServerIP;
                if (device.Port != null) message.SourcePort = (int)device.Port;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                var command = Encoding.ASCII.GetBytes(json);
                socket.Connect(message.SourceIp, message.SourcePort);
                socket.Send(command);
                var inStream = new byte[2000];

                socket.ReceiveTimeout = 5000;
                socket.Receive(inStream);
                var response = Encoding.ASCII.GetString(inStream);
                socket.Close();
                return response;
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10057)
                {
                    return "5";
                }
                return "3";
            }
            catch (Exception ex)
            {
                return "3";
            }
        }

        public string SendForceOpen2(Device device)
        {
            try
            {
                var message = new Message();
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var deviceBll = new DeviceBLL();
                //  var hexString = BitConverter.ToString(Encoding.Default.GetBytes("4010000000000000050A"));
                //   string resetCmd = hexString.Replace("-", "");

                byte[] fo2Cmd =
                {
                    64, 12, 00, 00, 00, 00, 00, 00, 05, 010
                };
                if (!deviceBll.Ping(device.IP, device.Port))
                    return "2";

                message.Data = Encoding.ASCII.GetString(fo2Cmd);
                message.DistinationIp = device.IP;
                message.DistinationPort = 6034;
                message.SourceIp = device.ServerIP;
                if (device.Port != null) message.SourcePort = (int)device.Port;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                var command = Encoding.ASCII.GetBytes(json);
                socket.Connect(message.SourceIp, message.SourcePort);
                socket.Send(command);
                var inStream = new byte[2000];

                socket.ReceiveTimeout = 5000;
                socket.Receive(inStream);
                var response = Encoding.ASCII.GetString(inStream);
                socket.Close();
                return response;
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10057)
                {
                    return "5";
                }
                return "3";
            }
            catch (Exception ex)
            {
                return "3";
            }
        }

        public string ResetDevice(Device device)
        {
            try
            {
                var message = new Message();
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var deviceBll = new DeviceBLL();
                //  var hexString = BitConverter.ToString(Encoding.Default.GetBytes("4010000000000000050A"));
                //   string resetCmd = hexString.Replace("-", "");

                byte[] resetCmd =
                {
                    64, 17, 00, 00, 00, 00, 00, 00, 05, 010
                };
                if (!deviceBll.Ping(device.IP, device.Port))
                    return "2";

                message.Data = Encoding.ASCII.GetString(resetCmd);
                message.DistinationIp = device.IP;
                message.DistinationPort = 6034;
                message.SourceIp = device.ServerIP;
                if (device.Port != null) message.SourcePort = (int) device.Port;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                var command = Encoding.ASCII.GetBytes(json);
                socket.Connect(message.SourceIp, message.SourcePort);
                socket.Send(command);
                var inStream = new byte[2000];

                socket.ReceiveTimeout = 5000;
                socket.Receive(inStream);
                var response = Encoding.ASCII.GetString(inStream);
                socket.Close();
                return response;
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10057)
                {
                    return "5";
                }
                return "3";
            }
            catch (Exception ex)
            {
                return "3";
            }
        }

        public int SendSync(Device device)
        {
            try
            {
                var message = new Message();
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var deviceBll = new DeviceBLL();

                byte[] syncClockTime =
                {
                    83, 89, 78, 67, 95, 67, 76, 79, 67, 75, 32, 48, 46, 48, 32, 48, 46, 48, 32, 48,
                    13, 10, 84, 105, 109, 101, 58
                };
                var time = Encoding.ASCII.GetBytes(GetTodayTime());
                byte[] dateWord = {13, 10, 68, 97, 116, 101, 58};
                var date = Encoding.ASCII.GetBytes(GetTodayDate());
                byte[] endOfSync = {13, 10, 13, 10};

                var syncCommand =
                    new byte[syncClockTime.Length + time.Length + dateWord.Length + date.Length + endOfSync.Length];
                Buffer.BlockCopy(syncClockTime, 0, syncCommand, 0, syncClockTime.Length);
                Buffer.BlockCopy(time, 0, syncCommand, syncClockTime.Length, time.Length);
                Buffer.BlockCopy(dateWord, 0, syncCommand, syncClockTime.Length + time.Length, dateWord.Length);
                Buffer.BlockCopy(date, 0, syncCommand, syncClockTime.Length + time.Length + dateWord.Length, date.Length);
                Buffer.BlockCopy(endOfSync, 0, syncCommand,
                    syncClockTime.Length + time.Length + dateWord.Length + date.Length, endOfSync.Length);

                // مقادیر تاریخ و ساعت اینجا به صورت ظاهری در کامند گذاشته میشود زمان واقعی از سرویس و در سمت سرور گرفته می شود

                if (!deviceBll.Ping(device.IP, device.Port))
                    return 2;

                message.Data = Encoding.ASCII.GetString(syncCommand);
                message.DistinationIp = device.IP;
                message.DistinationPort = device.Port;
                message.SourceIp = device.ServerIP;
                if (device.Port != null) message.SourcePort = (int) device.Port;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                var command = Encoding.ASCII.GetBytes(json);
                socket.Connect(message.SourceIp, message.SourcePort);
                socket.Send(command);
                var inStream = new byte[2000];

                socket.ReceiveTimeout = 5000;
                socket.Receive(inStream);
                var response = Encoding.ASCII.GetString(inStream);
                socket.Close();
                if (response.Contains("SYNC_Ok"))
                {
                    return 1;
                }

                return 4;
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10057)
                {
                    return 5;
                }
                return 3;
            }
            catch (Exception e)
            {
                return 3;
                Console.WriteLine(e);
            }
        }

        private static string GetTodayDate()
        {
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            var day = DateTime.Now.Day.ToString();
            day = (day.Length == 1) ? "0" + day : day;
            month = (month.Length == 1) ? "0" + month : month;
            return year + month + day;
        }

        private static string GetTodayTime()
        {
            var hours = DateTime.Now.Hour.ToString();
            var minute = DateTime.Now.Minute.ToString();
            var second = DateTime.Now.Second.ToString();
            hours = (hours.Length == 1) ? "0" + hours : hours;
            minute = (minute.Length == 1) ? "0" + minute : minute;
            second = (second.Length == 1) ? "0" + second : second;
            return hours + minute + second;
        }

 

        public bool DeleteEmployeeFaceFromZK( CZKEMClass czkem,string PersonalNum)
        {
            return czkem.DelUserFace(1, PersonalNum, 50);
        }
    }


    internal class CSocketPacketClient
    {
        public int ClientNumber;

        public Socket CurrentSocket;

        public byte[] DataBuffer = new byte[1024];

        public Socket ThisSocket;

        public CSocketPacketClient(Socket socket, int clientNumber)
        {
            CurrentSocket = socket;
            ClientNumber = clientNumber;
        }

        public CSocketPacketClient()
        {
            // TODO: Complete member initialization
        }
    }
}