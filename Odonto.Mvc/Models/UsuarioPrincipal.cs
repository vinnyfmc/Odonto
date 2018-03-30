using Odonto.Domain.Entities;
using System;
using System.Security.Principal;

namespace Odonto.Mvc.Models
{
    public class UsuarioPrincipal : IPrincipal
    {
        public Funcionario Funcionario { get; set; }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public UsuarioPrincipal(IIdentity identity)
        {
            Identity = identity;

        }


        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

    }
}