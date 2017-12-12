using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Model
{
    [Table("objetivos")]
    public class Objetivos
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Objetivo { get; set; }

    }
}
