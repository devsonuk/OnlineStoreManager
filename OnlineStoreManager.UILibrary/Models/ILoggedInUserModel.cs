using System;

namespace OnlineStoreManager.UILibrary.Models
{
    public interface ILoggedInUserModel
    {
        string AccessToken { get; set; }
        DateTime CreatedAt { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}