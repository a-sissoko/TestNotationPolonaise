using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        static float Polonaise(String formule)
        {
            try
            {
                // découper la chaîne reçue en paramètre
                string[] tableau = formule.Split(' ');
                // à partir de la fin du tableau, s'arrêter à une case qui contient un signe d'opération
                int i = tableau.Length - 1;
                while (i >= 0)
                {
                    
                    if (tableau[i] != "+" && tableau[i] != "-" && tableau[i] != "*" && tableau[i] != "/")
                    {
                        i--;
                    }
                    else
                    {
                        float resultatIntermediaire = 0;
                        // faire l'opération avec les 2 cases suivantes (d'indices n+1 et n+2)
                        switch (tableau[i])
                        {
                            case "+":
                                resultatIntermediaire = float.Parse(tableau[i + 1]) + float.Parse(tableau[i + 2]);
                                break;
                            case "-":
                                resultatIntermediaire = float.Parse(tableau[i + 1]) - float.Parse(tableau[i + 2]);
                                break;
                            case "*":
                                resultatIntermediaire = float.Parse(tableau[i + 1]) * float.Parse(tableau[i + 2]);
                                break;
                            case "/":
                                resultatIntermediaire = float.Parse(tableau[i + 1]) / float.Parse(tableau[i + 2]);
                                break;
                        }
                        // ranger le résultat à la place du signe
                        tableau[i] = resultatIntermediaire.ToString();

                        // décalant toutes les cases de 2 crans vers la gauche
                        for (int j = (i + 1); j < tableau.Length - 2; j++)
                        {
                            if (tableau[j + 2] != " ")
                            {
                                tableau[j] = tableau[j + 2];
                            }
                        }

                        // remplacer le contenu des 2 dernières cases par un espace
                        int k = tableau.Length - 1;
                        while (tableau[k] == " " && k >= 2)
                        {
                            k--;
                        }
                        if (k >= 2)
                        {
                            tableau[k] = " ";
                            tableau[k - 1] = " ";
                        }
                    }
                }
                if (float.IsInfinity(float.Parse(tableau[0])))
                {
                    return float.NaN;
                }
                else
                {
                    return float.Parse(tableau[0]);
                }
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
