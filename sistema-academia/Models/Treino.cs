using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class Treino
    {


        [Key]
        public int id { get; set; }

        [Required]
        [Column("nome", TypeName = "varchar(100)")]
        public string nome { get; set; }



        [Required]
        [Column("objetivo", TypeName = "varchar(100)")]
        public string objetivo { get; set; }


        
        [Column("observacao", TypeName = "varchar(100)")]
        public string observacao { get; set; }

        [Column("dataCadastro", TypeName = "datetime")]
        public DateTime dataCadastro {get; set;}



        public virtual Aluno Aluno { get; set; }

        public virtual ICollection<ExercicioTreino> ExerciciosTreinos { get; set; }


    }


}