using System;
using System.ComponentModel.DataAnnotations;

namespace otopark.UI.Models
{
    public class PayModelView
    {
        public int vehiclheId { get; set; }

        [Display(Name = "Plaka")]
        public string Plate { get; set; }
        
        [Display(Name = "Giriş zamanı")]
        public DateTime LoginTime { get; set; }
        
        [Display(Name = "Çıkış zamanı")]
        public DateTime ExitTime { get; set; }
        
        [Display(Name = "Toplam süre")]
        public string Duration { get; set; }
        
        [Display(Name = "Ücret")]
        public double Price { get; set; }

    }
}
