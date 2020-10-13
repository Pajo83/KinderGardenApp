using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KinderGarden.Data;
using KinderGarden.Core;
using Microsoft.Extensions.Configuration;

namespace KinderGardenApp
{
    public class ListApplicationsModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
       
        public ListApplicationsModel(KinderGarden.Data.KindergardenDbContext context)
        {
            _context = context;
           
        }
        [BindProperty]
        public List<Kid> kids { get; set; }

        public void OnGet()
        {
            if (Program.loggedUser == false)
            {
                RedirectToPage("./NotFound");
            }

            kids = _context.Kids.Where(k => k.Status == Statuses.Se_procesira).ToList<Kid>();
            
        }
    }
}