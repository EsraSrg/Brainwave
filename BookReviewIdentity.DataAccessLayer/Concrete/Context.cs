using BookReviewIdentity.EntityLayer.Concrete;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewIdentity.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-ONCVC9CR;initial catalog=Brainwave;integrated Security=true");
        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserProjectProcess> userProjectProcesses { get; set; }
    }
}
