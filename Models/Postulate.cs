using System.ComponentModel.DataAnnotations;

namespace API_RESTful_Project.Models
{
    public class Postulate
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;


        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime DateCreate { get; set; }

        public string? Organizacion { get; set; }

        // Relación con el modelo User existente
        public User? Usuario { get; set; }
        public string? UsuarioId { get; set; }
    }
}
