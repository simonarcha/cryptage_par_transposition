using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptage
{
    public struct MethodeDuProjet
    {
        public void Entreecle(out char[] Tcle)
        {
            Console.Clear();
            bool ok = true;
            string cle = ("");
            Tcle = cle.ToCharArray(); // sert a verifier si c'est entrer correctement en lettre uniquement
            do
            {
                Console.WriteLine("Veuillez entrer la clé Alphanumérique : ");
                cle = Console.ReadLine().ToUpper();
                if (IsAlphaNumeric(cle))
                {
                    Tcle = cle.ToCharArray();
                    ok = true;
                }
                else
                {
                    Console.WriteLine("La clé doit être uniquement alphanumérique");
                    Console.ReadKey();
                    ok = false;
                }
            } while (!ok);

        }
        public void Entreephrase(out char[] Tphrase)
        {
            Console.Clear();
            bool ok = true;
            string phr = ("");
            Tphrase = phr.ToCharArray(); // sert a ce que les espaces entrer soient remplacer par ""
            do
            {
                Console.WriteLine("Veuillez entrer la phrase a crypter : ");
                phr = Console.ReadLine().ToUpper();
                phr = phr.Replace(" ", String.Empty);
                if (IsAlphaNumeric(phr))
                {
                    Tphrase = phr.ToCharArray();
                    ok = true;
                }
                else
                {
                    Console.WriteLine("La phrase doit être uniquement alphanumérique");
                    Console.ReadKey();
                    ok = false;
                }
            } while (!ok);
        }
        public static bool IsAlphaNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!(c >= 'A' && c <= 'Z') &&
                        !(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }

            return true;
        }
        public static char[] Trieetnum(char[] Temp)
        {
            char[] Tcletemp = new char[Temp.Length];
            char[] Tsort = new char[Temp.Length];
            char[] Tnum = new char[Temp.Length];
            Array.Copy(Temp, Tcletemp, Temp.Length);
            Array.Copy(Temp, Tsort, Temp.Length);
            int index = 0;
            Array.Sort(Tsort);  // fonction de tri
            int j = (int)Tsort[0] - 64; // le numéro du premier caractère (a=1,b=2, etc...) de la clé
            for (int i = 0; i < Tsort.Length; i++) // j'attribue la valeur numérique à la lettre n° ASCII
            {
                Tnum[i] = (char)(48 + j + i);
            }
            int k = 0;
            foreach (char c in Tcletemp)
            {
                index = Array.IndexOf(Tsort, c);
                Tsort[index] = '\0';
                Temp[k] = Tnum[index];
                k++;

            }
            return Temp;
        }
        public void AfficherMatrice(in char[,] matrice)
        {
            int lignes = matrice.GetLength(0);
            int colonnes = matrice.GetLength(1);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write(matrice[i, j] + "  "); // Affiche la valeur de chaque élément de la matrice avec deux espaces entre chaque élément
                }
                Console.Write("\n"); // Passe à la ligne suivante
            }
        }
        public void Affichephasecodee(in char[,] matrice, in char[] Tcle)
        {
            string phrasecodee = "";
            int lignes = matrice.GetLength(0);
            int colonnes = matrice.GetLength(1);

            for (int i = 49; i <= colonnes + 48; i++)
            {
                int k = Array.IndexOf(Tcle, (char)i);
                for (int j = 2; j < lignes; j++)
                {
                    phrasecodee = phrasecodee + matrice[j, k];
                }

                phrasecodee = phrasecodee + " ";
            }
            Console.Write(phrasecodee);
        }
        public  void Creematcrypt(in char[] Tcle, in char[] Tphrase, out char[,] MatCrypt)
        {
            int n = Tcle.Length;
            int m = Tphrase.Length;
            int div = m / n;
            if (m % n > 0) { div++; }
            MatCrypt = new char[div + 2, n];
            char[] Tcleinit = new char[n];
            Array.Copy(Tcle, Tcleinit, Tcle.Length);
            Trieetnum(Tcle);
            for (int i = 0; i < n; i++) { MatCrypt[0, i] = Tcleinit[i]; }
            for (int i = 0; i < n; i++) { MatCrypt[1, i] = Tcle[i]; }
            int j = 2;
            int k = 0;
            for (int i = 0; i < m;)
            {
                MatCrypt[j, k] = Tphrase[i];
                k++;
                i++;
                if (k % n == 0) { j++; k = 0; }
            }
        }
    }
}
