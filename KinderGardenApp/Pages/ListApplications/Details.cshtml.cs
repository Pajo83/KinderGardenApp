using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KinderGarden.Data;
using KinderGarden.Core;

namespace KinderGardenApp
{
    public class DetailsModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
        public DetailsModel(KinderGarden.Data.KindergardenDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Kid Kid { get; set; }
        
        [BindProperty]
        public Parents Parent { get; set; }

        public string returnPage { get; set; }

        public IActionResult OnGet(string returnPage, int id)
        {
            Kid = _context.Kids.Where(k => k.Id == id).First(); 
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }
            Parent = _context.Parents.Where(p => p.Id == Kid.ParentId).First();
            this.returnPage = returnPage == "accepted" ? "./Accepted" : "./ListApplications";
            return Page();
        }
        
    }
}