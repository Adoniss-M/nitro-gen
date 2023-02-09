using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace nitro_gen_check_webhook
{
    class Program
    {

        protected static int gen_n = 0;
        protected static List<string> codes = new List<string> { };
        protected static readonly char[] alpha = "AfnOmhIFoWUb73dauQpLg6XwqJxiNY5T1r4SlkvztH2yeBsGE8DRPCVMcKZ9".ToCharArray();
        protected static readonly string logo = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/,/#@       #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@     .*(%%      &    @&#*. @@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@      @@@@@       @@@@    @@@,     @@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@     @@@@@@@,     @@@@@@     @@@@@@@     @@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@     @@@@@@@@@     %@@@@@@/    @@@@@@@@@@@     @@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@    &@@@@@@@@@@&    &@@@@@@(    @@@@@@@@@@@@@@&    @@@@@@@@@@@@@@\n@@@@@@@@@@@@@@   *@@@@@@@@@@@@@     @@@@@@   &@@@@@@@@@@@@@@@@@/   @@@@@@@@@@@@@\n@@@@@@@@@@@@#   @@@@@@@@@@@@@@@@      @@@@@@@@@@@@@@@@@@@@@@@@@@@   (@@@@@@@@@@@\n@@@@@@@@@@@#   @@@@@@@@@@@@@@@@@@@       @@@@@@@@@@@@@@@@@@@@@@@@@   (@@@@@@@@@@\n@@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@       @@@@@@@@@@@@@@@@@@@@@@@   @@@@@@@@@@\n@@@@@@@@@@   *@@@@@@@@@@@@@@@@@@@@@@@@@@       @@@@@@@@@@@@@@@@@@@@/   @@@@@@@@@\n@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@@@@@@@@@@@@@@@   @@@@@@@@@\n@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@       @@@@@@@@@@@@@@@@@@@   @@@@@@@@@\n@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@        @@@@@@@@@@@@@@@@@@@@   @@@@@@@@@\n@@@@@@@@@@   *@@@@@@@@@@@@@@@@@@@@@@*      &@@@@@@@@@@@@@@@@@@@@@@@/   @@@@@@@@@\n@@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@.    .@@@@@@@@@@@@@@@@@@@@@@@@@@@@   @@@@@@@@@@\n@@@@@@@@@@@#   @@@@@@@@@@@@@@@*   #@@@@@@@@@    @@@@  ,&@@@@@@@@@@   (@@@@@@@@@@\n@@@@@@@@@@@@(   @@@@@@@@@@@@   @@@@@@@@@@@@@@@   .    @@@@@@@@@@@   (@@@@@@@@@@@\n@@@@@@@@@@@@@@   *@@@@@@@.#@@@@@@@@@@@@@@@@@@@@@    ,@@@@@@@@@@/   @@@@@@@@@@@@@\n@@@@@@@@@@@@@@@   .&@@@@@@@@@@@@@@@@@@@@@@@@@@ .&@    &@@@@@@&    @@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@*(@@@@@@@@@@@@@@@@@@@@@@@@@@ @@@@@,  ,.@@@,    @@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@%#/,.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%/,  @@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@@@@@@@@@@@@@@@@@@****. @@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@            ...            @@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*           *@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
        protected static readonly string banner = "\n    _   __    _    __                          ______                                       __                \n   / | / /   (_)  / /_   _____  ____          / ____/  ___    ____   ___    _____  ____ _  / /_  ____    _____\n  /  |/ /   / /  / __/  / ___/ / __ \\        / / __   / _ \\  / __ \\ / _ \\  / ___/ / __ `/ / __/ / __ \\  / ___/\n / /|  /   / /  / /_   / /    / /_/ /       / /_/ /  /  __/ / / / //  __/ / /    / /_/ / / /_  / /_/ / / /    \n/_/ |_/   /_/   \\__/  /_/     \\____/        \\____/   \\___/ /_/ /_/ \\___/ /_/     \\__,_/  \\__/  \\____/ /_/     ";

        static void Main(string[] args)
        {
            Menu1();
            Thread.Sleep(500);
            Console.Clear();
            Console.Write('\n');
            Menu2();
            Thread.Sleep(500);
            Console.Write("\n\n");
            while(true)
            {
                Console.Write("Enter number of nitro links to generate : ");
                gen_n = Convert.ToInt32(Console.ReadLine());
                Generate();
                Console.Write('\n');
                Console.Write("Generated " + Convert.ToString(gen_n) + " links\n\nWanna Generate more ? (y/N) : ");
                string ans = Console.ReadLine();
                if(ans == "n" || ans =="N")
                {
                    break;
                }
            }
            Save();
            Console.Clear();
            Menu1();
            Thread.Sleep(500);
            Console.Clear();
        }
        protected static void Menu1()
        {
            Console.SetWindowSize(80, 27);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(logo);
        }
        protected static void Menu2()
        {
            Console.SetWindowSize(120, 30);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(banner);
        }
        protected static void Generate()
        {
            for (int i = 0; i < gen_n; i++)
            {
                List<char> tmpCode = new List<char> { };
                for (int j = 0; j < 16; j++)
                {
                    tmpCode.Add(alpha[(new Random()).Next(0, alpha.Length - 1)]);
                }
                string completeCode = String.Join("", tmpCode);
                Console.WriteLine($"[+] https://discord.com/gifts/{completeCode}", ColorTranslator.FromHtml("#08d91a"));
                codes.Add(completeCode);
            }
        }
        protected static void Save()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory().ToString(), "Nitro.txt");
            string codeToString = String.Join("\n", codes);
            Console.WriteLine("\nSaving Generated Codes !");
            string generatorDate = DateTime.Now.ToString();
            Thread.Sleep(2000);
            if (File.Exists(filePath))
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    codes.ForEach(s => sw.WriteLine("https://discord.gift/" + s));
                }
            }
            else
            {
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    codes.ForEach(s => sw.WriteLine("https://discord.gift/" + s));
                }
            }
            Console.WriteLine("\nCodes saved, check execution directory\n");
            Console.WriteLine(filePath);
            Thread.Sleep(500);
        }
        protected static bool Check(string code)
        {
            return true;
        }
    }
}
