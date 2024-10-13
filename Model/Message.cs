namespace Model
{
    public class Message
    {
        public string Data { get; set; }

        public string DistinationIp { get; set; }

        public int? DistinationPort { get; set; }

        public string SourceIp { get; set; }

        public int SourcePort { get; set; }
    }
}