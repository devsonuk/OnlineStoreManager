using System;

namespace OnlineStoreManager.DesktopUI.Library.Models
{
    public class LoggedUserModel : ILoggedUserModel
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Clear()
        {
            Id = 0;
            AccessToken = null;
            FirstName = null;
            LastName = null;
            Email = null;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = null;
        }
    }
}
