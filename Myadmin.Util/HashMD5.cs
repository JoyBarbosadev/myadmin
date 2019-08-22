using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Myadmin.Util
{
    public static class HashMD5
    {
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string getMD5(string valor)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, valor);
            }

            return hash;
        }

        public static string getMD5IdentificadorLog()
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "SAFF@" + DateTime.Now + "#LOGERRO");
            }
            return hash;
        }

        public static String getMD5Senha(String senha)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                //hash = GetMd5Hash(md5Hash, "SAFF@" + senha + "#T2B");
                hash = GetMd5Hash(md5Hash, "MD5T2B" + senha);
            }

            return hash;
        }

        public static String getMD5Token(String senha)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "MYADMIN@TOKEN" + senha + "#JOYBARBOSA" + DateTime.Now.ToString());
            }

            return hash;
        }

        public static String getMD5Id(int id)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "MYADMIN@ID" + id.ToString() + "#JOYBARBOSA" + DateTime.Now.ToString());
            }

            return hash;
        }

        public static String getMD5Hash(string id)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "MYADMIN@HASH" + id.ToString() + "#JOYBARBOSA" + DateTime.Now.ToString());
            }

            return hash;
        }

        public static String getMD5Id(string id)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "MYADMIN@ID" + id + "" + DateTime.Now.ToString());
            }

            return hash;
        }

        public static String getMD5IdVenda(string id)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, "VENDA@ID" + id + "#JOYBARBOSA" + DateTime.Now.ToString());
            }

            return hash;
        }
    }
}
