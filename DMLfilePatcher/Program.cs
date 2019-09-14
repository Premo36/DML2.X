using P36_UTILITIES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DMLfilePatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("PATCHING UTILITY - 2.0/v2.0b => v2.1");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Hello, this utilty will patch any incompatible file from version 2.0b (and also 2.0) in order to make it compatible with 2.1.");
            Console.WriteLine();
            Console.WriteLine("WARNING:");
            Console.WriteLine("This utility does not check if a file is already been patched!");
            Console.WriteLine("repeating again the process over already processed file (or file made with 2.1 version) will make them unreadble for any dml version!");
            //Console.WriteLine("Do not run this utility if you skipped a version (The patching is from last version to current, run in order all the patching utility till this one)");
            Console.WriteLine("Do not run this utility twice on the same files!");
            Console.WriteLine("Do not run this utility on files genereted with any version different from 2.0/2.0b!");
            Console.WriteLine("Do not run this utility on files that you've already patched by hand!");
            Console.WriteLine("If you have any file that conflicts with the above statments, temporary move it somewhere else and restart this utility");
            Console.WriteLine("The following presets will be patched:");


            string fold_APPDATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fold_P36SOFTWARE = Path.Combine(fold_APPDATA, @"P36_Software");
            string fold_DMLv2 = Path.Combine(fold_P36SOFTWARE, @"DMLv2");
            string foldPRESET = Path.Combine(fold_DMLv2, @"Presets");
            string[] file = Directory.GetFiles(foldPRESET).Where(P => Path.GetFileName(P) != "-.dml").ToArray();

            Console.WriteLine();

            foreach (string s in file)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            Console.WriteLine("Press the [X] in the corner to stop...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine("Press any key again to confirm...");
            Console.ReadKey();
            bool error = false;

            foreach (string s in file)
            {
                int C = 0;
                try
                {
                    Console.WriteLine("Patching " + s + "...");
                    Storage storage = new Storage(s);
                    Dictionary<string, string> values = new Dictionary<string, string>();
                    string[] rows = File.ReadAllLines(s);


                    foreach (string row in rows)
                    {


                        values.Add(C.ToString(), row);
                        C++;

                    }
                    storage.SaveValues(values, true);
                    Console.WriteLine("Patching SUCCEDED!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Patching FAILED: " + ex.Message);
                    error = true;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Patching terminated");

            if (error)
            {
                Console.WriteLine("WARNING: One ore more file could not be patched correctly, see log above for more details.");
            }
            else
            {
                Console.WriteLine("All files have been patched!");
            }
            Console.WriteLine("Press any key to exit the utility...");
            Console.ReadKey();
        }
    }
}
