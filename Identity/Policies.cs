using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public static class Policies
    {
        public static AuthorizationPolicy RolePolicy(string role)
        {
            return new AuthorizationPolicyBuilder()
                .RequireRole(role)
                .Build();
        }
    }
}
