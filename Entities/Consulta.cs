using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultaId { get; set; }

        [Column("data_consulta")]
        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }

        [Column("usuario_id")]
        [ForeignKey("Usuario")]
        public int UserId { get; set; }

        [Column("medico_id")]
        [ForeignKey("Medico")]
        public int MedicoId { get; set; }

        [Column("consultorio_id")]
        [ForeignKey("Consultorio")]
        public int ConsultorioId { get; set; }

        [Column("prescricao_id")]
        [ForeignKey("Prescricao")]
        public int? PrescricaoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Consultorio Consultorio { get; set; }
        public virtual Prescricao Prescricao { get; set; }
    }
}