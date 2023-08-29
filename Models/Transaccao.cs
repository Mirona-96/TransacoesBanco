using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransacoesBanco.Models
{
    public class Transaccao
    {
        [Key]
        public int TransaccaoId { get; set; }


        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Número de Conta")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(12, ErrorMessage = "O máximo de apenas 12 caracteres é possível")]
        public  string NumeroConta { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nome do Beneficiario")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string TitularConta { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nome do Banco")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeBanco { get; set; }


        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Código Swift")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(12, ErrorMessage = "O máximo de apenas 11 caracteres é possível")]
        public string CodigoSWIFT { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Montante { get; set; }


        [DisplayName("Data da Transacção")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yy}")]
        public DateTime DataTransaccao { get; set; }
    }
}
