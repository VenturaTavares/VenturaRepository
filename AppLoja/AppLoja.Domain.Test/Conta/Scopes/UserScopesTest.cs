using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLoja.Domain.Conta.Entidades;
using AppLoja.Domain.Conta.Scopes;

namespace AppLoja.Domain.Test.Conta.Scopes
{
    [TestClass]
    public class UserScopesTest
    {
        [TestMethod]
        [TestCategory("Users - Scopes")]
        public void RegisterUserScopeIsValid()
        {
            var user = new User("Bruno Ventura", "123456", "bruno@gmail.com");
            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("Users - Scopes")]
        public void RegisterUserScopeIsInvalidWhenUsernameIsNull()
        {
            var user = new User("", "123456", "bruno@gmail.com");
            Assert.AreEqual(false, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("Users - Scopes")]
        public void VerificationScopeIsValid()
        {
            var user = new User("Bruno Ventura", "123456", "bruno@gmail.com");
            var verificationCode = user.VerificationCode;
            Assert.AreEqual(true, user.VerificationScopeIsValid(verificationCode));
        }

        [TestMethod]
        [TestCategory("Users - Scopes")]
        public void VerificationScopeIsInvalid()
        {
            var user = new User("Bruno Ventura", "123456", "bruno@gmail.com");
            var verificationCode = "123456789";
            Assert.AreEqual(false, user.VerificationScopeIsValid(verificationCode));
        }
    }
}
