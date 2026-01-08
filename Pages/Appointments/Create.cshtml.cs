using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendamentoPro.Models;

namespace AgendamentoPro.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Appointment Appointment { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // por enquanto só redireciona
            return RedirectToPage("/Index");
        }
    }
}
