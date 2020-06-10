using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDeneme.Pages
{
    public class CanberkModel : PageModel
    {
        public string Sonuc { get; set; }
        public string GozRenk { get; set; }
        public void OnGet( bool? dogruMu )
        {
            ViewData["ad"] = "Canberk";

            GozRenk = "Siyah";

            if (dogruMu.HasValue )
            {
                Sonuc = dogruMu.Value ? "Tebrikler bildiniz." : "Malesef, bilemediniz.";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool result = Quiz.Cevap.ToLower() == "şahin"; 
            return RedirectToPage("./Canberk" , new { dogruMu = result });
        }

        [BindProperty]
        public Quiz Quiz { get; set; }
    }

    public class Quiz
    {
        [Required]
        public string Cevap { get; set; }


    }
}