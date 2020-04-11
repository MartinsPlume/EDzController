using System.ComponentModel.DataAnnotations;

namespace EDzController.Controllers.V1.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}