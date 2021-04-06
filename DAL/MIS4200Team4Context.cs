using centricTeam4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

    namespace centricTeam4.DAL
    {
        public class MIS4200Team4Context : DbContext
        {
        //internal object recognition;

        public MIS4200Team4Context() : base("name=DefaultConnection")
            {

            }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // note: this is all one line!
        }
        public DbSet<Profile> profile { get; set; }
        public DbSet<employeeRecognition> EmployeeRecognitions { get; set; }
        //public DbSet<recognition> Recognition { get; set; }

        

    }
    }
  