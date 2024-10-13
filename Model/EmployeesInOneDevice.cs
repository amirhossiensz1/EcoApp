namespace Model
{
    public class EmployeesInOneDevice
    {
        public int Id { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public string PersonalNum { get; set; }
        public bool? Finger { get; set; }
        public bool? Db { get; set; }
        public bool? Picture { get; set; }

        public Employee Employee { get; set; }

        public DeviceEmp DeviceEmp { get; set; }

        public Device Device { get; set; }
    }
}