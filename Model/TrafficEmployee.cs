namespace Model
{
    public class TrafficEmployee
    {
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public string DeviceName { get; set; }
        public byte[] Image { get; set; }
        public string EmpPersonalNum { get; set; }

        public int? Id { get; set; }
        public string Time { get; set; }
        public int? DeviceId { get; set; }
        public int EmpId { get; set; }
        public int? Mode { get; set; }
        public int? Type { get; set; }
        public string Date { get; set; }
        public bool? status { get; set; }

        public bool? Access { get; set; }
        public bool? SuccessPass { get; set; }

        public string ReqType { get; set; }
    }
}