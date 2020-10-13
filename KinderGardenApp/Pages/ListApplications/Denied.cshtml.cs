using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using KinderGarden.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace KinderGardenApp
{
    public class DeniedModel : PageModel
    {
        private readonly IKindergardenData kindergardenData;
        public IConfiguration Configuration { get; }
        public Kid Kid { get; set; }

        public DeniedModel(IKindergardenData kindergardenData, IConfiguration configuration)
        {
            this.kindergardenData = kindergardenData;
            Configuration = configuration;
        }

        public IActionResult OnGet(int kidId)
        {
            if (Program.loggedUser == false)
            {
                return RedirectToPage("./NotFound");
            }

            Kid = kindergardenData.GetKidById(kidId);
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int kidId)
        {
            if (Program.loggedUser == false)
            {
                return RedirectToPage("./NotFound");
            }

            Kid = kindergardenData.GetKidById(kidId);
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }

            Kid.Status = Statuses.Odbien;
            kindergardenData.Commit();
            MailHelper mailHelper = new MailHelper(Configuration);
            Parents parent = kindergardenData.GetParentById((int)Kid.ParentId);
            mailHelper.SendApplicationDenied(parent.Email, parent.ImeTatko + " " + parent.ImeMajka + " " + Kid.LastName);
            return RedirectToPage("./ListApplications");
        }

    }
}