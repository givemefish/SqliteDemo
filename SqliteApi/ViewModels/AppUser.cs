// =================================================================
// File: AppUser.cs
// Editor: 陳佳駿 chiachunchen (Yuanta)
// Create Date: 2018/03/16 上午 08:52
// Update Date: 2018/03/16 上午 11:03
// =================================================================
using System.ComponentModel.DataAnnotations;

namespace SqliteApi.ViewModels
{
    public class AppUser
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}