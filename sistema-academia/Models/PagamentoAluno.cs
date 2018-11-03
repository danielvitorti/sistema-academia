using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class PagamentoAluno
    {


        [Key]
        public int id { get; set; }


        [Required]
        [Display(Name = "Descrição")]
        [Column("descricao", TypeName = "varchar(255)")]
        public string descricao { get; set; }


        [Required]
        [Column("valor", TypeName = "decimal(4,2)")]
        [Display(Name = "Valor")]
        public decimal valor { get; set; }


        [Required]
        [Column("tipoPagamento", TypeName = "char(1)")]
        [Display(Name = "Tipo de pagamento")]
        public string tipoPagamento { get; set; }


        public virtual Aluno Aluno { get; set; }

        public virtual Plano Plano { get; set; }








    }


}