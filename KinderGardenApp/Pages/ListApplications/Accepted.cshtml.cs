using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KinderGardenApp
{
    public class AcceptedModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
        public AcceptedModel(KinderGarden.Data.KindergardenDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Kid> kids { get; set; }

        public void OnGet()
        {
            kids = _context.Kids.Where(k => k.Status == Statuses.Primen).ToList<Kid>();
        }
    }
}