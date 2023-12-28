using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

		[DisplayName("Зображення")]
		public string? Image { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Назва")]
		public string? Title { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Автор")]
		public string? Author { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Опис")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Введіть значення для поля.")]
		[DisplayName("Рік")]
		[Range(1000, 9999, ErrorMessage = "Рік має бути у діапазоні 1000-9999")]
		public int Year { get; set; }

		[Required(ErrorMessage = "Вибір категорії обов'язковий.")]
		[DisplayName("Категорія")]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category? Category { get; set; }
    }
}