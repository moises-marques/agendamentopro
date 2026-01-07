using AgendamentoPro.Data;
using AgendamentoPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendamentoPro.Pages.Admin.Services
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var service = _context.Services.Find(id);

            if (Service == null)
                return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Service.Name) || Service.Price <= 0)
            {
                return Page();
            }

            _context.Services.Update(Service);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
