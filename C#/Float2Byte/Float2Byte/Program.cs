// Masahiro Furukawa
// Sept 11, 2019
//
// Float 2 Byte Test in C#
// 
// SDK : Visual Studio 2019
// 
// Reference
// [1] https://www.atmarkit.co.jp/ait/articles/0307/04/news005.html
// [2] https://dobon.net/vb/dotnet/internet/udpclient.html
//
// Result
// C:\Users\MasahiroFurukawa\Documents\GitHub\Utility\C#\Float2Byte\Float2Byte\bin\Debug>Float2Byte.exe
// 00-01-02-0A-0B-0C-61-62
// 00 01 02 0A 0B 0C 61 62
// 
// 3.14159\t ->  BitConverter.GetBytes(floatArray[j]) ->  D0 0F 49 40  -> BitConverter.ToSingle ->  3.14159
// 0 ->  BitConverter.GetBytes(floatArray[j]) ->  00 00 00 00  -> BitConverter.ToSingle ->  0
//



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
            // Float to Byte Array
            //
            // [1] https://www.atmarkit.co.jp/ait/articles/0307/04/news005.html

            // Byte 列の取り扱い
            byte[] byteArray = {0, 1, 2, 10, 11, 12, (byte)'a', (byte)'b'};

            Console.WriteLine(BitConverter.ToString(byteArray));
            // Output：00-01-02-0A-0B-0C-61-62

            for (int i = 0; i < byteArray.Length; i++)
            {
                Console.Write("{0:X2} ", byteArray[i]);
            }
            // Output：00 01 02 0A 0B 0C 61 62

            Console.WriteLine();
            Console.WriteLine();


            // Float 型の取り扱い
            float[] floatArray = { 3.14159f, 0.0f };

            for (int j = 0; j < floatArray.Length; j++)
            {
                Console.Write(floatArray[j]);

                // Float -> Byte 変換
                byte[] byteArrayFromFloat = BitConverter.GetBytes(floatArray[j]);

                Console.Write(" ->  BitConverter.GetBytes(floatArray[j]) ->  ");

                for (int i = 0; i < byteArrayFromFloat.Length; i++)
                {
                    Console.Write("{0:X2} ", byteArrayFromFloat[i]);
                }
                Console.Write(" -> BitConverter.ToSingle ->  ");

                float f = BitConverter.ToSingle(byteArrayFromFloat, 0);
                Console.WriteLine(f);
            }


            // UDP Data Send
            // 
            // [2] https://dobon.net/vb/dotnet/internet/udpclient.html


            //データを送信するリモートホストとポート番号
            string remoteHost = "127.0.0.1";
            int remotePort = 2002;

            //UdpClientオブジェクトを作成する
            System.Net.Sockets.UdpClient udp =
                new System.Net.Sockets.UdpClient();

            //送信するデータを作成する
            byte[] sendBytes = BitConverter.GetBytes(3.14159f);


            //リモートホストを指定してデータを送信する
            udp.Send(sendBytes, sendBytes.Length, remoteHost, remotePort);

            //または、
            //udp = new UdpClient(remoteHost, remotePort);
            //として、
            //udp.Send(sendBytes, sendBytes.Length);

            
            //UdpClientを閉じる
            udp.Close();


        }
    }
}
