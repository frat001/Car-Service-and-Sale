using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Arac : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public int MarkaId { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Renk { get; set; }

        [Display(Name = "Fiyat"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public decimal Fiyati { get; set; }

        [StringLength(50), Display(Name = "Model"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Modeli { get; set; }

        [Display(Name = "Kasa Tipi"), StringLength(50), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string KasaTipi { get; set; }

        [Display(Name = "Model Yılı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public int ModelYili { get; set; }

        [Display(Name = "Satışta Mı")]
        public bool SatistaMi { get; set; }
        
        [Display(Name = "Anasayfa")]
        public bool Anasayfa { get; set; }

        [Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Notlar { get; set; }

        [StringLength(100)]
        public string? Resim1 { get; set; }

        [StringLength(100)]
        public string? Resim2 { get; set; }

        [StringLength(100)]
        public string? Resim3 { get; set; }

        public virtual Marka? Marka { get; set; } //Araç sınıfı ile Marka sınıfı arasında bağlantı
    }
}
