using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstrumenteMuzicale.Models;

namespace InstrumenteMuzicale.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly InstrumenteMuzicaleContext _context;

        [BindProperty]
        public Comanda Comanda { get; set; } = new Comanda();

        public SelectList InstrumenteSelectList { get; set; } = default!;

        public CreateModel(InstrumenteMuzicaleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var instrumente = await _context.Instrumente.ToListAsync();

            if (!instrumente.Any())
            {
                ModelState.AddModelError("", "Nu există instrumente disponibile. Adaugă un instrument mai întâi.");
            }

            InstrumenteSelectList = new SelectList(instrumente, "ID", "Nume");
            ViewData["Instrumente"] = InstrumenteSelectList;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var instrumente = await _context.Instrumente.ToListAsync();
                InstrumenteSelectList = new SelectList(instrumente, "ID", "Nume");
                ViewData["Instrumente"] = InstrumenteSelectList;
                return Page();
            }

            Comanda.DataComanda = DateTime.Now;

            var instrumentExist = await _context.Instrumente.AnyAsync(i => i.ID == Comanda.InstrumentID);
            if (!instrumentExist)
            {
                ModelState.AddModelError("", "Instrumentul selectat nu există.");
                return Page();
            }

            _context.Comenzi.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
