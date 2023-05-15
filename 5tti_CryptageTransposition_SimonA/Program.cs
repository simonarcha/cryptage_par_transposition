using System;
using System.Text;

namespace cryptage
{
    internal class Program
    {
        /*
-------------------------------------------------------------------------------------------------------
            4.La méthode de Cryptage par transposition:
            Les méthodes de cryptographie par transposition sont celles pour lesquelles on chiffre le
            message en permutant l'ordre des lettres du message suivant des règles bien définies.
            Autrement dit, on produit une anagramme du message initial.
            Effectuons un chiffrement par transposition rectangulaire :
            On commence par se mettre d'accord sur un mot-clé, par exemple le mot BIBMATH. On classe
            les lettres de ce mot et on attribue alors à chaque lettre son numéro dans l'ordre alphabétique.
            Ainsi, on donne à A le numéro 1, au premier B le numéro 2, au deuxième B le numéro 3, au H le
            numéro 4, etc....On crée ensuite un tableau de la façon suivante :
             La première ligne est constituée par les lettres de la clé;
             La deuxième ligne est constituée par les numéros qui leur sont associés;
             On complète ensuite le tableau en le remplissant avec les lettres du message à
            chiffrer.On écrit sur chaque ligne autant de lettres que de lettres dans la clé.
            Éventuellement, la dernière ligne n'est pas complète.
            Exemple: "JE SUIS ELEVE AU CENTRE ASTYMOULIN".
            B I B M A T H
            2 5 3 6 1 7 4
            J E S U I S E
            L E V E A U C
            E N T R E A S
            T Y M O U L I
            N

            Ensuite, on écrit d'abord le contenu de la colonne numérotée 1, puis le contenu de la colonne
            numérotée 2, etc...Le message chiffré obtenu est alors :
            IAEU JLETN SVTM ECSI EENY UERO SUAL
            Pour le déchiffrement, à vous de jouer...
------------------------------------------------------------------------------------------------------------ 
        */
        static void Main(string[] args)
        {
            MethodeDuProjet MesOutils = new MethodeDuProjet();
            MesOutils.Entreecle(out char[] Tcle);
            MesOutils.Entreephrase(out char[] Tphrase);
            MesOutils.Creematcrypt(in Tcle, in Tphrase, out char[,] MatCrypt);
            MesOutils.AfficherMatrice(MatCrypt);
            Console.ReadKey();
            MesOutils.Affichephasecodee(in MatCrypt,in Tcle);
            Console.ReadKey();
        }
    }
}
