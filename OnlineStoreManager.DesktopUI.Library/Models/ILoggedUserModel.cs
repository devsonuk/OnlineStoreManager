using System;

namespace OnlineStoreManager.DesktopUI.Library.Models
{
    public interface ILoggedUserModel
    {
        string AccessToken { get; set; }
        DateTime CreatedAt { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        DateTime? UpdatedAt { get; set; }

        void Reset();
    }
}