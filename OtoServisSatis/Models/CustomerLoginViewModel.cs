using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Models
{
    public class CustomerLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Sifre { get; set; }
    }
}
