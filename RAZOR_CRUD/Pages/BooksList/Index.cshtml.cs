using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAZOR_CRUD.Models;

namespace RAZOR_CRUD.Pages.BooksList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book deleted successfully";

            return RedirectToPage("Index");
        }
    }
}