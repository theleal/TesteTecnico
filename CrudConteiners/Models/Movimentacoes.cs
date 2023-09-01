using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CrudConteiners.Enums.Enums;

namespace CrudConteiners.Models
{
    public class Movimentacoes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime DataHoraInicio { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime DataHoraFim { get; set; }

        [ForeignKey("Conteiner")]
        public int ID_Conteiner { get; set; }

        public virtual Conteiner? Conteiner { get; set; }
    }
}
