using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Infastructure.Models
{
    internal class AuthOptions
    {
		public const string ISSUER = "FinanceManagerServer";

		public const string AUDIENCE = "FinanceManagerClient";

		const string Key = "124567secret80ar";

		public const int LIFETIME = 1;

		public static SymmetricSecurityKey GetSummetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}
