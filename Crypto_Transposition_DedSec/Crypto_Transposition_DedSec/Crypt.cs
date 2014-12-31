using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Transposition_DedSec
{
    class Crypt
    {
        public static String crypt(String toCrypt, String key)
        {
            String crypted = "";
            int length = toCrypt.Length;
            int columnNumber = key.Length;
            int rowNumber = (int)length / columnNumber;
            if (length % columnNumber != 0) rowNumber++;
            
            // On remplit un tableau de char à 2 dimmensions
            char[,] result = new char[rowNumber, columnNumber];
            int position = 0;
            for(int i = 0; i < rowNumber; ++i)
                for(int j = 0; j < columnNumber; ++j)
                {
                    if (position < toCrypt.Length)
                    {
                        result[i, j] = toCrypt[position];
                        position++;
                    }
                    else
                        result[i, j] = ' ';
                }
                    

            //On trie notre clef
            int[] orderedKey = relativeAlphabetOrder(key);
            for(int j = 0; j < columnNumber; ++j)
            {
                int k = 0;
                while (orderedKey[k] != j) k++;
                for (int i = 0; i < rowNumber; ++i)
                    if (result[i, k] != '\0')
                        crypted += result[i, k];
            }

            return crypted;
        }

        public static int[] relativeAlphabetOrder(String str)
        {
            int length = str.Length;
            int[] result = new int[length];
            for(int i = 0; i < length; ++i) result[i] = -1;
            int index = 0;
            // Procédure de tri de la clef
            for(int i = 0; i < length; ++i)
            {
                //On va traiter chaque élément de cette façon
                //On commence par prendre le premier élément non traité
                int j = 0;
                while(result[j] != -1) j++;
                // Là on tient notre j qui est le premier élément non traité
                int min = j;
                // On fait comme si c'etait le minimum
                for (int k = 0; k < length; ++k)
                {
                    // On parcourt notre clef pour trouver un element non traité plus petit
                    if (result[k] == -1 && str[k] < str[min])
                        min = k;
                }
                // Maintenant on a notre vrai minimum non traité
                result[min] = index;
                index++;
                // On lui donne une médaille et on réitère jusqu'à la mort !!
            }
            return result;       
        }

    }
}
