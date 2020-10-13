using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using KinderGarden.Data;

namespace KinderGardenApp
{
    public class LogInModel : PageModel
    {
        private readonly IKindergardenData _kindergardenData;
        public LogInModel(IKindergardenData kindergardenData)
        {
            _kindergardenData = kindergardenData;
        }
        [BindProperty]
        public User User { get; set; }
        public IActionResult OnPost([Bind] User userCheck)
        {

            Program.loggedUser = _kindergardenData.CheckLogIn(userCheck.Email, userCheck.Password);
            return RedirectToPage("/Index");
        }
    }
}