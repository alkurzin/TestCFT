using System.ComponentModel.DataAnnotations;

namespace TestCFT.BLL.DTO
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime DataEnd { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
