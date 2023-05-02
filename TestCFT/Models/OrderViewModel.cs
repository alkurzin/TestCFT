using System.ComponentModel.DataAnnotations;

namespace TestCFT.Models
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано приложение")]
        public string ApplicationName { get; set; }
        [Required(ErrorMessage = "Не указана дата окончания разработки")]
        [RegularExpression(@"[0-3][0-9].[0-1][0-9].[0-9]{4}", ErrorMessage = "Некорректный формат(ДД.ММ.ГГГГ)")]
        public string DataEnd { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        public string Email { get; set; }
    }
}
