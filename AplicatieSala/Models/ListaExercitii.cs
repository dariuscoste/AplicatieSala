using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieSala.Models
{
    public class ListaExercitii
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ListaAplicatie))]
        public int ListaExercitiiID { get; set; }
        public int ExercitiuID { get; set; }
    }
}
