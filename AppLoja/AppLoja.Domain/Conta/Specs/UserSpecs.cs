using AppLoja.Domain.Conta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Domain.Conta.Specs
{
    public static  class UserSpecs
    {

        public static Expression<Func<User,bool>> GetByUserName(string username) {

            return x => x.UserName == username;
        }



        public static Expression<Func<User, bool>> GetByAuthorizationCode(string authorizationCode)
        {
            return x => x.AuthorizationCode == authorizationCode;
        }
    }
}
