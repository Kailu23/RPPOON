using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    public class UserEntry
    {
        public String Email { get; set; }
        public String Password { get; set; }
        private UserEntry() { }
        public static UserEntry ReadUserFromConsole()
        {
            UserEntry entry = new UserEntry();
            Console.WriteLine("Enter email: ");
            entry.Email = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            entry.Password = Console.ReadLine();
            return entry;
        }
    }
    public interface IRegistrationValidator
    {
        bool IsUserEntryValid(UserEntry entry);
    }

    public class RegistrationValidator : IRegistrationValidator
    {
        private IPasswordValidatorService passwordValidator;
        private IEmailValidatorService emailValidator;
        public RegistrationValidator(IPasswordValidatorService passwordValidator, IEmailValidatorService emailValidator)
        {
            this.passwordValidator = passwordValidator;
            this.emailValidator = emailValidator;
        }
        public bool IsUserEntryValid(UserEntry entry)
        {
            return passwordValidator.IsValidPassword(entry.Password) && emailValidator.IsValidAddress(entry.Email);
        }
    }
}
