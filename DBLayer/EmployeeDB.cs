using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using Model;

namespace DBLayer
{
    public class EmployeeDb
    {
        private readonly EchoDBEntities _echoDbEntities = new EchoDBEntities();

        public void AddEmployees(Employee emp)
        {
            try
            {
                _echoDbEntities.Employees.Add(emp);
                _echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        public List<Employee> SelectEmployeeAndGuest()
        {
            try
            {
                _echoDbEntities.Employees.Load();
                var employeeList = _echoDbEntities.Employees.Local.ToList();
                return employeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Employee> SelectEmployee()
        {
            try
            {
                var employeeList = _echoDbEntities.Employees.Where(x => x.IsGuest != true);
                return employeeList.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<EmployeeDto> SelectEmployeeList()
        {
            try
            {
                var employeeList = _echoDbEntities.Employees.Where(x => x.IsGuest != true).ToList();
                var employeeDtos = new List<EmployeeDto>();

                foreach (var employee in employeeList)
                {
                    var empdto = new EmployeeDto();
                    if (employee.Organization != null)
                        empdto.OrganizationName = employee.Organization.name;
                    if (employee.AccessGroup != null)
                        empdto.AccessGroupName = employee.AccessGroup.Name;
                    empdto.ID = employee.ID;
                    empdto.EmpLname = employee.EmpLname;
                    empdto.EmpFname = employee.EmpFname;
                    empdto.EmpNationalCode = employee.EmpNationalCode;
                    empdto.AuthenticationMode = employee.AuthenticationMode;
                    empdto.EmpPinCode = employee.EmpPinCode;
                    empdto.Image = employee.Image;
                    empdto.PersonalNum = employee.PersonalNum;
                    empdto.HasCard = employee.HasCard;
                    empdto.HasFinger = employee.HasFinger;
                    employeeDtos.Add(empdto);
                }

                return employeeDtos.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<EmployeeDto> SelectEmployee1()
        {
            try
            {
                var employeeList = _echoDbEntities.Employees.Where(x => x.IsGuest != true).Select(x => new EmployeeDto
                {
                    ID = x.ID,
                    EmpFname = x.EmpFname,
                    EmpLname = x.EmpLname,
                    EmpNationalCode = x.EmpNationalCode,
                    PersonalNum = x.PersonalNum,
                    EmpPinCode = x.EmpPinCode,
                    AuthenticationMode = x.AuthenticationMode,
                    TelePhone = x.TelePhone,
                    Post = x.Post,
                    HasFinger = x.HasFinger,
                    HasCard = x.HasCard,
                    MenuAccess = x.MenuAccess,
                    IsGuest = x.IsGuest
                });
                return employeeList.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            try
            {
                _echoDbEntities.Employees.Remove(employee);
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteOneEmployee(object id)
        {
            try
            {
                var employee = new Employee();
                employee = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == (int) id);
                _echoDbEntities.Employees.Remove(employee);
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

        public Employee SelectOneEmployee(object id)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == (int) id);
                _echoDbEntities.SaveChanges();
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Employee SelectEmployee(string nationalCode)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.EmpNationalCode == nationalCode);
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Employee SelectOneEmployee(string personalNum)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.PersonalNum == personalNum);
                _echoDbEntities.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public int SelectLastEmployeeId()
        {
            try
            {
                var lastId = _echoDbEntities.Employees.Max(x => x.ID);
                _echoDbEntities.SaveChanges();
                return lastId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == employee.ID);

                if (emp != null)
                {
                    _echoDbEntities.Entry(emp).CurrentValues.SetValues(employee);
                    _echoDbEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpdateEmployeeforZK(Employee employee)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == employee.ID);

                if (emp != null)
                {
                    _echoDbEntities.Entry(emp).CurrentValues.SetValues(employee);
                    _echoDbEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            };
        }

        public void saveChanges()
        {
            _echoDbEntities.SaveChanges();
        }

        public void SetHasCard(int id)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == id);

                if (emp != null)
                {
                    emp.HasCard = true;
                }

                _echoDbEntities.Entry(emp).State = EntityState.Modified;
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetHasFinger(int employeeId)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == employeeId);

                if (emp != null)
                {
                    emp.HasFinger = true;
                }

                //_echoDbEntities.Entry(emp).State = EntityState.Modified;
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetCard(Employee employee)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == employee.ID);

                if (emp != null)
                {
                    emp.HasCard = false;
                }

                _echoDbEntities.Entry(emp).State = EntityState.Modified;
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetFalseFinger(Employee employee)
        {
            try
            {
                var emp = _echoDbEntities.Employees.FirstOrDefault(x => x.ID == employee.ID);

                if (emp != null)
                {
                    emp.HasFinger = false;
                }

                _echoDbEntities.Entry(emp).State = EntityState.Modified;
                _echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ImportEmployeeToSql(string excelfilepath)
        {
            try
            {
                var employee = "Employee";
                //   string myexceldataquery = "select ID,FirstName,LastName,NationalCode,PersonalNum,PersonalNum from [sheet1$]";

                var myexceldataquery = "select * from [sheet1$]";

                //create our connection strings
                var sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0; data source=" + excelfilepath +
                                             ";extended properties=" + "\"Excel 12.0;hdr=yes;\"";

                var ssqlconnectionstring =
                    ConfigurationManager.ConnectionStrings["EchoDBEntities"].ConnectionString;

                var stratIndex = ssqlconnectionstring.IndexOf("data source", StringComparison.Ordinal);
                var endIndex = ssqlconnectionstring.IndexOf("MultipleActiveResultSets", StringComparison.Ordinal);
                ssqlconnectionstring = ssqlconnectionstring.Substring(stratIndex, endIndex - stratIndex);

                //series of commands to bulk copy data from the excel file into our sql table
                var oledbconn = new OleDbConnection(sexcelconnectionstring);
                var oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                var dr = oledbcmd.ExecuteReader();
                var bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = employee;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }

                oledbconn.Close();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool ExistNationalCode(string nationalCode)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.EmpNationalCode == nationalCode);

                if (employee == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool ExistPersonalNum(string personalNum)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.PersonalNum == personalNum);

                if (employee == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePicBasedNationalCode(byte[] dataPic, string nationalCode)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.EmpNationalCode == nationalCode);
                if (employee != null)
                {
                    employee.Image = dataPic;
                    _echoDbEntities.Entry(employee).CurrentValues.SetValues(employee);
                    _echoDbEntities.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePicBasedPersonalNum(byte[] dataPic, string personalNum)
        {
            try
            {
                var employee = _echoDbEntities.Employees.FirstOrDefault(x => x.PersonalNum == personalNum);
                if (employee != null)
                {
                    employee.Image = dataPic;
                    _echoDbEntities.Entry(employee).CurrentValues.SetValues(employee);
                    _echoDbEntities.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Employee> SelectAllGuest()
        {
            try
            {
                _echoDbEntities.Employees.Load();

                var employeeList = _echoDbEntities.Employees.Where(x => x.IsGuest == true);


                return employeeList.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public List<string> SelectNationalCodeFromTaInDevice(string deviceIp)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["NahadConnection"]);

                var sqlCommand =
                    new SqlCommand(
                        "SELECT [ID],[nationalcode],[deviceIp],[IsExist],[Sync] FROM [TA].[dbo].[PdpValidPersons]" +
                        " where IsExist = 1 and deviceIp = @deviceIp"
                        , sqlConnection);
                sqlCommand.Parameters.AddWithValue("@deviceIp", deviceIp);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<string> nationalCodeList = new List<string>();

                while (sqlDataReader.Read())
                {
                    var national = Convert.ToString(sqlDataReader["nationalcode"]);
                    nationalCodeList.Add(national);
                }
                sqlConnection.Close();
                sqlDataReader.Close();

                return nationalCodeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}