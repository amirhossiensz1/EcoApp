namespace Model
{
    public class GuestCard
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CardNumberStr { get; set; }
        public int? CardNumber { get; set; }
        public string CardData { get; set; }
        public int? EmpID { get; set; }
        public bool? IsGuest { get; set; }
    }
}