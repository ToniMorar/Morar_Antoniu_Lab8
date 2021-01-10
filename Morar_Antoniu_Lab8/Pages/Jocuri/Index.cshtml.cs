using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Morar_Antoniu_Lab8.Data;
using Morar_Antoniu_Lab8.Models;

namespace Morar_Antoniu_Lab8.Pages.Jocuri
{
    public class IndexModel : PageModel
    {
        private readonly Morar_Antoniu_Lab8.Data.Morar_Antoniu_Lab8Context _context;

        public IndexModel(Morar_Antoniu_Lab8.Data.Morar_Antoniu_Lab8Context context)
        {
            _context = context;
        }

        public IList<Joc> Joc { get; set; }

        public JocData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new JocData();

            BookD.Jocuri = await _context.Joc
            .Include(b => b.Publisher)
            .Include(b => b.JocCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                BookID = id.Value;
                Joc book = BookD.Jocuri
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.JocCategories.Select(s => s.Category);
            }
        }
    }
}
