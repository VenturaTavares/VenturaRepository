using SpyuserControl.Common.Resource;
using SpyuserControl.Common.Validation;
using SpyUserControl.Common.ValidationCommon;
using SpyUserControl.Domain.Contracts.Repository;
using SpyUserControl.Domain.Contracts.Services;
using SpyUserControl.Domain.Models;
using System;

namespace SpyUserControl.Bussiness.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);
            AssertionConcern.AssertArgumentEquals(user.Password, PasswordAssertionConcern.Encrypt(password), Errors.InvalidCredentials);
            return user;

        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _repository.Update(user);

        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {

            var user = Authenticate(email, password);
            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);

        }

        public User GetByEmail(string email)
        {
            var user = _repository.Get(email);
            AssertionConcern.AssertArgumentNotNull(user, Errors.InvalidEmail);

            return user;

        }

        public void Register(string name, string email, string password, string ConfirmPassword)
        {
            var hasUser = GetByEmail(email);
            if (hasUser != null)
                throw new Exception(Errors.InvalidEmail);

            var user = new User(email, name);
            user.SetPassword(password, ConfirmPassword);
            user.Validate();

            _repository.Create(user);

        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            var password = user.ResetPassword();
            user.Validate();
            _repository.Update(user);

            return password;

        }


        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
