using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Transposition_DedSec
{
    class Decrypt
    {
        public static String decrypt(String toDecrypt, String key)
        {
            String decrypted = "";
            int length = toDecrypt.Length;
            int columnNumber = key.Length;
            int rowNumber = (int)length / columnNumber;
            if(length % columnNumber != 0) rowNumber++;

            //On trie notre clef
            int[] orderedKey = Crypt.relativeAlphabetOrder(key);

            // On remplit un tableau de char à 2 dimmensions
            char[,] result = new char[rowNumber, columnNumber];
            int position = 0;            
            for (int j = 0; j < columnNumber; ++j)
            {
                int k = 0;
                while (orderedKey[k] != j) k++;
                for (int i = 0; i < rowNumber; ++i)
                {
                    if (position < toDecrypt.Length)
                    {
                        result[i, k] = toDecrypt[position];
                        position++;
                    }
                }
                    
            }
            
            for(int i = 0; i < rowNumber; ++i)
                for(int j = 0; j < columnNumber; ++j)
                {
                    if (result[i, j] != '\0')
                        decrypted += result[i, j];
                }
            
            return decrypted;
        }
            
    }
}
