using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WEBWORK.DATA.Data
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationContext context)
         {
            context.Database.Migrate();

            context.SaveChanges();
        }
    }
}
