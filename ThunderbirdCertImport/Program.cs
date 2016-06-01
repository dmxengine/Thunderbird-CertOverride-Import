using System;
using System.Collections.Generic;
using System.IO;

namespace ThunderbirdCertImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string appLocationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sourceCertOverrideLocationPath = Path.Combine(appLocationPath + "\\cert_override.txt");
            if (File.Exists(sourceCertOverrideLocationPath))
            {
                string certOverrideContent = File.ReadAllText(sourceCertOverrideLocationPath);
                string ThunderbirdProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Thunderbird\\Profiles");
                IEnumerable<string> certOverrideFiles = Directory.EnumerateFiles(ThunderbirdProfilePath, "cert_override.txt", SearchOption.AllDirectories);
                foreach (var certOverrideFile in certOverrideFiles)
                {
                    try
                    {
                        File.WriteAllText(certOverrideFile, certOverrideContent);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else {
                Console.WriteLine("cert_override.txt not found in folder with ThunderbirdCertImport");
            }
        }
    }
}
