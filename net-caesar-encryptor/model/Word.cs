using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_caesar_encryptor.model
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// Word.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// POJO class for your text. Contains 3 attributes: 
    /// - ClearText(string) : for the clear text your enter.
    /// - EncryptedText(string) : for the encrypted text by CAESAR Method.
    /// - Offset(int): for the number offset.
    /// </summary>
    class Word
    {
        public string ClearText { get; set; }
        public string EncryptedText { get; set; }
        public int NumberOfOffsets { get; set; }

        /// <summary>
        /// Default constructor of the class.
        /// </summary>
        public Word() { }

        /// <summary>
        /// Parameterized constructor of the class with ClearText(string) attribute.
        /// </summary>
        /// <param name="ClearText"></param>
        public Word(string ClearText)
        {
            this.ClearText = ClearText;
        }

        /// <summary>
        /// Parameterized constructor of the class.
        /// </summary>
        /// <param name="ClearText"></param>
        /// <param name="EncryptedText"></param>
        /// <param name="NumberOfOffsets"></param>
        public Word(string ClearText, string EncryptedText, int NumberOfOffsets)
        {
            this.ClearText = ClearText;
            this.EncryptedText = EncryptedText;
            this.NumberOfOffsets = NumberOfOffsets;
        }

        public override string ToString()
        {
            return this.ClearText;
        }
    }
}
