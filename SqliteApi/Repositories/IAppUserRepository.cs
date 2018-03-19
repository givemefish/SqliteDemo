// =================================================================
// File: IAppUserRepository.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/16 上午 08:52
// Update Date: 2018/03/16 上午 11:03
// =================================================================
using System.Collections.Generic;
using SqliteApi.ViewModels;

namespace SqliteApi.Repositories
{
    public interface IAppUserRepository
    {
        IEnumerable<AppUser> GetAll();

        AppUser Get(int id);

        void Add(AppUser appUser);

        void Update(int id, AppUser appUser);

        void Delete(int id);
    }
}