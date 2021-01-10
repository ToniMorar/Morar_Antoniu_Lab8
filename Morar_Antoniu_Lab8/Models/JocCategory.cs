using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morar_Antoniu_Lab8.Models
{
    public class JocCategory
    {
        public int ID { get; set; }
        public int JocID { get; set; }
        public Joc Book { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
