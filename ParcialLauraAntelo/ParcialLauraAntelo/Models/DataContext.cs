using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ParcialLauraAntelo.Models
{
    public class DataContext: DbContext
    {
        public DataContext():base("DefaultConnection")
        {       

        }

        public System.Data.Entity.DbSet<ParcialLauraAntelo.Models.AnteloD> AnteloDs { get; set; }
    }
}