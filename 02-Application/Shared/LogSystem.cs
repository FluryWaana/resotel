using System;
using System.IO;
using System.Windows;

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
            string APP_ENV  = Application.Current.FindResource( "APP_ENV" ).ToString();
            string path = "";

            if ( APP_ENV.Equals( "dev" ) )
            {
                path = @"../../Logs/" + fileName;
            }
            else
            {
                if ( ! Directory.Exists( @"Logs/" ) )
                {
                    Directory.CreateDirectory( @"Logs/" );
                }

                path = @"Logs/" + fileName;
            }                      

            Console.WriteLine(mess);

            // Vérifie si le fichier logs existe
            if( File.Exists( path ) )
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
