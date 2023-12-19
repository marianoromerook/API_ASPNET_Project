using System.ComponentModel.DataAnnotations;

namespace API_RESTful_Project.Models
{
    public class LinkModel
    {
        [Required(ErrorMessage = "La URL es obligatoria.")]
        [Url(ErrorMessage = "Por favor, introduce una URL válida.")]
        public string? Url { get; set; }
    }
}
