using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Instrumente
{
    public class DetailsModel : PageModel
    {
        private readonly InstrumenteMuzicale.Models.InstrumenteMuzicaleContext _context;

        public DetailsModel(InstrumenteMuzicale.Models.InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public Instrument Instrument { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrumente.FirstOrDefaultAsync(m => m.ID == id);

            if (instrument is not null)
            {
                Instrument = instrument;

                return Page();
            }

            return NotFound();
        }
    }
}
