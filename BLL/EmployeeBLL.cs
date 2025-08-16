using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DBLayer;
using Model;

namespace BLL
{
    public class EmployeeBLL
    {
        private Employee _fakEmployee = new Employee
        {
            ID = 0,
            EmpFname = "fake",
            EmpLname = "Employee",
            EmpNationalCode = "1111111111",
            PersonalNum = "0",
            EmpPinCode = "0",
            HasFinger = false,
            Image = null,
            HasCard = false
        };

        private Employee FakEmployee
        {
            get { return _fakEmployee; }
            set { _fakEmployee = value; }
        }

        public void AddEmployee(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.AddEmployees(employee);
        }

        public List<Employee> SelectEmployeesAndGuest()
        {
            var Employees = new List<Employee>();
            var employeeDb = new EmployeeDb();
            Employees = employeeDb.SelectEmployeeAndGuest();
            return Employees;
        }

        public List<Employee> SelectEmployees()
        {
            List<Employee> employees = new EmployeeDb().SelectEmployee();
            return employees;
        }

        public List<EmployeeDto> SelectEmployeesList()
        {
            var employeeDb = new EmployeeDb();
            return employeeDb.SelectEmployeeList();
        }

        public List<EmployeeDto> SelectEmployees1()
        {
            var Employees = new List<EmployeeDto>();
            var employeeDb = new EmployeeDb();
            Employees = employeeDb.SelectEmployee1();
            return Employees;
        }

        public void DeleteEmployee(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.DeleteEmployee(employee);
        }

        public void DeleteOneEmployee(object id)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.DeleteOneEmployee(id);
        }

        public void DeleteEmployees(List<Employee> employees)
        {
            var employeeDb = new EmployeeDb();

            foreach (var employee in employees)
            {
                employeeDb.DeleteOneEmployee(employee.ID);
            }
        }

        public Employee SelectOneEmployees(object id)
        {
            var employeeDb = new EmployeeDb();
            var employee = new Employee();
            employee = employeeDb.SelectOneEmployee(id);
            return employee;
        }

        public Employee SelectOneEmployees(string personalNum)
        {
            var employeeDb = new EmployeeDb();
            var employee = new Employee();
            employee = employeeDb.SelectOneEmployee(personalNum);
            return employee;
        }


        public List<Employee> SelectEmployees(object[] result)
        {
            var employees = new List<Employee>();

            // ReSharper disable once LoopCanBeConvertedToQuery

            foreach (var index in result)
            {
                employees.Add(SelectOneEmployees(index));
            }
            return employees;
        }


        public int SelectLastEmployeeId()
        {
            var employeeDb = new EmployeeDb();
            var LastId = employeeDb.SelectLastEmployeeId();
            return LastId;
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.UpdateEmployee(employee);
        }

        public void UpdateEmployeeforZK(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.UpdateEmployeeforZK(employee);
        }

        public void SaveChanges()
        {
            var employeeDb = new EmployeeDb();
            employeeDb.saveChanges();
        }

        //        public void BuildDBfile()
        //        {
        //            List<Employee> employee = new List<Employee>();
        //            List<string> DbStr = new List<string>();
        //            string echoDb = "";
        //            EmployeeDb employeeDb = new EmployeeDb();
        //            const string filename = "db.txt";
        //
        //            employee = employeeDb.SelectEmployee();
        //
        //            for (int i = 0; i < employee.Count; i++)
        //            {
        //                string EmpInfo = ";";
        //                EmpInfo += "F_" + employee[i].EmpFname + ";";
        //                EmpInfo += "L_" + employee[i].EmpLname + ";";
        //                EmpInfo += "C_" + "07CDAF9E" + ";";
        //                EmpInfo += "I_" + employee[i].ID + ";";
        //                EmpInfo += "Q_" + employee[i].EmpPinCode + ";";
        //                EmpInfo += "S_" + "-10" + ";";
        //                EmpInfo += "T_" + "0" + ";";
        //                EmpInfo += "A_" + employee[i].AuthenticationMode + ";";
        //                EmpInfo += "P_" + employee[i].PersonalNum + ";";
        //                EmpInfo += "N_" + employee[i].EmpNationalCode + ";";
        //                EmpInfo += "M_" + "0" + ";\r\n";
        //                DbStr.Add(EmpInfo);
        //            }
        //
        //            for (int i = 0; i < DbStr.Count(); i++)
        //                echoDb += DbStr[i];
        //
        //            File.WriteAllText("C:\\Users\\Jahad\\Desktop\\db.txt", echoDb, Encoding.BigEndianUnicode);
        //
        //        }


        public void SetHasCard(int id)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.SetHasCard(id);
        }

        public void SetHasFinger(int employeeId)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.SetHasFinger(employeeId);
        }

        public void GetCard(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.GetCard(employee);
        }

        public void SetFalseFinger(Employee employee)
        {
            var employeeDb = new EmployeeDb();
            employeeDb.SetFalseFinger(employee);
        }


        public bool GetFingersOfEmployees(List<Employee> employees, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var fingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Fings\\" + device.IP);

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(fingsPath))
                    Directory.CreateDirectory(fingsPath);


                // ReSharper disable once AssignNullToNotNullAttribute
                foreach (var employee in employees)
                {
                    // ReSharper disable once CollectionNeverQueried.Local
                    var fingerBll = new FingerBLL();

                    for (var j = 0; j < fingerBll.SelectFingersEmployee(employee.ID).Count; j++)
                    {
                        var finger = fingerBll.SelectFingersEmployee(employee.ID)[j];
                        var fingerData = finger.Data;
                        byte[] header;

                        header = fingerBll.GenarateHeader(fingerData, employee.ID, finger);
                        fingerBll.GenerateFinger(fingsPath, header, fingerData, employee.ID, finger.FingerNum);

                        fingerBll.GenerateSyncFile(employee.ID, finger.FingerNum, device);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void GetPictureOfEmployee(List<Employee> employees, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var picPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics\\" + device.IP);

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(picPath))
                    Directory.CreateDirectory(picPath);


                foreach (var employee in employees)
                {
                    Application.DoEvents();
                    if (employee.Image != null)
                    {
                        var fileName = employee.ID + ".bmp";
                        var temp = ConvertToRgb565(employee.Image);

                        var pictureData = new byte[temp.Length + 64];

                        for (var i = 0; i < 64; i++)
                        {
                            pictureData[i] = 0;
                        }

                        for (var i = 64; i < temp.Length + 64; i++)
                        {
                            pictureData[i] = temp[i - 64];
                        }
                        File.WriteAllBytes(picPath + "\\" + fileName, pictureData);
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool GetPictureOfEmployeeForZK(Employee employee, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var picPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics\\" + device.IP);

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(picPath))
                    Directory.CreateDirectory(picPath);

                //Application.DoEvents();
                if (employee.Image != null)
                {
                    var fileName = employee.PersonalNum + ".jpg";
                    var pictureData = ConvertToRgb565forZK(employee.Image);

                    File.WriteAllBytes(picPath + "\\" + fileName, pictureData);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void GetPictureOfEmployee(List<Employee> employees)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var picPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics");

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(picPath))
                    Directory.CreateDirectory(picPath);


                foreach (var employee in employees)
                {
                    if (employee.Image != null)
                    {
                        var fileName = employee.ID + ".bmp";
                        var temp = ConvertToRgb565(employee.Image);

                        var pictureData = new byte[temp.Length + 64];

                        for (var i = 0; i < 64; i++)
                        {
                            pictureData[i] = 0;
                        }

                        for (var i = 64; i < temp.Length + 64; i++)
                        {
                            pictureData[i] = temp[i - 64];
                        }
                        File.WriteAllBytes(picPath + "\\" + fileName, pictureData);
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BuildDeletePictureFile(List<Employee> employees, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var picPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics\\" + device.IP);

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(picPath))
                    Directory.CreateDirectory(picPath);


                foreach (var employee in employees)
                {
                    Application.DoEvents();
                    if (employee.Image != null)
                    {
                        var fileName = employee.ID + ".bmp.Del";
                        //  byte[] temp = ConvertToRgb565(employee.Image);

                        //                        byte[] pictureData = new byte[temp.Length + 64];
                        var pictureData = new byte[2];

                        for (var i = 0; i < pictureData.Length; i++)
                        {
                            pictureData[i] = 0;
                        }

                        //                        for (int i = 64; i < temp.Length + 64; i++)
                        //                        {
                        //                            pictureData[i] = temp[i - 64];
                        //                        }
                        File.WriteAllBytes(picPath + "\\" + fileName, pictureData);
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception exp)
            {
                throw;
            }
        }


        public void BuildDeletePictureFile(List<Employee> employees)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var picPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Pics");

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(picPath))
                    Directory.CreateDirectory(picPath);


                foreach (var employee in employees)
                {
                    if (employee.Image != null)
                    {
                        var fileName = employee.ID + ".bmp.Del";
                        var temp = ConvertToRgb565(employee.Image);

                        var pictureData = new byte[temp.Length + 64];

                        for (var i = 0; i < 64; i++)
                        {
                            pictureData[i] = 0;
                        }

                        for (var i = 64; i < temp.Length + 64; i++)
                        {
                            pictureData[i] = temp[i - 64];
                        }
                        File.WriteAllBytes(picPath + "\\" + fileName, pictureData);
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception exp)
            {
                throw;
            }
        }


        private byte[] ConvertToRgb565(byte[] picData)
        {
            var image = Image.FromStream(new MemoryStream(picData));
            var resizeb = new Bitmap(image, 176, 216);
            var b = new Bitmap(216, 176, PixelFormat.Format16bppRgb565);
            for (var i = 0; i < 176; i++)
            {
                for (var j = 0; j < 216; j++)
                {
                    var cl = resizeb.GetPixel(i, j);
                    b.SetPixel(j, i, cl);
                }
            }

            var ms = new MemoryStream();
            b.Save(ms, ImageFormat.Bmp);
            var sa = ms.ToArray();
            return sa;
        }


        private byte[] ConvertToRgb565forZK(byte[] picData)
        {
            var image = Image.FromStream(new MemoryStream(picData));
            var resizeb = new Bitmap(image, 300, 300);
            var b = new Bitmap(300, 300, PixelFormat.Format24bppRgb);
            for (var i = 0; i < 300; i++)
            {
                for (var j = 0; j < 300; j++)
                {
                    var cl = resizeb.GetPixel(i, j);
                    b.SetPixel(i, j, cl);
                }
            }

            var ms = new MemoryStream();
            b.Save(ms, ImageFormat.Jpeg);
            var sa = ms.ToArray();
            return sa;
        }
        public void BuildDBfile(List<Employee> employees, List<Device> devices)
        {
            try
            {
                var deviceEmpBll = new DeviceEmpBll();
                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                var dbStr = new List<string>();
                var echoDb = string.Empty;


                foreach (var device in devices)
                {
                    foreach (var employee in deviceEmpBll.BasicInfoEmployeeInDevice(device.ID))
                    {
                        employees.Add(employee);
                    }

                    foreach (var employee in employees)
                    {
                        dbStr.Add(BuilDBfile(employee));
                    }
                    for (var i = 0; i < dbStr.Count(); i++)
                        echoDb += dbStr[i];
                    File.WriteAllText(dbPath + "\\" + device.IP + ".txt", echoDb, Encoding.BigEndianUnicode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void BuildDBfile(List<Employee> employees, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");
                var deviceEmpBll = new DeviceEmpBll();

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                var dbStr = new List<string>();
                var echoDb = string.Empty;

                var emps = deviceEmpBll.BasicInfoEmployeeInDevice(device.ID);
                var employeesTemp = new List<Employee>();
                employeesTemp.AddRange(employees);
                for (var i = 0; i < emps.Count; i++)
                {
                    for (var j = 0; j < employees.Count; j++)
                    {
                        if (employees[j].ID == emps[i].ID)
                            break;
                        if (j == employees.Count - 1)
                            employeesTemp.Add(emps[i]);
                    }
                }


                foreach (var employee in employeesTemp)
                {
                    dbStr.Add(BuilDBfile(employee));
                }

                //Add last line of Db beacuse of niknejad Bug
                dbStr.Add(BuilDBfakeEmployee(_fakEmployee));

                for (var i = 0; i < dbStr.Count(); i++)
                    echoDb += dbStr[i];
                File.WriteAllText(dbPath + "\\" + device.IP + ".txt", echoDb, Encoding.BigEndianUnicode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void BuildDBfileCotroller(List<Employee> employees, Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");
                var deviceEmpBll = new DeviceEmpBll();

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                var dbStr = new List<string>();
                var echoDb = string.Empty;

                var emps = deviceEmpBll.BasicInfoEmployeeInDevice(device.ID);
                var employeesTemp = new List<Employee>();
                employeesTemp.AddRange(employees);


                for (var i = 0; i < emps.Count; i++)
                {
                    for (var j = 0; j < employees.Count; j++)
                    {
                        if (employees[j].ID == emps[i].ID)
                            break;
                        if (j == employees.Count - 1)
                            employeesTemp.Add(emps[i]);
                    }
                }


                foreach (var employee in employeesTemp)
                {
                    dbStr.Add(BuildDBfileController(employee, device));
                }

                //Add last line of Db beacuse of niknejad Bug
                // dbStr.Add(BuilDBfakeEmployee(_fakEmployee));

                for (var i = 0; i < dbStr.Count(); i++)
                    echoDb += dbStr[i];
                File.WriteAllText(dbPath + "\\" + device.IP + ".txt", echoDb, Encoding.ASCII);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BuildDBfile(ref List<EmployeesInOneDevice> employeesInOneDevice, Device device)
        {
            try
            {
                var dbStr = new List<string>();
                var echoDb = string.Empty;
                var employeesTemp = new List<Employee>();

                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                foreach (var employee in employeesInOneDevice)
                {
                    if (employee.Db == true)
                        employeesTemp.Add(employee.Employee);
                    if (employee.Db == false)
                    {
                        employee.Picture = false;
                        employee.Finger = false;
                    }
                    if (employee.Employee.Image == null)
                        employee.Picture = false;
                }

                foreach (var employee in employeesTemp)
                {
                    Application.DoEvents();
                    dbStr.Add(BuilDBfile(employee));
                }

                //Add last line of Db beacuse of niknejad Bug
                dbStr.Add(BuilDBfakeEmployee(_fakEmployee));


                for (var i = 0; i < dbStr.Count(); i++)
                    echoDb += dbStr[i];
                File.WriteAllText(dbPath + "\\" + device.IP + ".txt", echoDb, Encoding.BigEndianUnicode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void BuildDBfile(Device device)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");
                var deviceEmpBll = new DeviceEmpBll();

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                var dbStr = new List<string>();
                var echoDb = string.Empty;

                var emps = deviceEmpBll.BasicInfoEmployeeInDevice(device.ID);

                foreach (var employee in emps)
                {
                    dbStr.Add(BuilDBfile(employee));
                }
                for (var i = 0; i < dbStr.Count(); i++)
                    echoDb += dbStr[i];
                File.WriteAllText(dbPath + "\\" + device.IP + ".txt", echoDb, Encoding.BigEndianUnicode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void BuildDBfile(List<Employee> employees, ref EmployeeInDevice editDeviceEmp,
            List<EmployeeInDevice> onlineDevices)
        {
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Db");
                var deviceEmpBll = new DeviceEmpBll();

                // ReSharper disable once AssignNullToNotNullAttribute
                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                var dbStr = new List<string>();
                var echoDb = string.Empty;

                var emps = deviceEmpBll.BasicInfoEmployeeInDevice(editDeviceEmp.Device.ID);
                var employeesTemp = new List<Employee>();

                if (editDeviceEmp.Db == true)
                {
                    employeesTemp.AddRange(employees);
                }
                if (editDeviceEmp.Db == false)
                {
                    employeesTemp = new List<Employee>();
                    editDeviceEmp.Picture = false;
                    foreach (var onlineDevice in onlineDevices)
                    {
                        if (onlineDevice == editDeviceEmp)
                            onlineDevice.Picture = false;
                    }
                    editDeviceEmp.Finger = false;
                    foreach (var onlineDevice in onlineDevices)
                    {
                        if (onlineDevice == editDeviceEmp)
                            onlineDevice.Finger = false;
                    }
                }


                for (var i = 0; i < emps.Count; i++)
                {
                    for (var j = 0; j < employees.Count; j++)
                    {
                        if (employees[j].ID == emps[i].ID)
                            break;
                        if (j == employees.Count - 1)
                            employeesTemp.Add(emps[i]);
                    }
                }

                foreach (var employee in employeesTemp)
                {
                    dbStr.Add(BuilDBfile(employee));
                }

                //Add last line of Db beacuse of niknejad Bug
                dbStr.Add(BuilDBfakeEmployee(_fakEmployee));

                for (var i = 0; i < dbStr.Count(); i++)
                    echoDb += dbStr[i];
                File.WriteAllText(dbPath + "\\" + editDeviceEmp.Device.IP + ".txt", echoDb, Encoding.BigEndianUnicode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        private string BuilDBfile(Employee employee)
        {
            var cardDb = new CardDB();
            var cardData = cardDb.SelectCardData(employee.ID);
            var empInfo = ";";
            empInfo += "F_" + employee.EmpFname + ";";
            empInfo += "L_" + employee.EmpLname + ";";
            empInfo += "C_" + cardData + ";";
            empInfo += "I_" + employee.ID + ";";
            empInfo += "Q_" + employee.EmpPinCode + ";";
            empInfo += "S_" + "-10" + ";";
            empInfo += "T_" + "0" + ";";
            empInfo += "A_" + employee.AuthenticationMode + ";";
            empInfo += "P_" + employee.PersonalNum + ";";
            empInfo += "N_" + employee.EmpNationalCode + ";";
            empInfo += "M_" + employee.MenuAccess + ";\r\n";

            return empInfo;
        }


        private string BuildDBfileController(Employee employee, Device device)
        {
            var schId = GetschId(employee, device);


            var cardDb = new CardDB();
            var cardData = cardDb.SelectCardData(employee.ID);
            var empInfo = "";
            empInfo += "R" + cardData + ";";
            empInfo += "I" + employee.ID + ";";
            empInfo += "P" + employee.PersonalNum + ";";
            empInfo += "Q" + employee.EmpPinCode + ";";
            empInfo += schId + ";";
            empInfo += "0" + ";";
            empInfo += "0" + "\r\n";

            return empInfo;
        }

        private int GetschId(Employee employee, Device device)
        {
            try
            {
                if (employee.PrivateAccess == true)
                {
                    if (employee.AccessGroup == null) return -3;
                    if (employee.AccessGroup.AcsGroupAcsAreas == null) return -3;
                    var acsGroupAcsAreas = employee.AccessGroup.AcsGroupAcsAreas;
                    foreach (var acsGroupAcsArea in acsGroupAcsAreas)
                    {
                        if (acsGroupAcsArea.AccessArea == null) continue;
                        if (acsGroupAcsArea.AccessArea.DeviceSchGroups == null) continue;
                        var deviceSchgroups = acsGroupAcsArea.AccessArea.DeviceSchGroups;
                        foreach (var deviceSchgroup in deviceSchgroups)
                        {
                            if (deviceSchgroup.DeviceID != device.ID) continue;
                            if (deviceSchgroup.SchgroupID != null) return (int)deviceSchgroup.SchgroupID;
                            return -3;
                        }
                    }
                }
                else
                {
                    if (employee.Organization == null) return -3;
                    if (employee.Organization.AccessGroup == null) return -3;
                    if (employee.Organization.AccessGroup.AcsGroupAcsAreas == null) return -3;

                    var acsGroupAcsAreas = employee.Organization.AccessGroup.AcsGroupAcsAreas;

                    foreach (var acsGroupAcsArea in acsGroupAcsAreas)
                    {
                        if (acsGroupAcsArea.AccessArea == null) continue;
                        if (acsGroupAcsArea.AccessArea.DeviceSchGroups == null) continue;
                        var deviceSchgroups = acsGroupAcsArea.AccessArea.DeviceSchGroups;
                        foreach (var deviceSchgroup in deviceSchgroups)
                        {
                            if (deviceSchgroup.DeviceID != device.ID) continue;
                            if (deviceSchgroup.SchgroupID != null) return (int)deviceSchgroup.SchgroupID;
                            return -3;
                        }
                    }
                }
                return -3;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private string BuilDBfakeEmployee(Employee employee)
        {
            var empInfo = ";";
            empInfo += "F_" + employee.EmpFname + ";";
            empInfo += "L_" + employee.EmpLname + ";";
            empInfo += "C_;";
            empInfo += "I_" + employee.ID + ";";
            empInfo += "Q_" + employee.EmpPinCode + ";";
            empInfo += "S_" + "-10" + ";";
            empInfo += "T_" + "0" + ";";
            empInfo += "A_" + employee.AuthenticationMode + ";";
            empInfo += "P_" + employee.PersonalNum + ";";
            empInfo += "N_" + employee.EmpNationalCode + ";";
            empInfo += "M_" + employee.MenuAccess + ";\r\n";

            return empInfo;
        }

        public bool ImportEmployeeFromExcel(string filePath)
        {
            try
            {
                var employeeDb = new EmployeeDb();
                return employeeDb.ImportEmployeeToSql(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExistNationalCode(string nationalCode)
        {
            var employeeDb = new EmployeeDb();
            return employeeDb.ExistNationalCode(nationalCode);
        }

        public bool ExistPersonalNum(string personalNum)
        {
            var employeeDb = new EmployeeDb();
            return employeeDb.ExistPersonalNum(personalNum);
        }

        public bool InsertPicToDbBasedPersonalNum(byte[] dataPic, string id)
        {
            var employeeDb = new EmployeeDb();
            return employeeDb.UpdatePicBasedPersonalNum(dataPic, id);
        }

        public bool InsertPicToDbBasedNationalCode(byte[] dataPic, string id)
        {
            var employeeDb = new EmployeeDb();
            return employeeDb.UpdatePicBasedNationalCode(dataPic, id);
        }

        public List<String> SelectNationalCodeFromTainDevice(string deviceIp)
        {
            return new EmployeeDb().SelectNationalCodeFromTaInDevice(deviceIp);
        }

        public Employee SelectEmployeeWithPersonalNumber(string PersonalNumber)
        {
            return new EmployeeDb().SelectOneEmployee(PersonalNumber);
        }

        public Employee SelectEmployee(string empNationalCode)
        {
            return new EmployeeDb().SelectEmployee(empNationalCode);
        }
    }
}