using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }

        [StringLength(50), Display(Name = "Ad"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Adi { get; set; }

        [StringLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Soyadi { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Email { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Telefon { get; set; }

        [StringLength(50), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string KullaniciAdi { get; set; }
        [StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Sifre { get; set; }

        public bool AktifMi { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        [Display(Name = "Rolü"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public int RolId { get; set; }

        public virtual Rol? Rol { get; set; }
    }
}
