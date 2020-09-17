using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using KinderGarden.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KinderGardenApp
{
    public class AcceptModel : PageModel
    {
        private readonly IKindergardenData kindergardenData;
        public AcceptModel(IKindergardenData kindergardenData)
        {
            this.kindergardenData = kindergardenData;
        }
        public Kid Kid { get; set; }
        public IActionResult OnGet(int kidId)
        {
            Kid = kindergardenData.GetKidById(kidId);
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }

            Kid.Status = Statuses.Primen;
            switch(Kid.Age)
            {
                case 1:
                    Kid.GroupId = (int)GroupType.JasliMala;
                    break;
                case 2:
                    Kid.GroupId = (int)GroupType.JasliGolema;
                    break;
                case 3:
                    Kid.GroupId = (int)GroupType.GradinkaMala;
                    break;
                case 4:
                    Kid.GroupId = (int)GroupType.GradinkaSredna;
                    break;
                case 5:
                    Kid.GroupId = (int)GroupType.GradinkaGolema;
                    break;
                default:
                    Kid.GroupId = (int)GroupType.None;
                    break;
            }
            kindergardenData.Commit();

            return Page();
        }
    }
}