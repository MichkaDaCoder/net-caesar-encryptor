using net_caesar_encryptor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_caesar_encryptor.exporter
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// ICaesarEncryptedWordFileSaver.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Contains the method for saving the generated Encrypted file.
    /// </summary>
    interface ICaesarEncryptedWordFileSaver
    {
        /// <summary>
        /// Generate and Save the Encrypted file as a random filename. 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="Fileame"></param>
        void SaveCaesarEncryptedFile(Word word, string Fileame);
    }
}
