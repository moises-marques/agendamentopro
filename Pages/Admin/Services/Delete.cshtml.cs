using AgendamentoPro.Data;
using AgendamentoPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendamentoPro.Pages.Admin.Services
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
                return RedirectToPage("Index");

            Service = service;
            return Page();
        }

        public IActionResult OnPost()
        {
            var service = _context.Services.Find(Service.Id);

            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
