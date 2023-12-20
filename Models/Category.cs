using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Назва категорії")]
        public string? Name { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Порядок відображення")]
		[Range(1, int.MaxValue, ErrorMessage = "Порядок відображення категорії має бути більше нуля.")]
        public int DisplayOrder { get; set; }
    }
}
