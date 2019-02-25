using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SnowCalc.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnowCalc.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly SnowCalcService _snowService;

        public IndexModel(SnowCalcService snowService)
        {
            _snowService = snowService;
        }

        // Selected Zone
        public int Zone { get; set; }

        [Display(Name = "Höhe ü.d.M. in m"), Range(0, 1500)]
        public int Hoehe { get; set; }

        [Range(0, 60)]
        public int Dachneigung { get; set; }

        public double SkB { get; set; }
        public double SkD { get; set; }

        public List<SelectListItem> Zones
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Zone 1" },
                    new SelectListItem { Value = "2", Text = "Zone 1a" },
                    new SelectListItem { Value = "3", Text = "Zone 2" },
                    new SelectListItem { Value = "4", Text = "Zone 2a" },
                    new SelectListItem { Value = "5", Text = "Zone 3" }
                };
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SkB = _snowService.CalcSkb(Zone, Hoehe);
            SkD = _snowService.CalcSkd(Dachneigung, SkB);

            return Page();
        }
    }
}
