using System.ComponentModel.DataAnnotations;

namespace ExerciciosPadraoMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 2 e 80 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres.")]
        [Required(ErrorMessage = "a descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres.")]
        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local { get; set; } = string.Empty;

        public DateTime DataEvento { get; set; }

        [Range(1, 1000)]
        public int QuantidadeVagas { get; set; }
        public decimal ValorIngresso { get; set; }
    }
}