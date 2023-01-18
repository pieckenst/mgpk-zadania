using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerLoginTemplate
{

	//    https://thomaslevesque.com/2013/05/21/an-easy-and-secure-way-to-store-a-password-using-data-protection-api/
	public static class DataProtectionExtensions
	{
		public static string Protect(
			this string clearText,
			string optionalEntropy = null,
			DataProtectionScope scope = DataProtectionScope.CurrentUser)
		{
			if (clearText == null)
				throw new ArgumentNullException("clearText");
			byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
			byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
				? null
				: Encoding.UTF8.GetBytes(optionalEntropy);
			byte[] encryptedBytes = ProtectedData.Protect(clearBytes, entropyBytes, scope);
			return Convert.ToBase64String(encryptedBytes);
		}

		public static string Unprotect(
			this string encryptedText,
			string optionalEntropy = null,
			DataProtectionScope scope = DataProtectionScope.CurrentUser)
		{
			if (encryptedText == null)
				throw new ArgumentNullException("encryptedText");
			byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
			byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
				? null
				: Encoding.UTF8.GetBytes(optionalEntropy);
			byte[] clearBytes = new byte[0];
			try
			{
				clearBytes = ProtectedData.Unprotect(encryptedBytes, entropyBytes, scope);
			}
			catch
			{
				//Do nothing - just return empty if unable to decrypt the original password
			}

			return Encoding.UTF8.GetString(clearBytes);
		}
	}
}
