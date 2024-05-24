using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Musteri : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Araç"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public int AracId { get; set; }
        [StringLength(50), Display(Name = "Adı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Adi { get; set; }
        [StringLength(50), Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Soyadi { get; set; }
        [StringLength(11), Display(Name = "TC Kimlik No")]
        public string? TcNo { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Email { get; set; }
        [StringLength(500)]
        public string? Adres { get; set; }
        [StringLength(20), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Telefon { get; set; }
        public string? Notlar { get; set; }
        [Display(Name = "Araç")]
        public virtual Arac? Arac { get; set; }
    }
}
