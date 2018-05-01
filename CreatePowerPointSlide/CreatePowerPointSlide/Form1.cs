using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePowerPointSlide
{
    public partial class frmCreateSlide : Form
    {
        public frmCreateSlide()
        {
            InitializeComponent();
        }

        private void btnSuggestImg_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string body = rtText.Rtf;

            // Remove font encoding info that we don't need
            int idx = body.IndexOf('}') + 2;
            body = body.Substring(idx, body.Length - idx - 3);

            // Remove carriage return/line feeds
            body = body.Replace("\r\n", "");

            // Remove starting encoding
            body = body.Replace("\\viewkind4\\uc1\\pard", "");
            body = body.Replace("\\f0\\fs17", "");

            // Remove paragraphs
            body = body.Replace("\\par", " ");

            // Separate bold encoding from text
            body = body.Replace("\\b", " \\b");

            // Get words from title and body text
            String[] delims = {" "};
            string[] titleWords = title.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            string[] bodyWords = body.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int len = bodyWords.Length;
            string[] boldWords = new string[len];
            int pos = 0;

            // Determine bold words
            bool bold = false;

            for (int i = 0; i < len; i++)
            {
                string word = bodyWords[i];

                // Beginning Bold marker
                if (word.CompareTo("\\b") == 0)
                {
                    bold = true;
                    continue;
                } // Ending Bold marker
                else if (word.CompareTo("\\b0") == 0)
                {
                    bold = false;
                    continue;
                } 
                
                // Just a word
                // If Bold, save it, otherwise do nothing
                if (bold)
                {
                    boldWords[pos++] = word;
                }
            }

            // Fix the bold word array size, now that it is known
            Array.Resize(ref boldWords, pos);

            // Determine suggestion words


        }

        // Toggles the boldness of the selected word
        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (rtText.SelectionLength > 1)
            {
                Font currentFont = rtText.SelectionFont;
                FontStyle newFontStyle = new FontStyle();

                if (currentFont.Bold)
                {
                    newFontStyle = FontStyle.Regular;
                } else
                {
                    newFontStyle = FontStyle.Bold;
                }

                rtText.SelectionFont = new Font(currentFont, newFontStyle);
            }

            rtText.Focus();
        }
    }
}
