using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentRestApi.Models
{
    public class Calisanlar
    {
        [Key]
        [Column(Order = 1)]
        public int CalisanID { get; set; }
        public int SirketID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Isim")]
        public string Isim { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Soyisim")]
        public string Soyisim { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Kullanici Adi")]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Sifre")]
        public string Sifre { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Adres")]
        public string Adres { get; set; }
        // [Column(TypeName = "bigint")]
        public Int64 TelNo { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Rol")]
        public string Rol { get; set; } //1 yönetici 0 çalışan
        public Sirket Sirket { get; set; }//Her çalışan bir şirkete bağlıdır.
    }
}
