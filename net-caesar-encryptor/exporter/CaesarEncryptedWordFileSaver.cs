using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net_caesar_encryptor.model;

namespace net_caesar_encryptor.exporter
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// CaesarEncryptedWordFileSaver.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Implements ICaesarEncryptedWordFileSave interface and contains
    /// the method for exporting the encrypted file.
    /// </summary>
    class CaesarEncryptedWordFileSaver : ICaesarEncryptedWordFileSaver
    {
        #region some declarations
        string FirstTitle = "Your Clear Text: ";
        string Delimiter = "\n";
        string SecondTitle = "Your Crypted Text: ";
        string ThirdTitle = "Number of Offsets : ";
        #endregion

        /// <summary>
        /// Saves the encrypted Word datas in a random filename name; including
        /// One line for the Encrypted text, another one for clear one and 
        /// another one for the used offset.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="Filename"></param>
        public void SaveCaesarEncryptedFile(Word word, string Filename)
        {
            StreamWriter streamWriter = new StreamWriter(Filename);
            StringBuilder stringBuilder = new StringBuilder();

            string format = this.FirstTitle + Delimiter + word.ClearText + Delimiter + Delimiter + this.SecondTitle + Delimiter + word.EncryptedText + Delimiter + Delimiter + this.ThirdTitle + Delimiter + word.NumberOfOffsets + Delimiter;
            stringBuilder.Append(format);

            if(Filename!=null)
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
