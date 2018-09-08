using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net_caesar_encryptor.model;
using net_caesar_encryptor.utils;

namespace net_caesar_encryptor.dao
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// CaesarWordCryptologist.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Implements ICaesarWordCryptologist, contains the implementation of 
    /// the Encryption and Decryption of the ClearText and the EncryptedText
    /// respectively.
    /// </summary>
    class CaesarWordCryptologist : ICaesarWordCryptologist
    {
        /// <summary>
        /// Latin Alphabet Array
        /// </summary>
        char[] Alphabets = new char[]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        char[] ClearText = new char[26];
        char[] EncryptedText = new char[26];

        /// <summary>
        /// Encrypts the ClearText
        /// </summary>
        /// <param name="word"></param>
        /// <returns>EncryptedText</returns>
        public string EncryptWord(Word word)
        {
            for (int i = 0; i < 26; i++)
            {
                this.EncryptedText[i] = Alphabets[(i + word.NumberOfOffsets) % 26];
            }

            for (int i = 0; i < 26; i++)
            {
                this.ClearText[i] = Alphabets[(i + word.NumberOfOffsets) % 26];
            }

            char[] msg = word.ClearText.ToCharArray();

            for(int i=0;i<msg.Length;i++)
            {
                if (AppUtils.IsUpperCaseChar(msg[i]))
                {
                    msg[i] = EncryptedText[msg[i] - 'A'];
                }
            }
            return new string(msg);

        }

        /// <summary>
        /// Decrypt the EncryptedText
        /// </summary>
        /// <param name="word"></param>
        /// <returns>ClearText</returns>
        public string DecryptWord(Word word)
        {
            for (int i = 0; i < 26; i++)
            {
                this.EncryptedText[i] = Alphabets[(i + word.NumberOfOffsets) % 26];
            }

            for (int i = 0; i < 26; i++)
            {
                this.ClearText[i] = Alphabets[(i + word.NumberOfOffsets) % 26];
            }
            char[] msg = word.ClearText.ToCharArray();

            for (int i = 0; i < msg.Length; i++)
            {
                if (AppUtils.IsUpperCaseChar(msg[i]))
                {
                    msg[i] = ClearText[msg[i] - 'A'];
                }
            }
            return new string(msg);
        }


        
    }
}
