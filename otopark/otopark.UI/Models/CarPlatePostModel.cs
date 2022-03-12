using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace otopark.UI.Models
{
    public class CarPlatePostModel
    {
         

        [Display(Name = "Plaka il kodu")]
        [RegularExpression("^[1-9]$|^[1-9][0-9]$|^(81)$", ErrorMessage = "Lütfen geçerli bir plaka giriniz.")]
        public int carPlateCityArea { get; set; }


        [Display(Name = "Plaka harf kodu")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen geçerli bir plaka giriniz.")]
        public string carPlateTextArea { get; set; }


        [Display(Name = "Plaka sayı kodu")]
        [RegularExpression("^[1-9]$|^[0-9][0-9]$|^[0-9][0-9][0-9]$|^[0-9][0-9][0-9][0-9]$|^[0-9][0-9][0-9][0-9][0-9]$|^(99999)$", ErrorMessage = "Lütfen geçerli bir plaka giriniz.")]
        public int carPlateNumberArea { get; set; }

    }
}
