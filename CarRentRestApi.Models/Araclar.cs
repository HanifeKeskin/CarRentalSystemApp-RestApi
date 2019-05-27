using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentRestApi.Models
{
    public class Araclar
    {
        [Key]
        [Column(Order = 1)]
        public int AracID { get; set; }
        public int SirketID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Marka")]
        public string Marka { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Model")]
        public string Model { get; set; }
        public int EhliyetYasi { get; set; }
        public int MinYasSiniri { get; set; }
        public float GunukKm { get; set; }
        public float AnlikKm { get; set; }
        public byte Airbag { get; set; }
        public int BagajHacmi { get; set; }
        public int KoltukSayisi { get; set; }
        //[Column(TypeName = "money")]
        public Decimal GunlukKiralikFiyati { get; set; }
        //[Column(TypeName = "bit")]
        public Boolean Durum { get; set; }

        public Sirket Sirket { get; set; }

        public KiralikBilgi KiralikBilgi { get; set; } //Her aracın bir kiralık bilgi durumu vardır.
    }
}
