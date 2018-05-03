using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.Office.Interop.PowerPoint;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace CreatePowerPointSlide
{
    public partial class frmCreateSlide : Form
    {
        private string[] imageList;
        private int iLPos;

        public readonly string[] stopWords = {"a", "about", "above", "above", "across", "after", "afterwards", "again", "against",
            "all", "almost", "alone", "along", "already", "also", "although", "always", "am", "among", "amongst", "amoungst", "amount",
            "an", "and", "another", "any", "anyhow", "anyone", "anything", "anyway", "anywhere", "are", "around", "as", "at", "back",
            "be", "became", "because", "become", "becomes", "becoming", "been", "before", "beforehand", "behind", "being", "below",
            "beside", "besides", "between", "beyond", "bill", "both", "bottom", "but", "by", "call", "can", "cannot", "cant", "co",
            "con", "could", "couldnt", "cry", "de", "describe", "detail", "do", "done", "down", "due", "during", "each", "eg", "eight",
            "either", "eleven", "else", "elsewhere", "empty", "enough", "etc", "even", "ever", "every", "everyone", "everything",
            "everywhere", "except", "few", "fifteen", "fify", "fill", "find", "fire", "first", "five", "for", "former", "formerly",
            "forty", "found", "four", "from", "front", "full", "further", "get", "give", "go", "had", "has", "hasnt", "have", "he",
            "hence", "her", "here", "hereafter", "hereby", "herein", "hereupon", "hers", "herself", "him", "himself", "his", "how",
            "however", "hundred", "ie", "if", "in", "inc", "indeed", "interest", "into", "is", "it", "its", "itself", "keep", "last",
            "latter", "latterly", "least", "less", "ltd", "made", "many", "may", "me", "meanwhile", "might", "mill", "mine", "more",
            "moreover", "most", "mostly", "move", "much", "must", "my", "myself", "name", "namely", "neither", "never", "nevertheless",
            "next", "nine", "no", "nobody", "none", "noone", "nor", "not", "nothing", "now", "nowhere", "of", "off", "often", "on",
            "once", "one", "only", "onto", "or", "other", "others", "otherwise", "our", "ours", "ourselves", "out", "over", "own", "part",
            "per", "perhaps", "please", "put", "rather", "re", "same", "see", "seem", "seemed", "seeming", "seems", "serious", "several",
            "she", "should", "show", "side", "since", "sincere", "six", "sixty", "so", "some", "somehow", "someone", "something", "sometime",
            "sometimes", "somewhere", "still", "such", "system", "take", "ten", "than", "that", "the", "their", "them", "themselves", "then",
            "thence", "there", "thereafter", "thereby", "therefore", "therein", "thereupon", "these", "they", "thickv", "thin", "third",
            "this", "those", "though", "three", "through", "throughout", "thru", "thus", "to", "together", "too", "top", "toward", "towards",
            "twelve", "twenty", "two", "un", "under", "until", "up", "upon", "us", "very", "via", "was", "we", "well", "were", "what", "whatever",
            "when", "whence", "whenever", "where", "whereafter", "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which",
            "while", "whither", "who", "whoever", "whole", "whom", "whose", "why", "will", "with", "within", "without", "would", "yet", "you",
            "your", "yours", "yourself", "yourselves"};

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
            string[] delims = {" "};
            string[] titleWords = title.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            string[] bodyWords = body.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int len = bodyWords.Length;
            string[] boldWords = new string[len];
            int pos = 0;

            // Determine bold words
            bool bold = false;

            foreach (string word in bodyWords)
            {
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
            len = titleWords.Length + bodyWords.Length;
            pos = 0;
            string[] suggestWords = new string[len];

            // Remove stop words from title
            foreach (string word in titleWords)
            {
                // If word is not a stop word
                if (!IsStopWord(word))
                {
                    // Add the word to the list of potential suggestions
                    suggestWords[pos++] = word;
                }
            }

            // Remove stop words from bold body text
            foreach (string word in boldWords)
            {
                // If word is not a stop word
                if (!IsStopWord(word))
                {
                    // Add the word to the list of potential suggestions
                    suggestWords[pos++] = word;
                }
            }

            // Fix the suggest word array size, now that it is known
            Array.Resize(ref suggestWords, pos);

            // Uses the User's Pictures folder
            string picturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            imageList = new string[99999];
            iLPos = 0;
            
            // For each suggested word, recursively search the path for image files containing the word
            foreach (string word in suggestWords)
            {
                DirSearch(picturePath, word);
            }

            // Fix the image list array size, now that it is known
            Array.Resize(ref imageList, iLPos);

            // Add the images found to the list box
            chkLstImages.Items.Clear();

            foreach (string file in imageList)
            {
                chkLstImages.Items.Add(file);
            }

            chkLstImages.Refresh();
            chkLstImages.Focus();
        }

        // Recursively search for image files containing the suggested word in the file name
        void DirSearch(string sDir, string word)
        {
            try
            {
                string query = "*" + word + "*.*";

                // For each sub-directory
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    // Recursive call
                    DirSearch(d, word);
                }

                // For each file within the directory
                foreach (string f in Directory.GetFiles(sDir, query))
                {
                    string x = f.ToLower();

                    // Is the file an image file?
                    if (x.EndsWith(".png") || x.EndsWith(".bmp") || x.EndsWith(".jpg") ||
                        x.EndsWith(".jpeg") || x.EndsWith(".gif") || x.EndsWith(".tif"))
                    {
                        // Has the image file been seen before?
                        if (!imageList.Contains(f))
                        {
                            // If not, add it to the list
                            imageList[iLPos++] = f;
                        }
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        // Is the word a stop word?
        private bool IsStopWord(string word)
        {
            // If Index is greater than or equal to 0,
            // then word is present in stopWords
            return Array.IndexOf(stopWords, word) >= 0;
        }

        // Toggles the boldness of the selected word
        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (rtText.SelectionLength > 1)
            {
                System.Drawing.Font currentFont = rtText.SelectionFont;
                FontStyle newFontStyle = new FontStyle();

                // Is the word already bold?
                if (currentFont.Bold)
                {
                    // If so, toggle it
                    newFontStyle = FontStyle.Regular;
                } else
                {
                    // If not, toggle it
                    newFontStyle = FontStyle.Bold;
                }

                rtText.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle);
            }

            rtText.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();

            Microsoft.Office.Interop.PowerPoint.Slides slides;
            Microsoft.Office.Interop.PowerPoint._Slide slide;
            Microsoft.Office.Interop.PowerPoint.TextRange objText;

            // Create the Presentation File
            Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoTrue);

            Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];

            // Create new Slide
            slides = pptPresentation.Slides;
            slide = slides.AddSlide(1, customLayout);

            // Add title
            objText = slide.Shapes[1].TextFrame.TextRange;
            objText.Text = txtTitle.Text.Trim();
            objText.Font.Name = "Arial";
            objText.Font.Size = 32;

            // Add body text
            objText = slide.Shapes[2].TextFrame.TextRange;
            objText.Text = rtText.Text.Trim();

            // Get list of selected images
            foreach (object file in chkLstImages.CheckedItems)
            {
                string fileName = file.ToString();

                // Insert Image
                Microsoft.Office.Interop.PowerPoint.Shape shape = slide.Shapes[2];
                slide.Shapes.AddPicture(fileName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, shape.Width / 2, shape.Top * 2, shape.Width / 2, shape.Height / 2);
            }

            // Launch PowerPoint
            pptPresentation.SaveAs(@"c:\temp\result.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

        }

        private void chkLstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the image in the picture box
            pictBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBox.ImageLocation = chkLstImages.SelectedItem.ToString();
        }
    }
}
