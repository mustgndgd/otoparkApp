using System.ComponentModel.DataAnnotations;

namespace otopark.UI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Lütfen kullanıcı isim alanını boş bırakmayınız!")]     
        public string userName { get; set; }
 
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre alanını boş bırakmayınız!")]     
        public string Password { get; set; }

    }
}
