using net_caesar_encryptor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_caesar_encryptor.dao
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// ICeasarWordCryptologist.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Interface that contains methods for Encrypting and Decrypting the Word clear text.
    /// </summary>
    interface ICaesarWordCryptologist
    {
        /// <summary>
        /// Encrypt the clear text
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        string EncryptWord(Word word);
        /// <summary>
        /// Decrypt the encrypted text.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        string DecryptWord(Word word);
    }
}
