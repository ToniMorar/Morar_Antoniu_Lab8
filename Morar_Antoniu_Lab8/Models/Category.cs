using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morar_Antoniu_Lab8.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<JocCategory> JocCategories { get; set; }
    }
}
