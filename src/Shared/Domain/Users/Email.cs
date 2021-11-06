using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class Email
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        public string EmailAddress { get; }

        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
