using AgendamentoPro.Data;
using AgendamentoPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendamentoPro.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Service> Services { get; set; } = new();

        [BindProperty]
        public int ServiceId { get; set; }

        [BindProperty]
        public DateOnly? Date { get; set; }

        [BindProperty]
        public TimeOnly Time { get; set; }

        public void OnGet()
        {
            Services = _context.Services.ToList();
        }

        public string? SuccessMessage { get; set; }

        public string? ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // 🔴 1️⃣ Validação básica
            if (ServiceId <= 0 || Date == null || Time == default)
            {
                ErrorMessage = "Preencha todos os campos corretamente.";
                Services = _context.Services.ToList();
                return Page();
            }

            // 🔴 2️⃣ Bloquear datas passadas
            if (Date < DateOnly.FromDateTime(DateTime.Today))
            {
                ErrorMessage = "Não é possível agendar para datas passadas.";
                Services = _context.Services.ToList();
                return Page();
            }

            // 🔴 3️⃣ BLOQUEAR HORÁRIO DUPLICADO
            bool exists = _context.Bookings.Any(b =>
                b.ServiceId == ServiceId &&
                b.Date == Date.Value &&
                b.Time == Time
            );

            if (exists)
            {
                ErrorMessage = "Este horário já está ocupado para este serviço.";
                Services = _context.Services.ToList();
                return Page();
            }

            // 🟢 4️⃣ Salvar agendamento
            var booking = new Booking
            {
                ServiceId = ServiceId,
                Date = Date.Value,
                Time = Time,
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            SuccessMessage = "Agendamento realizado com sucesso!";

            // 🔄 Limpar formulário
            ServiceId = 0;
            Date = null;
            Time = default;

            Services = _context.Services.ToList();
            ModelState.Clear();

            return Page();
        }

    }
}
