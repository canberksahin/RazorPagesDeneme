using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDeneme.Models;

namespace RazorPagesDeneme.Pages.Kisiler
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDeneme.Models.OkulContext _context;

        public CreateModel(RazorPagesDeneme.Models.OkulContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kisi Kisi { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kisiler.Add(Kisi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
