using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;
//using DevExpress.Data.WcfLinq.Helpers;

namespace DBLayer
{
    public class DeviceEmpDB
    {
        public readonly EchoDBEntities EchoDbEntities = new EchoDBEntities();

        public List<DeviceEmp> SelectDeviceEmp(Employee employee)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();
                var deviceList = EchoDbEntities.DeviceEmps.Where(x => x.EmpID == employee.ID).ToList();
                EchoDbEntities.SaveChanges();
                return deviceList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertDeviceEmp(List<DeviceEmp> deviceEmps)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();
                foreach (var deviceEmp in deviceEmps)
                {
                    EchoDbEntities.DeviceEmps.Add(deviceEmp);
                    EchoDbEntities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void InsertDeviceToDeviceEmp(List<Employee> employees, Device device)
        {
            try
            {
                // EchoDbEntities.DeviceEmps.Load();
                //    IList<DeviceEmp> deviceEmps = new List<DeviceEmp>();
                var deviceEmp = new DeviceEmp();
                EchoDbEntities.Configuration.AutoDetectChangesEnabled = false;
                foreach (var employee in employees)
                {
                    deviceEmp.EmpID = employee.ID;
                    deviceEmp.DeviceID = device.ID;
                    deviceEmp.Finger = false;
                    deviceEmp.Picture = false;
                    deviceEmp.Db = false;
                    EchoDbEntities.DeviceEmps.Add(deviceEmp);
                    EchoDbEntities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void InsertOneDeviceEmp(DeviceEmp deviceEmp)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();
                EchoDbEntities.DeviceEmps.Add(deviceEmp);
                EchoDbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public bool ExistOneEmployee(int emplId, int deviceId)
        {
            try
            {
                var deviceEmp =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(x => x.EmpID == emplId && x.DeviceID == deviceId);
                if (deviceEmp == null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool UpdateAllEmpDevice(List<Employee> employees, List<Device> devices, bool finger,
            bool picture, bool db)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();
                IEnumerable<DeviceEmp> objects = EchoDbEntities.DeviceEmps.ToList();
//                IEnumerable<DeviceEmp> objects = EchoDbEntities.DeviceEmps.Select(x =>new DeviceEmpDto
//                {
//                    EmpID = x.EmpID , DeviceID = x.DeviceID , Description = x.Description,
//                    Db = x.Db , Finger = x.Finger , Picture = x.Picture
//                    
//                        
//                }).ToList();

                var deviceEmp = new DeviceEmp();
                var deviceEmpDb = new DeviceEmpDB();

                foreach (var device in devices)
                {
                    foreach (var employee in employees)
                    {
                        deviceEmp.DeviceID = device.ID;
                        deviceEmp.EmpID = employee.ID;

                        var selectedDeviceEmp =
                            objects.FirstOrDefault(x => x.EmpID == deviceEmp.EmpID && x.DeviceID == deviceEmp.DeviceID);


                        if (selectedDeviceEmp != null &&
                            ((selectedDeviceEmp.Finger.Value || finger) && employee.HasFinger == true))
                            deviceEmp.Finger = true;
                        else
                        {
                            deviceEmp.Finger = false;
                        }
                        if (selectedDeviceEmp != null &&
                            ((selectedDeviceEmp.Picture.Value || picture) && employee.Image != null))
                            deviceEmp.Picture = true;
                        else
                        {
                            deviceEmp.Picture = false;
                        }
                        if (selectedDeviceEmp != null && (selectedDeviceEmp.Db.Value || db))
                            deviceEmp.Db = true;
                        else
                        {
                            deviceEmp.Db = false;
                        }


                        if (selectedDeviceEmp != null)
                        {
                            selectedDeviceEmp.Finger = deviceEmp.Finger;
                            selectedDeviceEmp.Picture = deviceEmp.Picture;
                            selectedDeviceEmp.Db = deviceEmp.Db;
                        }

                        else
                        {
                            EchoDbEntities.DeviceEmps.Add(deviceEmp);
                        }
                    }
                }

                EchoDbEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public bool CuncurrentUpdateAllEmpDevice(List<Employee> employees, Device device, bool finger, bool picture,
            bool db)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                IEnumerable<DeviceEmp> objects = EchoDbEntities.DeviceEmps.ToList();

                var deviceEmp = new DeviceEmp();
                var deviceEmpDb = new DeviceEmpDB();
                foreach (var employee in employees)
                {
                    deviceEmp.DeviceID = device.ID;
                    deviceEmp.EmpID = employee.ID;

                    var selectedDeviceEmp =
                        objects.FirstOrDefault(x => x.EmpID == deviceEmp.EmpID && x.DeviceID == deviceEmp.DeviceID);


                    if ((selectedDeviceEmp.Finger.Value || finger) && employee.HasFinger == true)
                        deviceEmp.Finger = true;
                    else
                    {
                        deviceEmp.Finger = false;
                    }
                    if ((selectedDeviceEmp.Picture.Value || picture) && employee.Image != null)
                        deviceEmp.Picture = true;
                    else
                    {
                        deviceEmp.Picture = false;
                    }
                    if (selectedDeviceEmp.Db.Value || db)
                        deviceEmp.Db = true;
                    else
                    {
                        deviceEmp.Db = false;
                    }


                    if (selectedDeviceEmp != null)
                    {
                        selectedDeviceEmp.Finger = deviceEmp.Finger;
                        selectedDeviceEmp.Picture = deviceEmp.Picture;
                        selectedDeviceEmp.Db = deviceEmp.Db;
                    }

                    else
                    {
                        EchoDbEntities.DeviceEmps.Add(deviceEmp);
                    }
                }

                EchoDbEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public void UpdateOneEmployee(DeviceEmp deviceEmp)
        {
            try
            {
                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.EmpID == (int) deviceEmp.EmpID && x.DeviceID == (int) deviceEmp.DeviceID);

                if (deviceEmployee != null)
                {
                    deviceEmployee.Finger = deviceEmp.Finger;
                    deviceEmployee.Db = deviceEmp.Db;
                    deviceEmployee.Picture = deviceEmp.Picture;
                    //EchoDbEntities.Entry(deviceEmployee).State = EntityState.Modified;
                    EchoDbEntities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        //public List<DeviceEmp> SelectDeviceOneEmployee(int ID)
        //{
        //    try
        //    {
        //        DeviceDB deviceDb = new DeviceDB();
        //        EchoDBEntities echoDbEntities = new EchoDBEntities();
        //        var deviceEmp = echoDbEntities.DeviceEmps.Where(x => x.EmpID == ID).ToList();
        //        deviceEmp = echoDbEntities.DeviceEmps.Where(x => x.EmpID == ID).ToList().Join(echoDbEntities.Devices.Where(x => x.ID == );
        //        return deviceEmp;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public void DeleteDeviceFromDeviceEmp(object deviceId)
        {
            try
            {
                var devicelist = EchoDbEntities.DeviceEmps.Where(x => x.DeviceID == (int) deviceId);
                EchoDbEntities.DeviceEmps.RemoveRange(devicelist);
                EchoDbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void DeleteEmployeeFromDeviceEmp(object employeeId)
        {
            try
            {
                var employeelist = EchoDbEntities.DeviceEmps.Where(x => x.EmpID == (int) employeeId);
                EchoDbEntities.DeviceEmps.RemoveRange(employeelist);
                EchoDbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        public IQueryable<EmployeeInDevice> EmployeeInDevices(int empId)
        {
            try
            {
                var employeeInDevicesList = from deviceEmp in EchoDbEntities.DeviceEmps
                    join device in EchoDbEntities.Devices on deviceEmp.DeviceID equals device.ID
                    where deviceEmp.EmpID == empId
                    select
                        new EmployeeInDevice
                        {
                            Id = device.ID,
                            DeviceID = deviceEmp.DeviceID,
                            DeviceName = deviceEmp.Device.DeviceName,
                            DeviceIp = deviceEmp.Device.IP,
                            Finger = deviceEmp.Finger,
                            Db = deviceEmp.Db,
                            Picture = deviceEmp.Picture,
                            Device = device,
                            DeviceEmp = deviceEmp,
                            Employee = deviceEmp.Employee
                        };

                return employeeInDevicesList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<EmployeesInOneDevice> EmployeeInOneDevice(int deviceId)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var employeeInIOneDeviceList = from deviceEmp in echoDbEntities.DeviceEmps
                    join employee in echoDbEntities.Employees
                        on deviceEmp.EmpID equals employee.ID
                    where deviceEmp.DeviceID == deviceId
                    select new EmployeesInOneDevice
                    {
                        Id = deviceEmp.Employee.ID,
                        EmpFname = deviceEmp.Employee.EmpFname,
                        EmpLname = deviceEmp.Employee.EmpLname,
                        PersonalNum = deviceEmp.Employee.PersonalNum,
                        Finger = deviceEmp.Finger,
                        Db = deviceEmp.Db,
                        Picture = deviceEmp.Picture,
                        Employee = employee,
                        DeviceEmp = deviceEmp,
                        Device = deviceEmp.Device
                    };

                return employeeInIOneDeviceList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFingerfromDeviceEmp(int empId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployeelist = EchoDbEntities.DeviceEmps.Where(x => x.EmpID == empId).ToList();

                foreach (var deviceEmp in deviceEmployeelist)
                {
                    deviceEmp.Finger = false;
                }


                //echoDbEntities.Entry(deviceEmployeelist).State = EntityState.Modified;
                EchoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFingerfromDeviceEmp(int empId, Device device)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployeelist =
                    EchoDbEntities.DeviceEmps.Where(x => x.EmpID == empId && x.DeviceID == device.ID).ToList();

                foreach (var deviceEmp in deviceEmployeelist)
                {
                    deviceEmp.Finger = false;
                }


                //echoDbEntities.Entry(deviceEmployeelist).State = EntityState.Modified;
                EchoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DeviceEmp> SelectDbEmpInDevice(int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployeelist =
                    EchoDbEntities.DeviceEmps.Where(x => x.DeviceID == deviceId && x.Db == true).ToList();
                EchoDbEntities.SaveChanges();
                return deviceEmployeelist;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ExistFingerEmpInDevice(int employeeId, int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.DeviceID == deviceId & x.EmpID == employeeId & x.Finger == true);
                if (deviceEmployee == null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ExistPictureEmpInDevice(int employeeId, int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.DeviceID == deviceId & x.EmpID == employeeId & x.Picture == true);
                if (deviceEmployee == null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistDbEmpInDevice(int employeeId, int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.DeviceID == deviceId && x.EmpID == employeeId && x.Db == true);
                if (deviceEmployee == null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEmployeesFromDevice(object[] idList, int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                foreach (var id in idList)
                {
                    var employee =
                        EchoDbEntities.DeviceEmps.FirstOrDefault(x => x.EmpID == (int) id && x.DeviceID == deviceId);

                    if (employee != null)
                    {
                        employee.Finger = false;
                        employee.Db = false;
                        employee.Picture = false;
                        EchoDbEntities.Entry(employee).State = EntityState.Modified;
                    }
                }


                EchoDbEntities.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void DeleteEmployeesFromDevice(List<Employee> employees, int deviceId)
        {
            try
            {
                EchoDbEntities.DeviceEmps.Load();

                foreach (var emp in employees)
                {
                    var employee =
                        EchoDbEntities.DeviceEmps.FirstOrDefault(x => x.EmpID == emp.ID && x.DeviceID == deviceId);

                    if (employee != null)
                    {
                        EchoDbEntities.DeviceEmps.Remove(employee);
                    }
                }

                EchoDbEntities.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void UpdateAccess(List<EmployeesInOneDevice> employeeInDevice)
        {
            try
            {
                // EchoDbEntities.DeviceEmps.Load();

                foreach (var deviceEmployee in employeeInDevice)
                {
                    var employee =
                        EchoDbEntities.DeviceEmps.FirstOrDefault(
                            x => x.EmpID == deviceEmployee.Employee.ID && x.DeviceID == deviceEmployee.Device.ID);
                    if (employee == null) continue;
                    employee.Db = deviceEmployee.Db;
                    employee.Picture = deviceEmployee.Picture;
                    employee.Finger = deviceEmployee.Finger;
                    EchoDbEntities.Entry(employee).State = EntityState.Modified;
                }

                EchoDbEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DeviceEmp SelectEmployeeInDevice(Employee employee, Device device)
        {
            try
            {
                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.DeviceID == device.ID && x.EmpID == employee.ID);
                return deviceEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetFingerInAccess(Employee employee, Device device, bool flag)
        {
            try
            {
                var deviceEmployee =
                    EchoDbEntities.DeviceEmps.FirstOrDefault(
                        x => x.EmpID == employee.ID && x.DeviceID == device.ID);

                if (deviceEmployee != null)
                {
                    deviceEmployee.Finger = flag;
                    EchoDbEntities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void UpdateAccess(List<EmployeeInDevice> onlineDevices)
        {
            try
            {
                // EchoDbEntities.DeviceEmps.Load();

                foreach (var deviceEmployee in onlineDevices)
                {
                    var employee =
                        EchoDbEntities.DeviceEmps.FirstOrDefault(
                            x =>
                                x.EmpID == deviceEmployee.DeviceEmp.EmpID &&
                                x.DeviceID == deviceEmployee.DeviceEmp.DeviceID);
                    if (employee == null) continue;
                    employee.Db = deviceEmployee.Db;
                    employee.Picture = deviceEmployee.Picture;
                    employee.Finger = deviceEmployee.Finger;
                    EchoDbEntities.Entry(employee).State = EntityState.Modified;
                }

                EchoDbEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}