using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class PresencaAluno
    {


        [Key]
        public int id { get; set; }

        public virtual Aluno Aluno { get; set; }

        [Column("dataPresenca", TypeName = "datetime")]
        public DateTime dataPresenca {get; set;}

    }

}