using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KinderGarden.Core;
using KinderGarden.Data;

namespace KinderGardenApp
{
    public class ApplicationModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
        public ApplicationModel(KinderGarden.Data.KindergardenDbContext context)
        {
            _context = context;
            this.saved = false;
        }
        [BindProperty]
        public  Kid kid { get; set; }
        [BindProperty]
        public Parents parent { get; set; }
        public bool saved { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var found = false;
            kid.AplicationDate = DateTime.Now;
            try
            {
                Parents parentFound = _context.Parents.Where(p => p.Email == parent.Email).First();
                if(parentFound!=null)
                {
                    if(parentFound.kids == null)
                    {
                        parentFound.kids = new List<Kid>();
                    }
                    parentFound.kids.Add(kid);
                    found = true;
                    _context.SaveChanges();
                }
                
            } catch (Exception e)
            {
                found = false;
                //
            }
            if(found==false){
                parent.kids = new List<Kid> { kid };
                _context.Add(parent);
                _context.SaveChanges();
            }
            saved = true;
            return Page();
        }
    }
}