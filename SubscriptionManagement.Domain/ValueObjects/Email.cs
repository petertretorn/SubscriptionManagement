using System;
using System.Text.RegularExpressions;

namespace SubscriptionManagement.Domain.ValueObjects
{
    public class Email
    {
        public Email(string email)
        {
            if ( !IsValid(email) ) {
                throw new ArgumentException("Invalid Email");
            }

            this.EmailAddress = email;
        }

        public Email Change(String email)
        {
            return new Email(email);
        }

        public string EmailAddress { get; private set; }

        private bool IsValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }
    }
}