using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Morar_Antoniu_Lab8.Data;
using Morar_Antoniu_Lab8.Models;

namespace Morar_Antoniu_Lab8.Pages.Jocuri
{
    public class CreateModel : JocCategoriesPageModel
    {
        private readonly Morar_Antoniu_Lab8.Data.Morar_Antoniu_Lab8Context _context;

        public CreateModel(Morar_Antoniu_Lab8.Data.Morar_Antoniu_Lab8Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var book = new Joc();
            book.JocCategories = new List<JocCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Joc Joc { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Joc();
            if (selectedCategories != null)
            {
                newBook.JocCategories = new List<JocCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new JocCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.JocCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Joc>(
            newBook,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Joc.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
