using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Domain;
using CozyCo.Domain.Models;

namespace CozyCo.Data.Context
{
    //This class will translate Models into Database tables
    public class CozyCoDbContent : DbContext
    {
        //Per Model as table - add as dbset
        public DbSet<Property> Properties { get; set; }
    }
}
