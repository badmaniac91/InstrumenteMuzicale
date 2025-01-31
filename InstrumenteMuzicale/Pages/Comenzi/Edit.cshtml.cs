using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Comenzi
{
    public class EditModel : PageModel
    {
        private readonly InstrumenteMuzicale.Models.InstrumenteMuzicaleContext _context;

        public EditModel(InstrumenteMuzicale.Models.InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda =  await _context.Comenzi.FirstOrDefaultAsync(m => m.ID == id);
            if (comanda == null)
            {
                return NotFound();
            }
            Comanda = comanda;
           ViewData["InstrumentID"] = new SelectList(_context.Instrumente, "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(Comanda.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComandaExists(int id)
        {
            return _context.Comenzi.Any(e => e.ID == id);
        }
    }
}
