using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    public interface IPasswordValidatorService
    {
        bool IsValidPassword(String candidate);
    }
    public interface IEmailValidatorService
    {
        bool IsValidAddress(String candidate);
    }
    public class PasswordValidator : IPasswordValidatorService
    {
        public int MinLength { get; private set; }
        public PasswordValidator(int minLength)
        {
            this.MinLength = minLength;
        }
        public bool IsValidPassword(String candidate)
        {
            if (String.IsNullOrEmpty(candidate))
            {
                return false;
            }
            return IsLongEnough(candidate) && ContainsDiffrentCharacterTypes(candidate);
        }
        private bool IsLongEnough(String candidate)
        {
            return candidate.Length >= this.MinLength;
        }
        private bool ContainsDiffrentCharacterTypes(string candidate)
        {
            bool hasLower = false, hasUpper = false, hasNumber = false, hasSymbol = false;
            foreach (char c in candidate)
            {
                if (char.IsDigit(c)) hasNumber = true;
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if(char.IsSymbol(c)) hasSymbol = true;
            }
            return (hasLower && hasUpper && hasNumber && !hasSymbol);
        }
    }

    public class EmailValidator : IEmailValidatorService
    {
        public bool IsValidAddress(string candidate)
        {
            if (String.IsNullOrWhiteSpace(candidate))
            {
                return false;
            }

            bool hasAtSymbol = candidate.Contains("@");
            bool endsWithDomain = candidate.EndsWith(".com") || candidate.EndsWith(".hr");
            return hasAtSymbol && endsWithDomain;
        }
    }

}
