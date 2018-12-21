using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAZOR_CRUD.Models;
using System.Threading.Tasks;

namespace RAZOR_CRUD.Pages.BooksList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }


        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Update(Book);
                await _db.SaveChangesAsync();
                Message = "Book has been updated successfully";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}