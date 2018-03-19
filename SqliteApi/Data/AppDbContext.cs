// =================================================================
// File: AppDbContext.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/15 下午 05:14
// Update Date: 2018/03/16 上午 11:04
// =================================================================
using Microsoft.EntityFrameworkCore;
using SqliteApi.ViewModels;

namespace SqliteApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){
            
        }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}