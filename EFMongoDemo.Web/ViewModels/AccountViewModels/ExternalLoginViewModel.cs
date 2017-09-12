using System.ComponentModel.DataAnnotations;

namespace EFMongoDemo.Web.ViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
