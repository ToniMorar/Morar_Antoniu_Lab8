using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Morar_Antoniu_Lab8.Data;


namespace Morar_Antoniu_Lab8.Models
{
    public class JocCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Morar_Antoniu_Lab8Context context,
        Joc book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
            book.JocCategories.Select(c => c.JocID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Morar_Antoniu_Lab8Context context,
        string[] selectedCategories, Joc bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.JocCategories = new List<JocCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.JocCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.JocCategories.Add(
                        new JocCategory
                        {
                            JocID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        JocCategory courseToRemove
                        = bookToUpdate
                        .JocCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
            {
            }
        }
    }
}
