using centricTeam4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

    namespace centricTeam4.DAL
    {
        public class MIS4200Team4Context : DbContext
        {
            public MIS4200Team4Context() : base("name=DefaultConnection")
            {

            }
            public DbSet<Profile> profile { get; set; }


        }
    }
  