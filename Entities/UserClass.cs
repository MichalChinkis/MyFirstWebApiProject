using System.ComponentModel.DataAnnotations;

namespace entities
{
    public class UserClass
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.StringLength(8, ErrorMessage = "First Name length can't be over 10.'")]

        public string FirstName { get; set; }
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Password length can't be less than 6.'")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(8, ErrorMessage = "Last Name length can't be less than 8.'")]

        public string LastName { get; set; }
       
        public string Email { get; set; }
        public int PhoneNumber { get; set; }


    }
}
