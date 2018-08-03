using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class NuevoContexto : DbContext
    {
        public NuevoContexto()
            : base("name=NuevoContexto")
        {

        }

        public virtual DbSet<Alumno> Alumni { get; set; }
    }
}