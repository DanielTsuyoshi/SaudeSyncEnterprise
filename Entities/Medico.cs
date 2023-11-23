using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("Medicos")]
    public class Medico
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }

        [Column("nome_medico")]
        [Required(ErrorMessage = "O nome do médico é obrigatório.")]
        [MaxLength(100)]
        public string NomeMedico { get; set; }

        [Column("crm")]
        [Required(ErrorMessage = "O CRM do médico é obrigatório.")]
        [MaxLength(15)]
        public string CRM { get; set; }

        [Column("especialidade")]
        [Required(ErrorMessage = "A especialidade do médico é obrigatória.")]
        [MaxLength(100)]
        public string Especialidade { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}