using AppLoja.Domain.Conta.Enums;
using AppLoja.Domain.Conta.Scopes;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AppLoja.Domain.Conta.Entidades
{
    public class User
    {
        public User(string username, string password,string email)
        {
            Id = new Guid();
            UserName = username;
            Password = password;
            Email = email;
            Verified = false;
            Active = false;
            LastLoginDate = DateTime.Now;
            Role = ERole.User;
            VerificationCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            ActivationCode = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            AuthorizationCode = string.Empty;
            LastAuthorizationCodeRequest = DateTime.Now.AddMinutes(5);
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public bool Verified { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public ERole Role { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime LastAuthorizationCodeRequest { get; private set; }

        public void Register()
        {
            this.RegisterScopeIsValid();
            Password = EncryptPassword(Password);
        }

        public void Verify(string verificationCode)
        {
            this.VerificationScopeIsValid(verificationCode);
            Verified = (verificationCode == VerificationCode);
        }

        public void Activate(string activationCode)
        {
            this.ActivationScopeIsValid(activationCode);
            Active =(activationCode == ActivationCode);         
        }

        public void RequestLogin(string username)
        {
            this.RequestLoginScopeIsValid(username);
            AuthorizationCode = GenereateAurotizationCode();
            LastAuthorizationCodeRequest = DateTime.Now;
        }

        public void Authenticate(string autorizationCode, string password)
        {
            this.LoginScopeIsValid(autorizationCode, password);
            LastLoginDate = DateTime.Now;
        }

        public string GenereateAurotizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

        }

        private string EncryptPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();

        }
    }
}
