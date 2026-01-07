using AgendamentoPro.Data;
using AgendamentoPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendamentoPro.Pages.Admin.Services
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = new();

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Service.Name) || Service.Price <= 0)
            {
                return Page();
            }

            _context.Services.Add(Service);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
