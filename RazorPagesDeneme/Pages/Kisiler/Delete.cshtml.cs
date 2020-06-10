using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDeneme.Models;

namespace RazorPagesDeneme.Pages.Kisiler
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesDeneme.Models.OkulContext _context;

        public DeleteModel(RazorPagesDeneme.Models.OkulContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kisi = await _context.Kisiler.FindAsync(id);

            if (Kisi != null)
            {
                _context.Kisiler.Remove(Kisi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
