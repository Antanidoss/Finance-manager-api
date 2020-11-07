using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Infastructure.Models
{
    internal class AuthOptions
    {
		public const string ISSUER = "BookOfRecipesServer";

		public const string AUDIENCE = "BookOfRecipesClient";

		const string Key = "12456742780777";

		public const int LIFETIME = 1;

		public static SymmetricSecurityKey GetSummetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}
