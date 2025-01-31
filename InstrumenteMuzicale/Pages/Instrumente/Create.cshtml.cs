using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Instrumente
{
    public class CreateModel : PageModel
    {
        private readonly InstrumenteMuzicale.Models.InstrumenteMuzicaleContext _context;

        public CreateModel(InstrumenteMuzicale.Models.InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Instrument Instrument { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instrumente.Add(Instrument);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
