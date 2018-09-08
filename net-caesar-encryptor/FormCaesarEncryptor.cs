using net_caesar_encryptor.model;
using net_caesar_encryptor.utils;
using net_caesar_encryptor.exporter;
using net_caesar_encryptor.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net_caesar_encryptor
{
    /// <summary>
    /// --------------------------------------------------------------------
    /// FormCaesarEncryptor.cs, by MichkaDaCoder
    /// --------------------------------------------------------------------
    /// Main Form that contains the Encryption and the generation of the file
    /// </summary>
    public partial class FormCaesarEncryptor : Form
    {
        Word word = new Word();
        ICaesarWordCryptologist wordCryptologist = new CaesarWordCryptologist();
        ICaesarEncryptedWordFileSaver fileSaver = new CaesarEncryptedWordFileSaver();
        
        public FormCaesarEncryptor()
        {
            InitializeComponent();

            this.MaximizeBox = AppUtils.PARAM_FORMCAESARENCRYPTOR_MAXIMIZABLE;
            this.Text = AppUtils.PARAM_FORMCAESARENCRYPTOR_TITLE;
            InitSavecaesar();
        }

        /// <summary>
        /// Init the saveCaesar component with params written in AppUtils class.
        /// See <see cref="utils.AppUtils"> AppUtils class.</see>
        /// </summary>
        private void InitSavecaesar()
        {
            saveCaesar.DefaultExt = AppUtils.PARAM_SAVEcaesar_EXTENSION;
            saveCaesar.FileName = AppUtils.PARAM_SAVEcaesar_FILENAME;
            saveCaesar.Title = AppUtils.PARAM_SAVEcaesar_TITLE;
            saveCaesar.ShowHelp = AppUtils.PARAM_SAVEcaesar_SHOW_HELP;
            saveCaesar.OverwritePrompt = AppUtils.PARAM_SAVEcaesar_OVERRIDE_PROMPT;
            saveCaesar.InitialDirectory = AppUtils.PARAM_SAVEcaesar_INITIAL_DIRECTORY;
            saveCaesar.Filter = AppUtils.PARAM_SAVEcaesar_FILTER;
            saveCaesar.AddExtension = AppUtils.PARAM_SAVEcaesar_ADD_EXTENSION;
            saveCaesar.CreatePrompt = AppUtils.PARAM_SAVEcaesar_CREATE_PROMPT;
        }

        private void Mapping()
        {
            this.word.ClearText = txtClear.Text;
            this.word.EncryptedText = txtCrypted.Text;

            if(!AppUtils.IsFieldEmpty(txtNumberOffset.Text))
            {
                this.word.NumberOfOffsets = AppUtils.ConvertToNumber(txtNumberOffset.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AppUtils.IsFieldEmpty(txtNumberOffset.Text))
            {
                txtClear.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                txtClear.Enabled = true;
                try
                {
                    Mapping();

                    DialogResult result = this.saveCaesar.ShowDialog();

                    switch (result)
                    {
                        case DialogResult.OK:
                            this.fileSaver.SaveCaesarEncryptedFile(this.word, saveCaesar.FileName);
                            AppUtils.ShowSuccessMsg("Success", AppUtils.PARAM_MSG_SUCCESS_SAVE);
                            AppUtils.InitForm(new TextBox[]
                            {
                                txtNumberOffset,
                                txtClear,
                                txtCrypted
                            });
                            break;

                        default:
                            return;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AppUtils.ShowErrorMsg("Error", ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void FormcaesarCrypter_Load(object sender, EventArgs e)
        {
            if(AppUtils.IsFieldEmpty(txtNumberOffset.Text))
            {
                txtClear.Enabled = false;
            }
            else
            {
                txtClear.Enabled = true;
            }
        }

        private void txtClear_TextChanged(object sender, EventArgs e)
        {
            if(AppUtils.IsFieldEmpty(txtNumberOffset.Text))
            {
                txtClear.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                txtClear.Enabled = true;

                try
                {
                    Mapping();
                    txtCrypted.Text = this.wordCryptologist.EncryptWord(this.word);
                    button1.Enabled = true;
                }
                catch(Exception ex)
                {
                    AppUtils.ShowErrorMsg("Error", ex.Message + "\n\n" + ex.StackTrace);
                    AppUtils.ShowErrorMsg("Error", "Offset = " + word.NumberOfOffsets + ", ClearText = " + word.ClearText + ", EncryptedText= " + word.EncryptedText);
                }
            }
        }

        private void txtNumberOffset_TextChanged(object sender, EventArgs e)
        {
            if(AppUtils.IsFieldEmpty(txtNumberOffset.Text))
            {
                txtClear.Enabled = false;
            }
            else
            {
                if(!AppUtils.IsOffsetValid(AppUtils.ConvertToNumber(txtNumberOffset.Text)))
                {
                    errorProvider1.SetError(txtNumberOffset, AppUtils.PARAM_MSG_INCORRECT_OFFSETS);
                    txtClear.Enabled = false;
                }
                else
                {
                    errorProvider1.Dispose();
                    txtClear.Enabled = true;
                }
            }
        }

        private void txtNumberOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) &&!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppUtils.ShowSuccessMsg("Info", "Bye Bye ! :)");
            Application.Exit();
        }

        private void aboutAppMenuItem_Click(object sender, EventArgs e)
        {
            new FormAboutcaesarEncryptor().ShowDialog();
        }
    }
}
