using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net_caesar_encryptor.utils
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// AppUtils.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Utility class. Contains FormCaesar Components attributes, 
    /// generic messages and form validation methods.
    /// </summary>
    class AppUtils
    {
        #region savecaesar properties
        public static readonly string PARAM_SAVEcaesar_EXTENSION = ".caesar";
        public static readonly string PARAM_SAVEcaesar_FILENAME = Path.GetRandomFileName();
        public static readonly string PARAM_SAVEcaesar_TITLE = "Save your text";
        public static readonly Boolean PARAM_SAVEcaesar_SHOW_HELP = true;
        public static readonly Boolean PARAM_SAVEcaesar_OVERRIDE_PROMPT = true;
        public static readonly string PARAM_SAVEcaesar_INITIAL_DIRECTORY = Application.StartupPath;
        public static readonly string PARAM_SAVEcaesar_FILTER = "caesar Files(*.caesar) | *.caesar";
        public static readonly Boolean PARAM_SAVEcaesar_ADD_EXTENSION = true;
        public static readonly Boolean PARAM_SAVEcaesar_CREATE_PROMPT = true;
        #endregion

        #region Form properties
        public static readonly string PARAM_FORMCAESARENCRYPTOR_TITLE = "net-caesar-encryptor";
        public static readonly Boolean PARAM_FORMCAESARENCRYPTOR_MAXIMIZABLE = false;
        #endregion

        #region MessageBox Texts 
        public static readonly string PARAM_MSG_SUCCESS_SAVE = "Successfully saved your to the filename : "+PARAM_SAVEcaesar_FILENAME;
        public static readonly string PARAM_MSG_FAILURE_SAVE = "Failed to save your text";
        public static readonly string PARAM_MSG_INCORRECT_OFFSETS = "Incorrect offset";
        #endregion

        #region Messagebox methods
        public static void ShowSuccessMsg(string Title, string Text)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMsg(string Title, string Text)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Form Validation methods
        /// <summary>
        /// Check if a TextBox field is empty.
        /// </summary>
        /// <example>
        /// <code>
        ///  if(AppUtils.IsFieldEmpty(txtLogin.Text)) {
        ///      btnLogin.Enabled=false;
        ///      }
        /// </code>
        /// </example>
        /// <param name="Field"></param>
        /// <returns>Boolean</returns>
        public static Boolean IsFieldEmpty(string Field)
        {
            return String.IsNullOrEmpty(Field);
        }
        
        /// <summary>
        /// Checks if the offset is valid.
        /// </summary>
        /// <param name="NumberOfOffset"></param>
        /// <returns></returns>
        public static Boolean IsOffsetValid(int NumberOfOffset)
        {
            return NumberOfOffset > 0 && NumberOfOffset < 25;
        }

        /// <summary>
        /// Parses a TextBox String value to Integer.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static int ConvertToNumber(string Value)
        {
            return int.Parse(Value);
        }

        /// <summary>
        /// Clear the form
        /// </summary>
        /// <param name="textBoxes"></param>
        public static void InitForm(TextBox[] textBoxes)
        {
            for(int i=0;i<textBoxes.Length;i++)
            {
                textBoxes[i].Clear();
            }
        }

        public static Boolean IsUpperCaseChar(char c)
        {
            return Char.IsUpper(c);
        }
        #endregion


    }
}
 