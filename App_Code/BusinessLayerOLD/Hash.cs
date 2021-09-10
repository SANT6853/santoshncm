using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for Hash
/// </summary>
public class Hash
{
    public static string GetSHA512(string phrase)
    { 
        UTF8Encoding encoder = new UTF8Encoding();
        SHA512Managed sha512hasher = new SHA512Managed();
        byte[] hashBytes = sha512hasher.ComputeHash(encoder.GetBytes(phrase));
        return BytesToHex(hashBytes);
    }

    public static string BytesToHex(byte[] bytes)
    {
        StringBuilder hexString = new StringBuilder(bytes.Length);
        for (int i = 0; i < bytes.Length; i++)
        {
            hexString.Append(bytes[i].ToString("X2"));
        }
        return hexString.ToString();
    }
}
