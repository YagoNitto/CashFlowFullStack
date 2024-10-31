using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Categories;
public class UpdateCategoryRequest : Request
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Título inválido.")]
    [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres.")]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
