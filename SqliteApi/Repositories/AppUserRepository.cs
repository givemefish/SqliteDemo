// =================================================================
// File: AppUserRepository.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/16 上午 08:52
// Update Date: 2018/03/16 上午 11:54
// =================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqliteApi.Data;
using SqliteApi.ViewModels;

namespace SqliteApi.Repositories
{
    public class AppUserRepository: IAppUserRepository
    {
        private readonly AppDbContext context;

        public AppUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<AppUser> GetAll()
        {
            return context.AppUsers.AsNoTracking().ToList();
        }

        public AppUser Get(int id)
        {
            return context.AppUsers.AsNoTracking().SingleOrDefault(o => o.Id == id);
        }

        public void Add(AppUser appUser)
        {
            context.AppUsers.Add(appUser);
            context.SaveChanges();
        }

        public void Update(int id, AppUser appUser)
        {
            context.AppUsers.Update(appUser);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appUser = context.AppUsers.SingleOrDefault(o => o.Id == id);
            if (appUser != null)
            {
                context.AppUsers.Remove(appUser);
                context.SaveChanges();
            }
        }
    }
}