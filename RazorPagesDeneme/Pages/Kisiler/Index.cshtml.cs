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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDeneme.Models.OkulContext _context;

        public IndexModel(RazorPagesDeneme.Models.OkulContext context)
        {
            _context = context;
        }

        public IList<Kisi> Kisi { get;set; }

        public async Task OnGetAsync()
        {
            Kisi = await _context.Kisiler.ToListAsync();
        }
    }
}
