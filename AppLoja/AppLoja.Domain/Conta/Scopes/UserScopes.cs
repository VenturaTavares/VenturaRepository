using AppLoja.Domain.Conta.Entidades;
using DomainNotificationHelper.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Domain.Conta.Scopes
{
    public static class UserScopes
    {

        public static bool RegisterScopeIsValid(this User user)
        {

            return AssertionConcern.IsSatisfiedBy
                (
                AssertionConcern.AssertLength(user.UserName, 6, 20, "O usuário deve conter um nome entre 6 e 20 caracteres!"),
                AssertionConcern.AssertLength(user.Password, 6, 20, "A senha deve conter um nome entre 6 e 20 caracteres!"),
                AssertionConcern.AssertEmailIsValid(user.Email,"Email inválido")

                );
        }

        public static bool VerificationScopeIsValid(this User user, string verificationCode)
        {

            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado"),
                AssertionConcern.AssertTrue(user.Verified == false, "Usuário já verificado"),
                AssertionConcern.AssertAreEquals(user.VerificationCode, verificationCode, "O código de verificação está incorreto!"));
        }

        public static bool ActivationScopeIsValid(this User user, string activationCode)
        {
            return AssertionConcern.IsSatisfiedBy(
                   AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado"),
                   AssertionConcern.AssertTrue(user.Verified == true, "Usuário não verificado"),
                   AssertionConcern.AssertTrue(user.Active == false, "Usuário já verificado"),
                   AssertionConcern.AssertAreEquals(user.ActivationCode, activationCode, "O código de ativação está incorreto!")
                );
        }

        public static bool RequestLoginScopeIsValid(this User user, string userName)
        {

            return AssertionConcern.IsSatisfiedBy(
                          AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado"),
                          AssertionConcern.AssertTrue(user.Verified == true, "Usuário não verificado"),
                          AssertionConcern.AssertTrue(user.Active == true, "Usuário não ativado"),
                          AssertionConcern.AssertAreEquals(user.UserName.ToLower(), userName.ToLower(), "O nome do usuário está incorreto!"),
                          AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(-5), DateTime.Now).ToString(), (-1).ToString(), "Um SMS foi enviado , favor aguardar 5 minutos para uma nova requisição")
                );
        }

        public static bool LoginScopeIsValid(this User user, string authorizationCode, string password)
        {

            return AssertionConcern.IsSatisfiedBy(
                          AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado"),
                          AssertionConcern.AssertTrue(user.Verified == true, "Email não verificado"),
                          AssertionConcern.AssertTrue(user.Active == true, "Cadastro não ativado"),
                          AssertionConcern.AssertAreEquals(user.AuthorizationCode.ToUpper(), authorizationCode.ToUpper(), "Código de autentiação inválido"),
                          AssertionConcern.AssertAreEquals(user.Password.ToUpper(), password.ToUpper(), "Usuário ou senha inválido"),
                          AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(5), DateTime.Now).ToString(), (-1).ToString(), "Um SMS foi enviado , favor aguardar 5 minutos para uma nova requisição")
                );
        }

    }
}
