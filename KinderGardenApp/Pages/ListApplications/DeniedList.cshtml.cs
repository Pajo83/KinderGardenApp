using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace KinderGardenApp
{
    public class DeniedListModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
      
        public DeniedListModel(KinderGarden.Data.KindergardenDbContext context)
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
            kids = _context.Kids.Where(k => k.Status == Statuses.Odbien).ToList<Kid>();

           
        }
    }
}