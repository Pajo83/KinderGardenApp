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
    public class DeleteModel : PageModel
    {
        private readonly IKindergardenData kindergardenData;

        public Kid Kid { get; set; }

        public DeleteModel(IKindergardenData kindergardenData)
        {
            this.kindergardenData = kindergardenData;
        }

        public IActionResult OnGet(int kidId)
        {
            Kid = kindergardenData.GetKidById(kidId);
            if (Kid == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int kidId)
        {
            var temp = kindergardenData.DeleteKid(kidId);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }

            kindergardenData.Commit();
            TempData["TempMessage"] = "Детето е избришано од евиденција";
            return RedirectToPage("./ListApplications");
        }
        
    }
}