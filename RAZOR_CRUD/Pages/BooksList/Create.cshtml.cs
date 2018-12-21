using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAZOR_CRUD.Models;

namespace RAZOR_CRUD.Pages.BooksList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Books.Add(Book);
                await _db.SaveChangesAsync();
                Message = "Book created successfully";
                return RedirectToPage("Index");
                
            }

            return Page();
        }
    }
}