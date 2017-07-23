using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{

    public enum EncryptionType
    {
        MD5,
        SHA1,
        SHA384,
        SHA512
    }

    public class EncryptionHelper
    {
        public delegate string EncodingString(string source);
        public string Encryption(EncryptionType type,string source)
        {
            Dictionary<EncryptionType, EncodingString> dictionary = new Dictionary<EncryptionType, EncodingString>()
            {
                { EncryptionType.MD5,EncodingMD5},
                { EncryptionType.SHA1,EncodingSHA1},
                { EncryptionType.SHA384,EncodingSHA384},
                { EncryptionType.SHA512,EncodingSHA512},

            };
            return dictionary[type].Invoke(source);
        }
        /// <summary> 
        /// MD5加密字符串 
        /// </summary> 
        /// <param name="source">原字串</param> 
        /// <returns>加密後字串</returns> 
        public string EncodingMD5(string source)
        {
            MD5 md5 = MD5.Create();
            string resultMd5 = Convert.ToBase64String(md5.ComputeHash(Encoding.Default.GetBytes(source)));
            return resultMd5; ;
        }


        /// <summary>
        /// SHA1加密字串
        /// </summary>
        /// <param name="source">原字串</param>
        /// <returns>加密後字串</returns>
        public string EncodingSHA1(string source)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string resultSha1 = Convert.ToBase64String(sha1.ComputeHash(Encoding.Default.GetBytes(source)));
            return resultSha1;
        }
        /// <summary>
        /// SHA384加密字串
        /// </summary>
        /// <param name="source">原字串</param>
        /// <returns>加密後字串</returns>
        public string EncodingSHA384(string source)
        {
            SHA384 sha384 = new SHA384CryptoServiceProvider();//建立一個SHA384
            string resultSha384 = Convert.ToBase64String(sha384.ComputeHash(Encoding.Default.GetBytes(source)));//把加密後的字串從Byte[]轉為字串
            return resultSha384;
        }
        /// <summary>
        /// SHA512加密字串
        /// </summary>
        /// <param name="source">原字串</param>
        /// <returns>加密後字串</returns>
        public string EncodingSHA512(string source)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string resultSha512 = Convert.ToBase64String(sha512.ComputeHash(Encoding.Default.GetBytes(source)));
            return resultSha512;
        }
    }
}
