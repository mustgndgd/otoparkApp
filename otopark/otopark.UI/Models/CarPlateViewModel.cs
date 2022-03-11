using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace otopark.UI.Models
{
    public class CarPlateViewModel
    {

        [Display(Name="Plaka")]
        [Required(ErrorMessage = "Lütfen plaka alanını boş bırakmayınız!")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen geçerli bir plaka giriniz.")]   
        public string carPlate  { get; set; }

    }
}
