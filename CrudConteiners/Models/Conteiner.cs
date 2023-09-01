using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CrudConteiners.Enums.Enums;

namespace CrudConteiners.Models
{
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Cliente { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        [Column(TypeName = "VARCHAR(11)")]
        public string NumeroConteiner { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "INT")]
        public TipoConteiner TipoConteiner { get; set; }

        [Required]
        [Column(TypeName = "INT")] 
        public Status Status { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public Categoria Categoria { get; set; }    

    }
}
