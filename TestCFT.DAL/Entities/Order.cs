namespace TestCFT.DAL.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DataEnd { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public long ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
