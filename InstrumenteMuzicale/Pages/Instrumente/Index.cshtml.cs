using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstrumenteMuzicale.Pages.Instrumente
{
    public class IndexModel : PageModel
    {
        private readonly InstrumenteMuzicaleContext _context;

        public IndexModel(InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public List<Instrument> ListaInstrumente { get; set; } = new List<Instrument>();

        public async Task<IActionResult> OnGetAsync()
        {
            ListaInstrumente = await _context.Instrumente.ToListAsync();
            return Page();
        }
    }
}
