using KinderGarden.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarden.Data
{
    public class KindergardenDbContext:DbContext
    {
        public KindergardenDbContext(DbContextOptions<KindergardenDbContext> options) : base(options)
        {

        }

        public DbSet<Kindergarden> Kindergardens { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Kid> Kids{ get; set; }
        public DbSet<Group> Groups { get; set; }
   
    }
}

