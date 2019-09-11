// Masahiro Furukawa
// Sept 11, 2019
//
// Float 2 Byte Test in C#
// 
// SDK : Visual Studio 2019
// 
// Reference
// [1] https://www.atmarkit.co.jp/ait/articles/0307/04/news005.html



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float2Byte
{
    public class ToHexString
    {
        static void Main()
        {
            // Byte 列の取り扱い
            byte[] byteArray = {0, 1, 2, 10, 11, 12, (byte)'a', (byte)'b'};

            Console.WriteLine(BitConverter.ToString(byteArray));
            // 出力：00-01-02-0A-0B-0C-61-62

            for (int i = 0; i < byteArray.Length; i++)
            {
                Console.Write("{0:X2} ", byteArray[i]);
            }
            // 出力：00 01 02 0A 0B 0C 61 62

            Console.Write("\n");
            Console.Write("\n");


            // Float 型の取り扱い
            float[] floatArray = { 3.14159f, 0.0f };

            for (int j = 0; j < floatArray.Length; j++)
            { 
                // Float -> Byte 変換
                byte[] byteArrayFromFloat = BitConverter.GetBytes(floatArray[j]);
            
                for (int i = 0; i < byteArrayFromFloat.Length; i++)
                {
                    Console.Write("{0:X2} ", byteArrayFromFloat[i]);
                }
                Console.Write("\n");
            }
        }
    }
}
