using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Model
{
    [Table("horarios")]
    public class Horarios
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Horario { get; set; }

    }
}
