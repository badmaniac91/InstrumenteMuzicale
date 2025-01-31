using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Comenzi
{
    public class DetailsModel : PageModel
    {
        private readonly InstrumenteMuzicale.Models.InstrumenteMuzicaleContext _context;

        public DetailsModel(InstrumenteMuzicale.Models.InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi.FirstOrDefaultAsync(m => m.ID == id);

            if (comanda is not null)
            {
                Comanda = comanda;

                return Page();
            }

            return NotFound();
        }
    }
}
