using System;
using System.Collections.Generic;
using System.Linq;
using DBLayer;
using Model;

namespace BLL
{
    public class DeviceEmpBll
    {
        public IQueryable<EmployeeInDevice> EmployeeInDevices(int empId)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                return deviceEmpDb.EmployeeInDevices(empId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<EmployeesInOneDevice> EmployeesInOneDevices(int deviceId)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                return deviceEmpDb.EmployeeInOneDevice(deviceId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletedevicefromDeviceEmp(object id)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.DeleteDeviceFromDeviceEmp(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEmployeesfromDeviceEmp(object[] id, int deviceId)
        {
            var deviceEmp = new DeviceEmpDB();
            deviceEmp.DeleteEmployeesFromDevice(id, deviceId);
        }

        public void DeleteEmployeesfromDeviceEmp(List<Employee> employees)
        {
            var deviceEmp = new DeviceEmpDB();
            var deviceBll = new DeviceBLL();
            var deviceList = deviceBll.SelectDevices();
            foreach (var device in deviceList)
            {
                deviceEmp.DeleteEmployeesFromDevice(employees, device.ID);
            }
        }

        public void DeleteEmployeefromDeviceEmp(object id)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.DeleteEmployeeFromDeviceEmp(id);
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
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.DeleteFingerfromDeviceEmp(empId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteFingerfromDeviceEmp(int empId, List<Device> devices)
        {
            try
            {
                foreach (var device in devices)
                {
                    var deviceEmpDb = new DeviceEmpDB();
                    deviceEmpDb.DeleteFingerfromDeviceEmp(empId, device);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> BasicInfoEmployeeInDevice(int deviceId)
        {
            var deviceEmpDb = new DeviceEmpDB();
            var employeeDb = new EmployeeDb();
            var employeelist = new List<Employee>();
            var deviceEmpList = deviceEmpDb.SelectDbEmpInDevice(deviceId);
            //   var GuestList = employeeDb.SelectAllGuest();

            foreach (var deviceEmp in deviceEmpList)
            {
                employeelist.Add(employeeDb.SelectOneEmployee(deviceEmp.EmpID));
            }
            //foreach (var Guest in GuestList)
            //{
            //    employeelist.Add(Guest);
            //}

            return employeelist;
        }

        public bool UpdateAccess2(List<Employee> employees, List<Device> devices, bool finger, bool picture,
            bool db)
        {
            try
            {
                var deviceEmp = new DeviceEmpDB();
                return deviceEmp.UpdateAllEmpDevice(employees, devices, finger, picture, db);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CuncurrentUpdateAccess(List<Employee> employees, Device device, bool finger, bool picture, bool db)
        {
            try
            {
                var deviceEmp = new DeviceEmpDB();
                return deviceEmp.CuncurrentUpdateAllEmpDevice(employees, device, finger, picture, db);
            }
            catch (Exception)
            {
                throw;
            }
        }


//        public Boolean UpdateAccess(List<Employee> employees, List<Device> devices, Boolean finger, Boolean picture, Boolean db)
//        {
//            try
//            {
//                var deviceEmp = new DeviceEmp();
//                var deviceEmpDb = new DeviceEmpDB();
//
//                    foreach (var device in devices)
//                    {
//                            foreach (var employee in employees)
//                            {
//                                
//                                deviceEmp.DeviceID = device.ID;
//                                deviceEmp.EmpID = employee.ID;
//
//                                if ((deviceEmpDb.ExistFingerEmpInDevice(employee.ID, device.ID) || finger) && employee.HasFinger == true)
//                                    deviceEmp.Finger = true;
//                                else
//                                {
//                                    deviceEmp.Finger = false;
//                                }
//                                if ((deviceEmpDb.ExistPictureEmpInDevice(employee.ID, device.ID) || picture) && employee.Image != null)
//                                    deviceEmp.Picture = true;
//                                else
//                                {
//                                    deviceEmp.Picture = false;
//                                }
//                                if (deviceEmpDb.ExistDbEmpInDevice(employee.ID, device.ID) || db)
//                                    deviceEmp.Db = true;
//                                else
//                                {
//                                    deviceEmp.Db = false;
//                                }
//                                if (deviceEmpDb.ExistOneEmployee(employee.ID, device.ID))
//                                    deviceEmpDb.UpdateOneEmployee(deviceEmp);
//
//                                else
//                                {
//                                    deviceEmpDb.InsertOneDeviceEmp(deviceEmp);
//                                }
//                            }
//                    }
//                return true;
//            }
//            catch (Exception )
//            {
//                return false;
//                throw;
//            }
//        }

        public void InsertOneEmpToAccess(Employee employee, List<Device> devices)
        {
            try
            {
                var deviceEmp = new DeviceEmp();
                var deviceEmpDb = new DeviceEmpDB();

                foreach (var device in devices)
                {
                    deviceEmp.EmpID = employee.ID;
                    deviceEmp.DeviceID = device.ID;
                    deviceEmp.Finger = false;
                    deviceEmp.Picture = false;
                    deviceEmp.Db = false;
                    deviceEmpDb.InsertOneDeviceEmp(deviceEmp);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        public void InsertOneDeviceToAccess(List<Employee> employees, Device device)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.InsertDeviceToDeviceEmp(employees, device);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        public bool InsertFirstAccessEmployee(List<Employee> employees, List<Device> devices)
        {
            try
            {
                var deviceEmp = new DeviceEmp();
                var deviceEmpDb = new DeviceEmpDB();

                foreach (var device in devices)
                {
                    foreach (var employee in employees)
                    {
                        deviceEmp.DeviceID = device.ID;
                        deviceEmp.EmpID = employee.ID;

                        if (!deviceEmpDb.ExistOneEmployee(employee.ID, device.ID))
                        {
                            deviceEmp.Finger = deviceEmpDb.ExistFingerEmpInDevice(employee.ID, device.ID);
                            deviceEmp.Picture = deviceEmpDb.ExistPictureEmpInDevice(employee.ID, device.ID);
                            deviceEmp.Db = deviceEmpDb.ExistDbEmpInDevice(employee.ID, device.ID);
                            deviceEmpDb.InsertOneDeviceEmp(deviceEmp);
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }


        public void UpdateAccess(List<EmployeesInOneDevice> employeeInDevice)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.UpdateAccess(employeeInDevice);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpdateAccess(List<EmployeeInDevice> onlineDevices)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.UpdateAccess(onlineDevices);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DeviceEmp SelectEmployeeInDevice(Employee employee, Device device)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                return deviceEmpDb.SelectEmployeeInDevice(employee, device);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetFingerTrueInAccess(Employee employee, Device device, bool flag)
        {
            try
            {
                var deviceEmpDb = new DeviceEmpDB();
                deviceEmpDb.SetFingerInAccess(employee, device, flag);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}