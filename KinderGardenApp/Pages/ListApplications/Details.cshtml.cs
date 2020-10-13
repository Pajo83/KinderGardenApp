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
        public Kindergardens Kindergarden { get; set; }
        
        [BindProperty]
        public Parents Parent { get; set; }

        public string returnPage { get; set; }

        public IActionResult OnGet(string returnPage, int id)
        {
            if (Program.loggedUser == false)
            {
                return RedirectToPage("./NotFound");
            }

            Kid = _context.Kids.Where(k => k.Id == id).First(); 
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }
            Parent = _context.Parents.Where(p => p.Id == Kid.ParentId).First();
            Kindergarden = _context.Kindergardens.Where(k => k.Id == Kid.KindergardenId).First();
            if (returnPage == "accepted")
            {
                this.returnPage = "./Accepted";
            } else if(returnPage == "denied")
            {
                this.returnPage = "./DeniedList";

            } else
            {
                this.returnPage = "./ListApplications";
            }
            return Page();
        }
        
    }
}