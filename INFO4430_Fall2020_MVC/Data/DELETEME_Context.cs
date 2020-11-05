using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INFO4430_Fall2020_MVC.Models;

namespace INFO4430_Fall2020_MVC.Data
{
    public class DELETEME_Context : DbContext
    {
        public DELETEME_Context (DbContextOptions<DELETEME_Context> options)
            : base(options)
        {
        }

        public DbSet<INFO4430_Fall2020_MVC.Models.Course> Course { get; set; }

        public DbSet<INFO4430_Fall2020_MVC.Models.Instructor> Instructor { get; set; }
    }
}
