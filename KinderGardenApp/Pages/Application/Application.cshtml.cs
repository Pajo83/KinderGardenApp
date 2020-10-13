using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KinderGarden.Core;
using KinderGarden.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGardenApp
{
    public class ApplicationModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
        public IConfiguration Configuration { get; }
        public ApplicationModel(KinderGarden.Data.KindergardenDbContext context, IConfiguration configuration)
        {
            _context = context;
            this.Saved = false;
            Configuration = configuration;
        }
        [BindProperty]
        public  Kid Kid { get; set; }
        [BindProperty]
        public Parents Parent { get; set; }
        public bool Saved { get; set; }
        public SelectList kindergardens;

        public void OnGet()
        {
            kindergardens = new SelectList(_context.Kindergardens, "Id", "Name");
        }
        public IActionResult OnPost([Bind] Kid kidUpdate)
        {
            var found = false;
            kidUpdate.AplicationDate = DateTime.Now;
            kidUpdate.KindergardenId = Kid.KindergardenId;
            try
            {
                Parents parentFound = _context.Parents.Where(p => p.Email == Parent.Email).First();
                if(parentFound!=null)
                {
                    if(parentFound.kids == null)
                    {
                        parentFound.kids = new List<Kid>();
                    }
                    parentFound.kids.Add(kidUpdate);
                    found = true;
                    _context.SaveChanges();
                }
                
            } catch (Exception e)
            {
                found = false;
                //
            }
            if(found==false){
                Parent.kids = new List<Kid> { kidUpdate };
                _context.Add(Parent);
                _context.SaveChanges();
            }
            Saved = true;
            MailHelper mailHelper = new MailHelper(Configuration);
            mailHelper.SendApplicationReceived(kidUpdate.Parent.Email, kidUpdate.Parent.ImeTatko + " " + kidUpdate.Parent.ImeMajka + " " + kidUpdate.LastName);
            return Page();
        }
    }
}