using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using KinderGarden.Core;
using KinderGarden.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KinderGardenApp
{
    public class StatisticsModel : PageModel
    {
        private readonly KinderGarden.Data.KindergardenDbContext _context;
        public List<Kid> kids { get; set; }
        public int pendingCount;
        public int acceptedCount;
        public int deniedCount;
        public List<int> groupsCount = new List<int>();
        public List<int> groupsKindergarden = new List<int>();


        public StatisticsModel(KinderGarden.Data.KindergardenDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            if (Program.loggedUser == false)
            {
                Response.Redirect("/NotFound");
            }

            pendingCount = _context.Kids.Where(k => k.Status == Statuses.Se_procesira).Count();
            acceptedCount = _context.Kids.Where(k => k.Status == Statuses.Primen).Count();
            deniedCount = _context.Kids.Where(k => k.Status == Statuses.Odbien).Count();

            var res = _context.Kids.Where(k => k.GroupId == (int)GroupType.JasliMala).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);

            res = _context.Kids.Where(k => k.GroupId == (int)GroupType.JasliGolema).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);

            res = _context.Kids.Where(k => k.GroupId == (int)GroupType.GradinkaMala).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);


            res = _context.Kids.Where(k => k.GroupId == (int)GroupType.GradinkaSredna).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);

            res = _context.Kids.Where(k => k.GroupId == (int)GroupType.GradinkaGolema).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);

            res = _context.Kids.Where(k => k.GroupId == (int)GroupType.None).ToList<Kid>();
            groupsCount.Add(res != null ? res.Count() : 0);



            var res1 = _context.Kids.Where(k => k.KindergardenId == 1);
            groupsKindergarden.Add(res1 != null ? res1.Count() : 0);

            res1 = _context.Kids.Where(k => k.KindergardenId == 2);
            groupsKindergarden.Add(res1 != null ? res1.Count() : 0);

            res1 = _context.Kids.Where(k => k.KindergardenId == 3);
            groupsKindergarden.Add(res1 != null ? res1.Count() : 0);

            res1 = _context.Kids.Where(k => k.KindergardenId == null);
            groupsKindergarden.Add(res1 != null ? res1.Count() : 0);

        }
    }
}