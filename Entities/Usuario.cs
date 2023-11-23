using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeSync.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column("nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("cpf")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email precisa ser válido")]
        [MaxLength(256)]
        public string Email { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        [MaxLength(60)]
        public string Senha { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}