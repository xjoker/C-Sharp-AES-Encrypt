using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace Encrypt
{
    class AESEncrypt
    {

        //生成密钥
        static Aes CreateAES(string key)
        {
            //MD5的算法接口
            MD5 md5 = new MD5CryptoServiceProvider();

            //AES的算法接口
            Aes aes = new AesCryptoServiceProvider();

            //这里将传入的密钥通过MD5的ComputeHash方法计算数据的哈希值
            //让后将哈希值作为aes加密的密钥
            //MD5的编码长度为128位
            aes.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));

            //设置对称算法的初始化向量
            //IV 属性的大小必须将BlockSize除以8
            aes.IV = new byte[aes.BlockSize/8];

            return aes;
        }


        //加密
        public string EncryptStringToAES(string text,string password)
        {
            //将传入的待加密文本转换为byte并存入数组
            byte[] byteText = Encoding.Unicode.GetBytes(text);

            //创建个内存流
            MemoryStream ms = new MemoryStream();

            Aes aes = CreateAES(password);
            
            //创建加密流
            //这里的aes.CreateEncryptor()为加密方法
            //解密方法为aes.CreateDecryptor()
            //基本上加密和解密的区别就在这里
            CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

            //写入到加密流(其实是写入到了ms 内存流中)
            cryptoStream.Write(byteText, 0, byteText.Length);

            //清空加密流
            cryptoStream.FlushFinalBlock();

            //返回加密为Base64的string
            return Convert.ToBase64String(ms.ToArray());
        }

        //解密
        public string DecryptAESToString(string text,string password)
        {
            byte[] byteText = Convert.FromBase64String(text);

            MemoryStream ms = new MemoryStream();

            Aes aes = CreateAES(password);


            //解密过程中，如果密钥错误会导致程序的崩溃
            //这里加入try语句，当密码错误的时候会返回信息而不会崩溃
            try
            {
                CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);

                cryptoStream.Write(byteText, 0, byteText.Length);

                cryptoStream.FlushFinalBlock();
            }
            catch 
            {

                return "密码错误";
            }

            return Encoding.Unicode.GetString(ms.ToArray());
        }

    }
}
