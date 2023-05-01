using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.DTO
{
    public class MessageModel
    {


        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange en giltigt e-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;



    }
}