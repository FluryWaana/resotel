using System;
using System.IO;

namespace Resotel.Shared
{
    /**
     * Cette classe permet de générer un log dans la console 
     * ainsi que dans un fichier Log.
     */
    public static class LogSystem
    {
        public static void WriteLog( string message, TypeLog  tl)
        {
            string mess     = DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + " - [" + tl + "] - " + message;
            string fileName = "logs-" + DateTime.Now.ToString("dd-MM-yy") + ".txt";
            string path     = @"../../Logs/" + fileName;

            Console.WriteLine(mess);

            // Vérifie si le fichier logs existe
            if( File.Exists("../../Logs/" + fileName ) )
            {
                using ( StreamWriter file = new StreamWriter( path, true ) )
                {
                    file.WriteLine(mess);
                }
            }
            else
            {
                File.WriteAllText( path, mess );
            }
        }
    }
}
