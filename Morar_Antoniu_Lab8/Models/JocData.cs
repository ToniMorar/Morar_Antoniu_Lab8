using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morar_Antoniu_Lab8.Models
{
    public class JocData
    {
        public IEnumerable<Joc> Jocuri { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<JocCategory> JocCategories { get; set; }
    }
}
