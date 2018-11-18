using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{

    public class ExercicioTreino
    {


        [Key]
        public int id { get; set; }

        [Required]
        [Column("nome", TypeName = "varchar(100)")]
        [Display(Name="Nome")]
        public string nome { get; set; }



        [Required]
        [Column("peso", TypeName = "decimal(3,2)")]
        [Display(Name="Peso (Kg)")]
        public decimal peso { get; set; }

        
        [Column("tempo", TypeName = "decimal(3,2)")]
        [Display(Name="Tempo de duração (min)")]
        public decimal tempo{ get; set;}


        [Column("observacao", TypeName = "varchar(100)")]
        [Display(Name="Observação")]
        public string observacao{ get; set;}


        [Column("dataCadastro", TypeName = "datetime")]
        [Display(Name="Data de cadastro")]

        public DateTime dataCadastro {get; set;}


        public virtual Treino Treino { get; set; }


    }

}