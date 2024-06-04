using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-ONCVC9CR; initial catalog=BrainWave; integrated Security=true");
		}
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<UserProject> UserProjects { get; set; }
		public DbSet<ProjectRequest> ProjectRequests { get; set; }
		public DbSet<UserResource> UserResources { get; set; }
		public DbSet<UserRequest> UserRequests { get; set; }
		public DbSet<ProjectTask> ProjectTasks { get; set; }


		//ilişkileri tanımlıyoruz
		//protected override void OnModelCreating(ModelBuilder builder)
		//{
		//    builder.Entity<ProjectRequest>()
		//        .HasOne(x => x.SenderUser)
		//        .WithMany(y => y.RequestSender)
		//        .HasForeignKey(z => z.SenderID)
		//        .OnDelete(DeleteBehavior.ClientSetNull);

		//    builder.Entity<ProjectRequest>()
		//        .HasOne(x => x.ReceiverUser)
		//        .WithMany(y => y.RequestReceiver)
		//        .HasForeignKey(z => z.ReceiverID)
		//        .OnDelete(DeleteBehavior.ClientSetNull);
		//    base.OnModelCreating(builder);
		//}
	}
}
