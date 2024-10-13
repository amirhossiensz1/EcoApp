using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DBLayer;
using Model;
using Newtonsoft.Json;

namespace BLL
{
    public class CardBLL
    {
        private static readonly object ThisLock = new object();


        public int EnrolCard(Device device, int id)
        {
            try
            {
                var message = new Message();

                var clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientsocket.ReceiveBufferSize = 1000;

                var deviceBll = new DeviceBLL();


                byte[] enrollCardReq =
                {
                    69, 78, 82, 79, 76, 76, 95, 67, 65, 82, 68, 95, 82, 69, 81, 32, 32, 13, 10,
                    13, 10
                };
//
//                if (!deviceBll.Ping(device.IP, device.Port))
//                    return 2;
                if (!deviceBll.Ping(device.IP, device.Port, device.ServerIP))
                    return 2;

                Thread.Sleep(1000);
                message.Data = Encoding.ASCII.GetString(enrollCardReq);
                message.DistinationIp = device.IP;
                message.DistinationPort = device.Port;
                message.SourceIp = device.ServerIP;
                message.SourcePort = 8000;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                enrollCardReq = Encoding.ASCII.GetBytes(json);
                clientsocket.Connect(message.SourceIp, message.SourcePort);
                clientsocket.Send(enrollCardReq);


                var inStream = new byte[1000];
                clientsocket.ReceiveTimeout = 10000;

                clientsocket.Receive(inStream);

                var cardResponse = Encoding.ASCII.GetString(inStream);


                clientsocket.Close();

                if (cardResponse.Contains("OFFLINE_LOG") || cardResponse.Contains("ONLINE_LOG"))
                {
                    return 4;
                }
                if (cardResponse.Contains("Canceled By User"))
                {
                    return 5;
                }

                if (cardResponse.Contains("NO_TAG"))
                {
                    return 1;
                }

                var cardCode = GetCardData(cardResponse);
                var cardDb = new CardDB();
                var card = new Card();
                if (CardReserved(cardCode))
                    return 3;
                card.CardData = cardCode;
                card.EmpID = id;
                cardDb.InsertCardData(card);
                return 0;
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                return 6;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 4;
            }
        }

        public int EnrolGuestCard(Device device, int id, int cardNumber)
        {
            try
            {
                var message = new Message();

                var clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientsocket.ReceiveBufferSize = 1000;

                var deviceBll = new DeviceBLL();


                byte[] enrollCardReq =
                {
                    69, 78, 82, 79, 76, 76, 95, 67, 65, 82, 68, 95, 82, 69, 81, 32, 32, 13, 10,
                    13, 10
                };

                if (!deviceBll.Ping(device.IP, device.Port))
                    return 2;


                message.Data = Encoding.ASCII.GetString(enrollCardReq);
                message.DistinationIp = device.IP;
                message.DistinationPort = device.Port;
                message.SourceIp = device.ServerIP;
                message.SourcePort = 8000;

                var json = JsonConvert.SerializeObject(message, Formatting.Indented);
                enrollCardReq = Encoding.ASCII.GetBytes(json);
                clientsocket.Connect(message.SourceIp, message.SourcePort);
                clientsocket.Send(enrollCardReq);


                var inStream = new byte[1000];

                clientsocket.Receive(inStream);

                var cardResponse = Encoding.ASCII.GetString(inStream);


                clientsocket.Close();

                if (cardResponse.Contains("OFFLINE_LOG") || cardResponse.Contains("ONLINE_LOG"))
                {
                    return 4;
                }
                if (cardResponse.Contains("Canceled By User"))
                {
                    return 5;
                }

                if (cardResponse.Contains("NO_TAG"))
                {
                    return 1;
                }

                var cardCode = GetCardData(cardResponse);
                var cardDb = new CardDB();
                var card = new Card();
                if (CardReserved(cardCode))
                    return 3;
                card.CardData = cardCode;
                card.EmpID = id;
                card.CardNumber = cardNumber;
                card.IsGuest = true;
                if (cardDb.ExistCard(card.EmpID))
                    cardDb.UpdateGuestCard(card);
                else
                {
                    cardDb.InsertCardData(card);
                }
                return 0;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return 6;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 4;
            }
        }

        private string GetCardData(string data)
        {
            var cardCodeIndex = data.IndexOf("Card-Code", StringComparison.Ordinal);
            var endIndex = data.IndexOf("\r\n\r\n", StringComparison.Ordinal);
            var cardCode = data.Substring(cardCodeIndex + 10, endIndex - (cardCodeIndex + 10));

            return cardCode;
        }


        public void DeleteOneCard(object id)
        {
            var cardDb = new CardDB();
            cardDb.DeleteOneCard(id);
        }

        public void DeleteCards(int id)
        {
            var cardDb = new CardDB();
            cardDb.DeleteCards(id);
        }

        public void DeleteCards(List<Employee> employees)
        {
            var cardDb = new CardDB();
            foreach (var employee in employees)
            {
                cardDb.DeleteCards(employee.ID);
            }
        }

        public bool CardReserved(string cardData)
        {
            var cardDb = new CardDB();
            if (cardDb.SelectOneCard(cardData))
                return true;
            return false;
        }

        public bool SelectOneCard(int id)
        {
            var cardDb = new CardDB();

            return cardDb.SelectOneCard(id);
        }


        public bool ExistCardNumber(int cardNumber)
        {
            var cardDb = new CardDB();
            return cardDb.ExistCardNumber(cardNumber);
        }

        public int EnrolCardWithUsb(string comPortName, int empId)
        {
            try
            {
                return StartMifareCardCoding(comPortName, empId);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private int StartMifareCardCoding(string comPortName, int empId)
        {
            try
            {
                var enCoderMiferCar = new EncoderMiferCard(comPortName, 19200);
                var cardData = "";

                lock (ThisLock)
                {
                    enCoderMiferCar.StartEncoding();

                    for (var i = 0; i < 101; i++)
                    {
                        cardData = enCoderMiferCar.CardData;
                        Thread.Sleep(100);
                        if (cardData != null)
                        {
                            enCoderMiferCar.SerialPort.Close();
                            break;
                        }
                    }
                }
                if (cardData == null)
                {
                    if (enCoderMiferCar.CardNotExist && enCoderMiferCar.IsException)
                        return 1;
                    return 6;
                }

                if (!enCoderMiferCar.IsException)
                {
                    enCoderMiferCar.SerialPort.Close();
                    var card = new Card();
                    var cardDb = new CardDB();

                    if (CardReserved(cardData))
                        return 3;
                    card.CardData = cardData;
                    card.EmpID = empId;
                    cardDb.InsertCardData(card);
                    return 0;
                }
                return 6;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("does not exist"))
                {
                    return 2;
                }
                throw;
            }
        }

        public void InsertCardData(Card card)
        {
            try
            {
                new CardDB().InsertCardData(card);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ExistCard(int? empID)
        {
            return new CardDB().ExistCard(empID);
        }

        public void UpdateGuestCard(Card card)
        {
            new CardDB().UpdateGuestCard(card);
        }
    }


    public class EncoderMiferCard
    {
        private const int MaxBuffer = 50;
        private readonly int _boudRate;
        private readonly byte[] _buzzerIsOk = {0x02, 0x01, 0x05, 0x04, 0x03};

        private readonly byte[] _cardExist = {0x02, 0x05, 0x07};
        private readonly byte[] _cardNotExist = {0x02, 0x01, 0x00, 0x00, 0x1, 0x03};
        private readonly byte[] _dataReceived = new byte[MaxBuffer];
        private readonly string _portNumber;

        private readonly byte[] _requestCommand = {0x02, 0x01, 0x07, 0x06, 0x3};
        //private readonly byte[] _antiCollideCommand = {0x02, 0x00, 0x02, 0x32, 0x93, 0xA3};

        private readonly byte[] _testBuzzerCommand = {0x02, 0x04, 0x05, 0x02, 0x02, 0x02, 0x03, 0x03};

        public bool IsException;
        public SerialPort SerialPort;


        public EncoderMiferCard(string encoderComPortName, int boudRate)
        {
            _portNumber = encoderComPortName;
            _boudRate = boudRate;
        }

        private bool CheckRequestIsOk { get; set; }
        private bool CheckBuzzerIsOk { get; set; }
        private bool CheckAntiCollideIsOk { get; set; }

        public bool CardNotExist { get; set; }

        public string CardData { get; set; }

        public void StartEncoding()
        {
            try
            {
                CheckBuzzerIsOk = false;
                CheckRequestIsOk = false;
                CheckAntiCollideIsOk = false;
                Thread.Sleep(500);
                if (SerialConnection())
                    SendCommand(_testBuzzerCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private bool SerialConnection()
        {
            try
            {
                SerialPort = new SerialPort(_portNumber.ToString(CultureInfo.InvariantCulture), _boudRate, Parity.None,
                    8, StopBits.One)
                {
                    WriteTimeout = 1000,
                    ReadTimeout = 1000
                };
                // ReSharper disable once RedundantDelegateCreation
                SerialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                SerialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                SerialPort.Close();
                throw new Exception(ex.Message, ex);
            }
        }


        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var i = 0;
                var sPort = (SerialPort) sender;
                Thread.Sleep(200);
                while (sPort.IsOpen && sPort.BytesToRead > 0)
                {
                    _dataReceived[i] = Convert.ToByte(SerialPort.ReadByte());
                    i++;
                    if (i >= MaxBuffer)
                    {
                        i = 0;
                    }
                }

                var data = new byte[i];
                if (i > 1 && _dataReceived[0] != Encoding.ASCII.GetBytes("^")[0])
                {
                    for (var j = 0; j < i; j++)
                        data[j] = _dataReceived[j];

                    if (!CheckBuzzerIsOk)
                        CheckBuzzerIsOk = CheckBuzzer(data);

                    else if (!CheckRequestIsOk)
                        CheckRequestIsOk = CheckRequest(data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private bool CheckBuzzer(byte[] data)
        {
            try
            {
                var dataHexCheckBuzzer = ByteArrayToString(data);
                var commandHexCheckBuzzer = ByteArrayToString(_buzzerIsOk);

                if (dataHexCheckBuzzer == commandHexCheckBuzzer)
                {
                    SendCommand(_requestCommand);
                    return true;
                }
                SendCommand(_testBuzzerCommand);
                Thread.Sleep(50);
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckRequest(byte[] data)
        {
            try
            {
                var dataHexCheckRequest = ByteArrayToString(data);
                var commandHexCheckRequest = ByteArrayToString(_cardExist);
                var commandHexCardNotExist = ByteArrayToString(_cardNotExist);

                if (dataHexCheckRequest == commandHexCardNotExist)
                {
                    IsException = true;
                    CardNotExist = true;
                    SendCommand(_testBuzzerCommand);
                    SendCommand(_testBuzzerCommand);
                    SendCommand(_testBuzzerCommand);
                    Thread.Sleep(50);
                    Thread.Sleep(50);
                    SerialPort.Close();
                    return false;
                }
                if (commandHexCheckRequest == dataHexCheckRequest.Substring(0, 6))
                {
                    IsException = false;
                    CardData = dataHexCheckRequest.Substring(6, 8);
                    SendCommand(_testBuzzerCommand);
                    SerialPort.Close();
                    return true;
                }
                IsException = true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void SendCommand(byte[] command)
        {
            try
            {
                SerialPort.Write(command, 0, command.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public static string ByteArrayToString(byte[] data)
        {
            var hexData = BitConverter.ToString(data);
            hexData = hexData.Replace("-", "");
            return hexData;
        }
    }
}