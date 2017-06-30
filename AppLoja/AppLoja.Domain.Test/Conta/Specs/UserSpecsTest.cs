using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AppLoja.Domain.Conta.Entidades;
using AppLoja.Domain.Conta.Specs;

namespace AppLoja.Domain.Test.Conta.Specs

{
    [TestClass]
    public class UserSpecsTest
    {
        private List<User> _users;


        public UserSpecsTest()
        {

            //MOCK
            _users = new List<User>();

            _users.Add(new User("BrunoVentura", "1234567", "bruno@gmail.com"));
            _users.Add(new User("Ironman", "1234567", "Ironman@gmail.com"));
            _users.Add(new User("Batman", "1234567", "Batman@gmail.com"));
            _users.Add(new User("Spiderman", "1234567", "Spiderman@gmail.com"));
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameShouldReturnValue()
        {
            var result = _users.
                AsQueryable().
                Where(UserSpecs.GetByUserName("BrunoVentura")).
                FirstOrDefault();

            Assert.AreNotEqual(null, result);

        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameNOTShouldReturnValue()
        {
            var result = _users.
                AsQueryable().
                Where(UserSpecs.GetByUserName("BrunoVentura1234")).
                FirstOrDefault();

            Assert.AreEqual(null, result);

        }
    }
}
