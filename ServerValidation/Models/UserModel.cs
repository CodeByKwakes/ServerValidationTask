using ServerValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerValidation.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select your title")]
        public Title Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(15, ErrorMessage = "First Name length Should be less than 50")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name length Should be less than 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter the name of the City you live")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]       
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "The Mobile must contains 11 characters", MinimumLength = 11)]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "PhoneNumber should contain only numbers")]
        public string Telephone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[BirthDate(ErrorMessage = "Your Date of Birth must be after today's date")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please choose if you are either Male or Female??")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{8,}", ErrorMessage = "Your password must be at least 8 characters long and contain at least 1 letter and 1 number")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "I Want To Join")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool Agree { get; set; }
    }

    public enum Title
    {
        Mr,
        Mrs,
        Miss,
        Ms,
        Dr
    }

    //public class BirthDateAttribute : ValidationAttribute
    //{
    //    public BirthDateAttribute()
    //    {
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        var dt = (DateTime)value;
    //        if (dt >= DateTime.Now)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //}


    public class Users
    {
        public List<UserModel> userList = new List<UserModel>();

        // Create User Method
        public void CreateUser(UserModel userModel)
        {
            userList.Add(userModel);
        }
    }
}