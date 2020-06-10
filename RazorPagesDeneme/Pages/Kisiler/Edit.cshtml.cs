using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDeneme.Models;

namespace RazorPagesDeneme.Pages.Kisiler
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDeneme.Models.OkulContext _context;

        public EditModel(RazorPagesDeneme.Models.OkulContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kisi Kisi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kisi = await _context.Kisiler.FirstOrDefaultAsync(m => m.Id == id);

            if (Kisi == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KisiExists(Kisi.Id))
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

        private bool KisiExists(int id)
        {
            return _context.Kisiler.Any(e => e.Id == id);
        }
    }
}
