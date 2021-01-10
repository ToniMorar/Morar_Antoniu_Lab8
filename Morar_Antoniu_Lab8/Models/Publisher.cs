using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morar_Antoniu_Lab8.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Joc> Jocuri { get; set; }
    }
}
