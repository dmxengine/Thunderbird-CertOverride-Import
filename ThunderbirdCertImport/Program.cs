using System;
using System.Collections.Generic;
using System.IO;

namespace ThunderbirdCertImport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string appLocationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string sourceCertOverrideLocationPath = Path.Combine(appLocationPath + "\\cert_override.txt");
                if (File.Exists(sourceCertOverrideLocationPath))
                {
                    string certOverrideContent = File.ReadAllText(sourceCertOverrideLocationPath);
                    string ThunderbirdProfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Thunderbird\\Profiles");
                    if (Directory.Exists(ThunderbirdProfilePath))
                    {
                        IEnumerable<string> profileFolders = Directory.EnumerateDirectories(ThunderbirdProfilePath);
                        foreach (var profileFolder in profileFolders)
                        {
                            try
                            {
                                File.WriteAllText(profileFolder + "\\cert_override.txt", certOverrideContent);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Thunderbird Profiles folder not found");
                    }
                }
                else
                {
                    Console.WriteLine("cert_override.txt not found in folder with ThunderbirdCertImport");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
