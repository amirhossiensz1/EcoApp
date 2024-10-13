namespace Model
{
    public class EmployeeInDevice
    {
        public int Id { get; set; }
        public int? DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIp { get; set; }
        public bool? Finger { get; set; }
        public bool? Db { get; set; }
        public bool? Picture { get; set; }
        public Device Device { get; set; }
        public DeviceEmp DeviceEmp { get; set; }
        public Employee Employee { get; set; }
    }
}