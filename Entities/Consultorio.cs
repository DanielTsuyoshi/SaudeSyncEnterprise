using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("Consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultorioId { get; set; }

        [Column("nome_consultorio")]
        [Required(ErrorMessage = "O nome do consultório é obrigatório.")]
        [MaxLength(100)]
        public string NomeConsultorio { get; set; }

        [Column("endereco")]
        [Required(ErrorMessage = "O endereço do consultório é obrigatório.")]
        [MaxLength(255)]
        public string Endereco { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}