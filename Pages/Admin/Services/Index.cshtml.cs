using AgendamentoPro.Data;
using AgendamentoPro.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendamentoPro.Pages.Admin.Services
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Service> Services { get; set; } = new();

        public void OnGet()
        {
            Services = _context.Services.ToList();
        }
    }
}
