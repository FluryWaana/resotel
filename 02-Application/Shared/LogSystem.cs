using System;
using System.IO;
using System.Windows;

namespace Resotel.Shared
{
    public static class LogSystem
    {
        /*
         * Affiche dans la sortie console le message à afficher ainsi que son
         * type de message.
         * Ecrit dans un fichier log la date où se produit l'erreur, le message
         * ainsi que le type de message exemple:
         * 26/04/2019 [Erreur] - Une erreur est survenue lors de 
         * l'enregistrement de la réservation
         */
        public static void WriteLog( string message, TypeLog  tl)
        {
            string mess     = DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + " - [" + tl + "] - " + message;

            // Nom du fichier log logs-26-04-2019.txt
            string fileName = "logs-" + DateTime.Now.ToString("dd-MM-yy") + ".txt";

            // Récupèré la variable d'environnement ( dev || prod ) 
            string APP_ENV  = Application.Current.FindResource( "APP_ENV" ).ToString();
            string path = "";

            // Vérifie l'environnement
            if ( APP_ENV.Equals( "dev" ) )
            {
                path = @"../../Logs/" + fileName;
            }
            else
            {
                // Si le dossier n'existe pas alors on le créé
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
                // Permet d'écrire dans un fichier .txt
                using ( StreamWriter file = new StreamWriter( path, true ) )
                {
                    // Ecrit le message après la dernière ligne du fichier
                    file.WriteLine(mess);
                }
            }
            else
            {
                // Créer le fichier texte et écrit le message
                File.WriteAllText( path, mess );
            }
        }
    }
}
