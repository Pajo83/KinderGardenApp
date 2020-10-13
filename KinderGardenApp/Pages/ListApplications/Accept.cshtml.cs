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
    public class AcceptModel : PageModel
    {
        private readonly IKindergardenData kindergardenData;
        public IConfiguration Configuration { get; }
        public AcceptModel(IKindergardenData kindergardenData, IConfiguration configuration)
        {
            this.kindergardenData = kindergardenData;
            Configuration = configuration;
        }
        public Kid kid { get; set; }
        public IActionResult OnGet(int kidId)
        {
            if(Program.loggedUser == false)
            {
                return RedirectToPage("./NotFound");
            }




            kid = kindergardenData.GetKidById(kidId);
            if (kid == null)
            {
                return RedirectToPage("./NotFound");
            }

            kid.Status = Statuses.Primen;
            switch(kid.Age)
            {
                case 1:
                    kid.GroupId = (int)GroupType.JasliMala;
                    break;
                case 2:
                    kid.GroupId = (int)GroupType.JasliGolema;
                    break;
                case 3:
                    kid.GroupId = (int)GroupType.GradinkaMala;
                    break;
                case 4:
                    kid.GroupId = (int)GroupType.GradinkaSredna;
                    break;
                case 5:
                    kid.GroupId = (int)GroupType.GradinkaGolema;
                    break;
                default:
                    kid.GroupId = (int)GroupType.None;
                    break;
            }
            kindergardenData.Commit();

            MailHelper mailHelper = new MailHelper(Configuration);

            Parents parent = kindergardenData.GetParentById((int)kid.ParentId);
            mailHelper.SendApplicationApproved(parent.Email, parent.ImeTatko + " " + parent.ImeMajka + " " + kid.LastName);

            return Page();
        }
    }
}