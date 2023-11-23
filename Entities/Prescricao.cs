using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("Prescricoes")]
    public class Prescricao
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescricaoId { get; set; }

        [Column("descricao")]
        [Required(ErrorMessage = "A descrição da prescrição é obrigatória.")]
        public string Descricao { get; set; }

        [Column("consulta_id")]
        [ForeignKey("Consulta")]
        public int ConsultaId { get; set; }

        public virtual Consulta Consulta { get; set; }
    }
}