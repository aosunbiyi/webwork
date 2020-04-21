using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEBWORK.WEB2.Data;

namespace WEBWORK.WEB2.Pages
{
    public class IndexModel : PageModel
    {
        public List<Student> Students { get; set; }
        private ApplicationContext _db { get; set; }
        public IndexModel(ApplicationContext db)
        {
            this._db =  db;
        }
        public void OnGet()
        {
            this.Students = this._db.Students.ToList();
        }


    }
}
