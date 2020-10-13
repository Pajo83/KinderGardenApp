﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KinderGardenApp
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            Program.loggedUser = false;
            Response.Redirect("./");
        }
    }
}