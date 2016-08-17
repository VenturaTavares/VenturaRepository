using SpyuserControl.Common.Resource;
using SpyuserControl.Common.Validation;
using SpyUserControl.Common.ValidationCommon;
using System;

namespace SpyUserControl.Domain.Models
{
    public class User
    {

        #region Ctor
        public User(string email, string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
        #endregion

        #region Methods
        public void SetPassword(string password, string confirm)
        {

            AssertionConcern.AssertArgumentEquals(password, confirm, Errors.InvalidPasswordConfirmation);
            AssertionConcern.AssertArgumentNotEmpty(password, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentNotEmpty(confirm, "confirmação da senha deve ser preenchida");
            AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidUserPassword);
            this.Password = PasswordAssertionConcern.Encrypt(password);
        }

        public string ResetPassword()
        {

            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = password;
            return password;

        }

        public void ChangeName(string name)
        {

            this.Name = name;
        }

        public void Validate()
        {


            AssertionConcern.AssertArgumentLength(this.Name, 3, 250, Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Password);
        }
        #endregion

    }
}
