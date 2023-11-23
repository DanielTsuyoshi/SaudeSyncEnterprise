using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("LeiturasSaude")]
    public class LeituraSaude
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeituraSaudeId { get; set; }

        [Column("data_leitura")]
        [Required(ErrorMessage = "A data da leitura é obrigatória.")]
        public DateTime DataLeitura { get; set; }

        [Column("pressao_arterial")]
        public string PressaoArterial { get; set; }

        [Column("glicose")]
        public string Glicose { get; set; }

        [Column("peso")]
        public decimal Peso { get; set; }

        [Column("altura")]
        public decimal Altura { get; set; }

        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UserId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}