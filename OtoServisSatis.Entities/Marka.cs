using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Adı"), Required(ErrorMessage = "{0} Alan Zorunludur")]
        public string Adi { get; set; }
    }
}
