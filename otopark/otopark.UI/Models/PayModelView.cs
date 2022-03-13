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
        public string LoginTime { get; set; }
        
        [Display(Name = "Çıkış zamanı")]
        public string ExitTime { get; set; }
        
        [Display(Name = "Toplam süre")]
        public string Duration { get; set; }
        
        [Display(Name = "Ücret")]
        public decimal Price { get; set; }

    }
}
