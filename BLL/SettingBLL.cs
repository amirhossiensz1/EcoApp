using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using DBLayer;
using Model;

namespace BLL
{
    public class SettingBLL
    {
        public List<string> GetPreventConsecutive()
        {
            var preventConsecutive = new List<string>();
            foreach (var i in Enum.GetValues(typeof (PreventConsecutive)))
            {
                preventConsecutive.Add((((PreventConsecutive) i).ToString()));
            }
            return preventConsecutive;
        }

        public List<string> GetRelayDriven()
        {
            var relayDriven = new List<string>();
            foreach (int i in Enum.GetValues(typeof (RelayDriven)))
            {
                relayDriven.Add(((RelayDriven) i).ToString());
            }
            return relayDriven;
        }

        public List<string> GetRelay()
        {
            var relay = new List<string>();
            foreach (var i in Enum.GetValues(typeof (Relay)))
            {
                relay.Add((((Relay) i).ToString()));
            }
            return relay;
        }

        public List<string> GetAudio()
        {
            var audio = new List<string>();
            foreach (var i in Enum.GetValues(typeof (Audio)))
            {
                audio.Add((((Audio) i).ToString()));
            }
            return audio;
        }

        public List<string> GetDeviceInfo()
        {
            var deviceInfo = new List<string>();
            foreach (var i in Enum.GetValues(typeof (DeviceInfo)))
            {
                deviceInfo.Add((((DeviceInfo) i).ToString()));
            }
            return deviceInfo;
        }

        public List<string> GetVacationDuty()
        {
            var vacationDuty = new List<string>();
            foreach (var i in Enum.GetValues(typeof (VacationDuty)))
            {
                vacationDuty.Add((((VacationDuty) i).ToString()));
            }
            return vacationDuty;
        }

        public List<string> GetLockHomeScreen()
        {
            var lockHomeScreen = new List<string>();
            foreach (var i in Enum.GetValues(typeof (LockHomeScreen)))
            {
                lockHomeScreen.Add((((LockHomeScreen) i).ToString()));
            }
            return lockHomeScreen;
        }

        public List<string> GetServerEnable()
        {
            var serverenabled = new List<string>();
            foreach (var i in Enum.GetValues(typeof (ServerEnable)))
            {
                serverenabled.Add((((ServerEnable) i).ToString()));
            }
            return serverenabled;
        }

        public List<string> GetEchoDir()
        {
            var echoDirList = new List<string>();
            foreach (int i in Enum.GetValues(typeof (EchoDir)))
            {
                echoDirList.Add(((EchoDir) i).ToString());
            }
            return echoDirList;
        }

        public void BuildSetting(Setting setting, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var settingdirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Setting");
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineChars = "\t\t\t\t\t\n",
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.GetEncoding("windows-1252")
                };

                var writer = XmlWriter.Create(settingdirectory + ".xml", settings);

                writer.WriteStartDocument();

                writer.WriteStartElement("SETTING_ROOT");

                writer.WriteStartElement("General_Setting");

                writer.WriteStartElement("Network_Setting");
                writer.WriteElementString("DHCP", setting.DHCP == true ? "Enable" : "Disable");
                writer.WriteElementString("IP", setting.IP);
                writer.WriteElementString("Subnet", setting.Subnet);
                writer.WriteElementString("Gateway", setting.gateway);
                writer.WriteElementString("FTP_Port", setting.UDPPort);

                writer.WriteStartElement("HTTP_Server");
                writer.WriteElementString("HTTP_Port", "1235");
                writer.WriteElementString("Web_Server", "Enable");
                writer.WriteEndElement();

                writer.WriteStartElement("Server");
                writer.WriteElementString("Server_Enabled", setting.ServerEnabled == true ? "Enable" : "Disable");
                writer.WriteElementString("Server_IP", setting.ServerIP);
                writer.WriteElementString("Server_Port", setting.ServerPort);
                writer.WriteEndElement();

                writer.WriteStartElement("AutoDiscovery");
                writer.WriteElementString("AutoDiscovery_Enabled", "Enable");
                writer.WriteElementString("AutoDiscovery_Port", "2530");
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteStartElement("Authentication_Setting");
                writer.WriteElementString("Authentication_Mode_Num", setting.AuthenticationType);
                writer.WriteEndElement();

                writer.WriteStartElement("Device_Setting");
                writer.WriteElementString("Language", "Farsi");

                writer.WriteStartElement("Display_Setting");
                writer.WriteElementString("LockHomeScreen", setting.LockHomeScreen == true ? "Enable" : "Disable");
                writer.WriteElementString("Theme", "t1");
                writer.WriteElementString("Screen_Saver", "None");
                writer.WriteElementString("Normal_Brightness", setting.NormalBrightness.ToString());
                writer.WriteElementString("Sleep_Brightness", setting.SleepBrightness.ToString());
                writer.WriteElementString("Backlight_Time_Out", "6");
                writer.WriteElementString("Menu_Time_Out", setting.TimeOutMenu.ToString());
                writer.WriteElementString("Screen_Saver_Time_Out", "20");
                writer.WriteElementString("DeviceInfoMenu", setting.DeviceInfo == true ? "Enable" : "Disable");
                writer.WriteEndElement();

                writer.WriteStartElement("Audio_Setting");
                writer.WriteElementString("BUZZER", setting.Audio == true ? "Enable" : "Disable");

                writer.WriteEndElement();

                writer.WriteStartElement("Door_Setting");

                writer.WriteStartElement("Door_Sensor");
                writer.WriteElementString("Door_Sensor_Enabled", "Disable");
                writer.WriteElementString("Door_Sensor_Time", "100");
                writer.WriteElementString("Door_Sensor_Action", "R1");
                writer.WriteEndElement();

                writer.WriteStartElement("Relay_Setting");
                writer.WriteElementString("Relay1_Enabled", setting.Relay == true ? "Enable" : "Disable");
                writer.WriteElementString("Relay1_Driven_By", setting.RelayDriven.ToString());
                writer.WriteElementString("Relay1_Duration", setting.RelayDuration);
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteStartElement("Advance_Setting");

                writer.WriteStartElement("Enterance_Setting");

                writer.WriteElementString("SamePersonCheck", "Disable");
                writer.WriteElementString("SamePersonTime", "30");
                writer.WriteElementString("PDP_DIR", setting.EchoDir);
                writer.WriteElementString("TA_Time_From_Server", "Enable");
                writer.WriteElementString("RevDualCard", "Disable");
                writer.WriteEndElement();

                writer.WriteStartElement("Fingerprint_Sensor_Setting");
                writer.WriteElementString("FingerOutDoor", "Disable");
                writer.WriteElementString("FingerDoubleScan", "Enable");
                writer.WriteElementString("Finger_Sensivity", "7");
                writer.WriteEndElement();

                writer.WriteStartElement("Administrator_Setting");
                writer.WriteElementString("WebUser", "pdp910");
                writer.WriteElementString("WebPass", "passwd!");
                writer.WriteEndElement();

                writer.WriteStartElement("Log_USB");
                writer.WriteElementString("LOG_USB_SERIAL", " ");
                writer.WriteEndElement();

                writer.WriteStartElement("Tamper_Setting");
                writer.WriteElementString("Tamper_Enabled", "Disable");
                writer.WriteElementString("Tamper_Action", "Lock");
                writer.WriteElementString("Tamper_Status", "Disable");
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("Special_Card_Setting");
                writer.WriteElementString("Vacation_Card", "24000000");
                writer.WriteElementString("Duty_Card", "23000000");
                writer.WriteEndElement();

                writer.WriteStartElement("Software_Setting");

                writer.WriteElementString("JD_ACCESS", "Enable");
                writer.WriteElementString("DeviceInfoMenu", "Enable");
                writer.WriteElementString("USBSyncPeriod", "30");
                writer.WriteElementString("Duty_Vac_Menu", setting.VacationDuty == true ? "Enable" : "Disable");
                writer.WriteEndElement();

                writer.WriteStartElement("Firmware_Setting");
                writer.WriteElementString("DFUMode", "Disable");
                writer.WriteElementString("AutoDFU", "Update_Firm");
                writer.WriteElementString("Fast_Boot", "Disable");
                writer.WriteEndElement();

                writer.WriteStartElement("Hard_Info");
                writer.WriteElementString("TOUCH", "OK");
                writer.WriteElementString("FirstBoot", "Disable");
                writer.WriteElementString("PACKET_LOGGING", "Disable");
                writer.WriteElementString("MAC", "");
                writer.WriteElementString("PDP_NAME", setting.EchoName);
                writer.WriteElementString("PDP_SERIAL", ConvertIdToSerial(Convert.ToInt32(device.DeviceSerial)));
                writer.WriteElementString("PDP_Description", setting.Description);
                writer.WriteElementString("GID", "10");
                writer.WriteElementString("BIOS_VER", "0.01");
                writer.WriteElementString("FIRM_VER", "0.14");
                writer.WriteElementString("SD_VER", "0.16");
                writer.WriteElementString("USER_COUNT", "123");
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ConvertIdToSerial(int? id)
        {
            if (id == null)
            {
                return "";
            }
            var str = id.ToString();
            str = str.Substring(1);
            return "ECO940T" + str;
        }

        public Setting GetSetting(int id)
        {
            try
            {
                var setting = new Setting();
                var settingDb = new SettingDB();
                setting = settingDb.SelectOne(id);
                return setting;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Setting setting)
        {
            var settingDb = new SettingDB();
            settingDb.Insert(setting);
        }

        public void Update(Setting setting)
        {
            var settingDb = new SettingDB();

            settingDb.UpdateSetting(setting);
        }

        public void DeleteOneSetting(object deviceId)
        {
            var settingDb = new SettingDB();

            settingDb.DeleteOneSetting(deviceId);
        }

        private enum EchoDir
        {
            IN = 0,
            OUT,
            TA,
            DUAL_READER,
            SERVER
        };

        private enum ServerEnable
        {
            Enable,
            Disable
        };

        private enum LockHomeScreen
        {
            Enable,
            Disable
        };

        private enum VacationDuty
        {
            Enable,
            Disable
        };

        private enum DeviceInfo
        {
            Enable,
            Disable
        };

        private enum Audio
        {
            Enable,
            Disable
        };

        private enum Relay
        {
            Enable,
            Disable
        };

        private enum RelayDriven
        {
            Success = 0,
            Denied,
            Tamper
        }

        private enum PreventConsecutive
        {
            Enable,
            Disable
        };
    }
}