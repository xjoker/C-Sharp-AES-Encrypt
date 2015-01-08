using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入要加密的文字：");
            string text = Console.ReadLine();
            Console.WriteLine("输入密码：");
            string password=Console.ReadLine();
            AESEncrypt aes = new AESEncrypt();
            Console.WriteLine("加密后...");
            string Encrypt = aes.EncryptStringToAES(text, password);
            Console.WriteLine(Encrypt);
            Console.WriteLine();
            Console.WriteLine("解密后...");
            Console.WriteLine(aes.DecryptAESToString(Encrypt, password));
            Console.ReadKey();

        }
    }
}
