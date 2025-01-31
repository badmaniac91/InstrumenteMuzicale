using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly InstrumenteMuzicaleContext _context;

        public IndexModel(InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public List<Comanda> Comenzi { get; set; } = new List<Comanda>();

        public async Task OnGetAsync()
        {
            Comenzi = await _context.Comenzi
                .Include(c => c.Instrument)
                .ToListAsync();
        }
    }
}
