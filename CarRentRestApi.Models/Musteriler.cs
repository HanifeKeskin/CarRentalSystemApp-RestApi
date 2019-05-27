using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentRestApi.Models
{
    public class Musteriler
    {
        [Key]
        [Column(Order = 1)]
        public int MusteriID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Isim")]
        public string Isim { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Soyisim")]
        public string Soyisim { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Kullanici Adi")]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Sifre")]
        public string Sifre { get; set; }
        public int EhliyetYasi { get; set; }
        public int SurucuYasi { get; set; }
        //[Column(TypeName = "bigint")]
        public Int64 TelNo { get; set; }
        public ICollection<KiralikBilgi> KiralikBilgi { get; set; }
    }
}
