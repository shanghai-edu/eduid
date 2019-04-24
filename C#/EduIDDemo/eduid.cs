using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class eduid
{
    const string NAMESPACE_DNS = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";

    public static bool is_valid(string uuid)
    {

        return Regex.IsMatch(uuid, "^[0-9a-f]{8}-?[0-9a-f]{4}-?[0-9a-f]{4}-?[0-9a-f]{4}-?[0-9a-f]{12}$");
    }

    public static string v5(string name_space, string name)
    {

        //if (!is_valid(name_space)) return null;

        // Get hexadecimal components of namespace
        string nhex = name_space.Replace("-", "").Replace("{", "").Replace("}", "");

        // Binary Value
        string nstr = "";

        Encoding asciiencoding = Encoding.UTF8;
        int len2 = 0;
        // Convert Namespace UUID to bits
        byte[] name_space_data = new byte[16];
        for (int i = 0; i < nhex.Length; i += 2)
        {
            string a = nhex[i].ToString() + nhex[i + 1].ToString();
            int value = Convert.ToInt32(a, 16);
            name_space_data[i / 2] = (byte)value;

        }
        int len = nstr.Length;
        // Calculate hash value
        byte[] name_data = asciiencoding.GetBytes(name);
        byte[] data = new byte[name_space_data.Length + name_data.Length];
        name_space_data.CopyTo(data, 0);
        name_data.CopyTo(data, name_space_data.Length);

        string hash = SHA1(data).ToLower();

        string result = hash.Substring(0, 8);
        result += "-";
        result += hash.Substring(8, 4);
        result += "-";
        // 16 bits for "time_hi_and_version",
        // four most significant bits holds version number 5
        int value2 = Convert.ToInt32(hash.Substring(12, 4), 16);
        value2 = (value2 & 0x0fff) | 0x5000;
        result += String.Format("{0:X}", value2).ToLower();
        result += "-";

        // 16 bits, 8 bits for "clk_seq_hi_res",
        // 8 bits for "clk_seq_low",
        // two most significant bits holds zero and one for variant DCE1.1
        value2 = Convert.ToInt32(hash.Substring(16, 4), 16);
        value2 = (value2 & 0x3fff) | 0x8000;
        result += String.Format("{0:X}", value2).ToLower();
        result += "-";

        result += hash.Substring(20, 12);

        return result;
    }


    public static string SHA1(byte[] data)
    {
        //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "SHA1");
        System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] result = sha1.ComputeHash(data);//得到哈希值
        string hash = BitConverter.ToString(result).Replace("-", "");
        return hash;

    }

    public static string GenerateShanghaiEduID(string IdNumber)
    {
        string ShanghaiEduDomain = "sh.edu.cn";
        string nameSpace = v5(NAMESPACE_DNS, ShanghaiEduDomain);
        //string nameSpace = "b22e8988-6d15-5bff-b3a6-8e85a8a79f37";
        return v5(nameSpace, IdNumber);
    }

}

