using System;

namespace MyProduct
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = UserData.Load();

            Console.WriteLine("Hello, World!");

            var v = Util.HexDisp16(123);
            Console.WriteLine(v);
            data.Names = new string[]
            {
                "aa","bb","cc"
            };

            data.IsSaving = true;
            data.Save();
        }
    }
}