using System;
using System.Threading;

namespace ProgressBar
{
    class Program
    {
        const char chrSquare = '■';
        const string strBack = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string strLoading = "-\\|/";

        static void Main(string[] args)
        {
            LoadingBar(0);
            for (var i = 0; i <= 100; ++i)
            {
                LoadingBar(i, true);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            LoadingIcon(0);
            for (var i = 0; i <= 100; ++i)
            {
                LoadingIcon(i, true);
                Thread.Sleep(50);
            }
        }

        public static void LoadingBar(int percent, bool update = false)
        {
            if (update)
                Console.Write(strBack);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(chrSquare);
            }
            Console.Write("] {0,3:##0}%", percent);
        }

        public static void LoadingIcon(int progress, bool update = false)
        {
            if (update)
                Console.Write("\b");
            Console.Write(strLoading[progress % strLoading.Length]);
        }
    }
}
