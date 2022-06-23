using System.ComponentModel.DataAnnotations;

namespace UsersAuthWebApi.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
