using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class Aluno
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column("nome", TypeName = "varchar(100)")]
        public string nome { get; set; }

        [Required]
        [Column("sexo", TypeName = "char(1)")]
        public string sexo { get; set; }


        
        [Column("enderecoCep", TypeName = "varchar(100)")]
        public string enderecoCep { get; set; }


        [Required]
        [Column("enderecoRua", TypeName = "varchar(100)")]
        public string enderecoRua { get; set; }

        [Required]
        [Column("enderecoNumero", TypeName = "char(15)")]
        public string enderecoNumero { get; set; }


        [Required]
        [Column("enderecoBairro", TypeName = "varchar(100)")]
        public string enderecoBairro { get; set; }


        [Required]
        [Column("enderecoCidade", TypeName = "varchar(100)")]
        public string enderecoCidade { get; set; }

        [Required]
        [Column("enderecoEstado", TypeName = "varchar(2)")]
        public string enderecoEstado { get; set; }

        [Column("dataCadastro", TypeName = "datetime")]
        public DateTime dataCadastro {get; set;}


        public virtual ICollection<Treino> Treinos { get; set; }

        public virtual ICollection<PlanoAluno> PlanosAlunos { get; set; }


        public virtual ICollection<PagamentoAluno> PagamentosAlunos { get; set; }

        public virtual ICollection<PresencaAluno> PresencasAlunos { get; set; }



    }
}
