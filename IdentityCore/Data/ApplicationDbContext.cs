using System;
using System.Collections.Generic;
using System.Text;
using IdentityCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbOdds> TbOdds { get; set; }

        public virtual DbSet<TbStakes> TbStakes { get; set; }
        public virtual DbSet<TbStakeDetails> TbStakeDetails { get; set; }



    }
}
