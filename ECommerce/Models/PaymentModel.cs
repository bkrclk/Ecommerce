using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class PaymentModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please input valid Name.")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karekter giriniz."), MaxLength(20, ErrorMessage = "Maximum 3 Karekter giriniz.")]
        [RegularExpression(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$",
        ErrorMessage = "özel karakter girilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input valid Surname.")]
        [MinLength(3,ErrorMessage = "Minimum 3 Karekter giriniz."), MaxLength(20, ErrorMessage = "Maximum 3 Karekter giriniz.")]
        [RegularExpression(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$",
        ErrorMessage = "özel karakter girilemez.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please input valid Email.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
        ErrorMessage = "Not a valid email")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0]{1}[5]{1}[3-5]{1}[0-9]{1})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", 
        ErrorMessage = "Telefon 0553-XXX-XXXX && 553XXXXXXX şeklinde olmalıdır.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please input valid Adress.")]
        [MinLength(10, ErrorMessage = "Minimum 10 Karekter giriniz."), MaxLength(100, ErrorMessage = "Maximum 100 Karekter giriniz.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Please input valid CardName.")]
        [MinLength(5, ErrorMessage = "Minimum 5 Karekter giriniz."), MaxLength(20, ErrorMessage = "Maximum 3 Karekter giriniz.")]
        [RegularExpression(@"^[a-zA-ZÖöıİşçÇğĞÜüŞ''-'\s]+$",
        ErrorMessage = "Lütfen Kart üzerindeki ismi Giriniz.")]
        public string CardName { get; set; }

        [Required(ErrorMessage = "Please input valid CardNumber.")]
        [MinLength(16, ErrorMessage = "Card Number of 16 digit input.")]
        [RegularExpression(@"^\d{1,16}$", ErrorMessage = "Please input enter valid card number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please input valid CardExpirationDate.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "input invalid.")]
        public string CardExpirationDate { get; set; }


        [Required(ErrorMessage = "Please inpıt valid CardCVV.")]
        [MinLength(3, ErrorMessage = "input invalid.")]
        public string CardCVV { get; set; }

    }
}
