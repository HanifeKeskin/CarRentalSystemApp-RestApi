using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentRestApi.Models
{
    public class Sirket
    {
        [Key]
        [Column(Order = 1)]
        public int SirketID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Ad")]
        public string Ad { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Sehir")]
        public string Sehir { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakteri geçemez"), Display(Name = "Adres")]
        public string Adres { get; set; }
        public int AracSayisi { get; set; }
        public int Puan { get; set; }
        public ICollection<Calisanlar> Calisanlar { get; set; }//Her şirket birden fazla çalışan içerebilir.
        public ICollection<Araclar> Araclar { get; set; }
    }
}
