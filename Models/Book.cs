using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Назва книги")]
		public string? Title { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Опис")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Ціна")]
		[Range(1, int.MaxValue, ErrorMessage = "Ціна має бути більше нуля.")]
		public int Price { get; set; }
    }
}