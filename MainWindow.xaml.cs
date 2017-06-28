using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using Citac2;
using System.Data;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Wpf_pdf_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteDatabase db;
        List<TextBox> boxovi;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void nesto(string[] popis2, string[] popis3,int pomak=0)
        {


            //PdfSharp.Pdf.PdfDocument PDFDoc = PdfSharp.Pdf.IO.PdfReader.Open(textBox9.Text, PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument PDFDoc = CompatiblePdfReader.Open(textBox9.Text, PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument PDFNewDoc = new PdfSharp.Pdf.PdfDocument();

            //       for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
            //{
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            PdfPage pp = PDFNewDoc.AddPage(PDFDoc.Pages[0]);
            XGraphics gfx = XGraphics.FromPdfPage(pp);
            XFont font = new XFont("Arial", 9, XFontStyle.Regular, options);

            XFont font1 = new XFont("Arial", 10, XFontStyle.Regular, options);
            XFont fontb = new XFont("Arial", 9.5, XFontStyle.Bold, options);
            XFont font1b = new XFont("Arial", 10.5, XFontStyle.Bold, options);
            XFont font1c = new XFont("Arial", 11, XFontStyle.Bold, options);
            XFont font2 = new XFont("Arial", 14, XFontStyle.Bold, options);
            XFont font3 = new XFont("Arial", pretvori(textBox11a.Text), XFontStyle.Bold, options);
            XFont font4 = new XFont("Arial", 12, XFontStyle.Bold, options);
            XFont font5 = new XFont("Arial", 8, XFontStyle.Regular, options);

            gfx.DrawRectangle(XBrushes.White, new XRect(78, 100, 450, 35));
            Size zz = MeasureString(popis2[8], new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal, font2.Size);
            gfx.DrawString(popis2[8], font2, XBrushes.Black, new XRect(86-(zz.Width-455)/3, 109, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(78, 136 , 150, 12 ));
            gfx.DrawString(popis2[0], font1, XBrushes.Black, new XRect(96, 136 , 0, 20 ), XStringFormats.TopLeft);
            if (popis2[4].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(230, 136 + pomak, 300, 12 ));
                gfx.DrawString(popis2[4], font1, XBrushes.Black, new XRect(238, 137 + pomak, 0, 20 ), XStringFormats.TopLeft);
            }
            gfx.DrawRectangle(XBrushes.White, new XRect(78, 152 + pomak, 150, 12 ));
            gfx.DrawString(popis2[1], font1, XBrushes.Black, new XRect(96, 151 + pomak, 0, 20 ), XStringFormats.TopLeft);
            if (popis2[5].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(230, 152+pomak, 300, 12));
                gfx.DrawString(popis2[5], font1, XBrushes.Black, new XRect(238, 152+pomak, 0, 20), XStringFormats.TopLeft);
            }
            gfx.DrawRectangle(XBrushes.White, new XRect(78, 167+pomak, 150, 12));
            gfx.DrawString(popis2[2], font1, XBrushes.Black, new XRect(96, 166+pomak, 0, 20), XStringFormats.TopLeft);
            if (popis2[6].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(230, 167+pomak, 300, 12));
                gfx.DrawString(popis2[6], font1, XBrushes.Black, new XRect(238, 167+pomak, 0, 20), XStringFormats.TopLeft);
            }
            gfx.DrawRectangle(XBrushes.White, new XRect(78, 182 + pomak, 150, 12));
            gfx.DrawString(popis2[3], font1, XBrushes.Black, new XRect(96, 181 + pomak, 0, 20), XStringFormats.TopLeft);
            if (popis2[7].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(230, 182 + pomak, 300, 12));
                gfx.DrawString(popis2[7], font1, XBrushes.Black, new XRect(238, 182 + pomak, 0, 20), XStringFormats.TopLeft);
            }
            gfx.DrawRectangle(XBrushes.White, new XRect(228, 15, 200, 23));


             zz = MeasureString(popis2[9], new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal, font3.Size);
            gfx.DrawString(popis2[9], font3, XBrushes.Black, new XRect(254-(zz.Width-141)/2, 17, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(228, 53, 25, 25));
            gfx.DrawString(popis2[10], font1, XBrushes.Black, new XRect(233, 60, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(228, 70, 30, 17));
            gfx.DrawString(popis2[11], font1, XBrushes.Black, new XRect(233, 75, 0, 20), XStringFormats.TopLeft);
            if (popis2[47].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(278, 57, 70, 18));
                gfx.DrawString(popis2[47], font1c, XBrushes.Black, new XRect(294, 57, 0, 20), XStringFormats.TopLeft);
            }
            if (popis2[12].Length > 0)
            {
                gfx.DrawRectangle(XBrushes.White, new XRect(278, 75, 70, 12));
                gfx.DrawString(popis2[12], font1, XBrushes.Black, new XRect(294, 75, 0, 20), XStringFormats.TopLeft);
            }
           
            gfx.DrawRectangle(XBrushes.White, new XRect(96, 206+pomak, 80, 12));
            gfx.DrawString(popis2[13], fontb, XBrushes.Black, new XRect(96, 206 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(96, 336 + pomak, 80, 12));
            gfx.DrawString(popis2[14], fontb, XBrushes.Black, new XRect(96, 336 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(96, 362 + pomak, 85, 12));
            gfx.DrawString(popis2[15], fontb, XBrushes.Black, new XRect(96, 362 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(96, 491 + pomak, 80, 12));
            gfx.DrawString(popis2[16], fontb, XBrushes.Black, new XRect(96, 492 + pomak, 0, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.White, new XRect(98, 525 + pomak, 80, 11));
            gfx.DrawString(popis2[17], font1b, XBrushes.Black, new XRect(96, 525 + pomak, 0, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.White, new XRect(220, 525 + pomak, 55, 11));
            gfx.DrawString(popis2[18], font1b, XBrushes.Black, new XRect(218, 525 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(287, 525 + pomak, 60, 11));
            gfx.DrawString(popis2[19], font1b, XBrushes.Black, new XRect(285, 525 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(351, 525 + pomak, 60, 11));
            gfx.DrawString(popis2[20], font1b, XBrushes.Black, new XRect(353, 525 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(415, 525 + pomak, 85, 11));
            gfx.DrawString(popis2[21], font1b, XBrushes.Black, new XRect(414, 525 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(504, 525 + pomak, 55, 11));
            gfx.DrawString(popis2[22], font1b, XBrushes.Black, new XRect(505, 525 + pomak, 0, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.White, new XRect(220, 536 + pomak, 55, 11));
            gfx.DrawString(popis2[23], font1b, XBrushes.Black, new XRect(245, 536 + pomak, 0, 20), XStringFormats.TopCenter);
            gfx.DrawRectangle(XBrushes.White, new XRect(287, 536 + pomak, 60, 11));
            gfx.DrawString(popis2[24], font1b, XBrushes.Black, new XRect(316, 536 + pomak, 0, 20), XStringFormats.TopCenter);
            gfx.DrawRectangle(XBrushes.White, new XRect(351, 536 + pomak, 60, 11));
            gfx.DrawString(popis2[25], font1b, XBrushes.Black, new XRect(380, 536 + pomak, 0, 20), XStringFormats.TopCenter);
            gfx.DrawRectangle(XBrushes.White, new XRect(415, 536 + pomak, 85, 11));
            gfx.DrawString(popis2[26], font1b, XBrushes.Black, new XRect(455, 536 + pomak, 0, 20), XStringFormats.TopCenter);
            gfx.DrawRectangle(XBrushes.White, new XRect(504, 536 + pomak, 55, 11));
            gfx.DrawString(popis2[27], font1b, XBrushes.Black, new XRect(505, 536 + pomak, 0, 20), XStringFormats.TopCenter);

            gfx.DrawRectangle(XBrushes.White, new XRect(98, 551 + pomak, 70, 11));
            gfx.DrawString(popis2[28], font1, XBrushes.Black, new XRect(98, 551 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 566 + pomak, 70, 11));
            gfx.DrawString(popis2[29], font1, XBrushes.Black, new XRect(98, 566 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 583 + pomak, 70, 11));
            gfx.DrawString(popis2[30], font1, XBrushes.Black, new XRect(98, 583 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 598 + pomak, 70, 11));
            gfx.DrawString(popis2[31], font1, XBrushes.Black, new XRect(98, 598 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 614 + pomak, 70, 11));
            gfx.DrawString(popis2[32], font1, XBrushes.Black, new XRect(98, 614 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 629 + pomak, 80, 11));
            gfx.DrawString(popis2[33], font1, XBrushes.Black, new XRect(98, 630 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 644 + pomak, 75, 11));
            gfx.DrawString(popis2[34], font1, XBrushes.Black, new XRect(98, 646 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 661 + pomak, 70, 11));
            gfx.DrawString(popis2[35], font1, XBrushes.Black, new XRect(98, 661 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 676 + pomak, 70, 11));
            gfx.DrawString(popis2[36], font1, XBrushes.Black, new XRect(98, 676 + pomak, 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(98, 691 + pomak, 70, 11));
            //Console.WriteLine(popis2[37].Length);
            gfx.DrawString(popis2[37], font1, XBrushes.Black, new XRect(98, 691 + pomak, 0, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.White, new XRect(78, 733 , 450, 15));
            gfx.DrawString(popis2[38], font4, XBrushes.Black, new XRect(78, 733 , 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(78, 748 , 450, 13));
            gfx.DrawString(popis2[39], font4, XBrushes.Black, new XRect(78, 748 , 0, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.White, new XRect(72, 779 , 200, 28));
            gfx.DrawString(popis2[40] + " " + popis2[44], font1, XBrushes.Black, new XRect(72, 779 , 0, 20), XStringFormats.TopLeft);
            gfx.DrawString(new string(' ', popis2[40].Length + 1 + 7) + popis2[45], font1, XBrushes.Black, new XRect(72, 792 , 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(332, 779 , 220, 13));
            gfx.DrawString(popis2[41] + " " + popis2[46], font1, XBrushes.Black, new XRect(332, 779 , 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(70, 810 , 500, 9));
            gfx.DrawString(popis2[42], font5, XBrushes.Black, new XRect(71, 810 , 0, 20), XStringFormats.TopLeft);
            gfx.DrawRectangle(XBrushes.White, new XRect(70, 819 , 500, 11));
            gfx.DrawString(popis2[43], font5, XBrushes.Black, new XRect(71, 819.5 , 0, 20), XStringFormats.TopLeft);
            //}

            for (int i = 0; i < popis3.Length; i++)
            {
                if (popis3[i].Length > 0)
                {
                    //if (i >= 30 && i < 40)
                    //{
                    //    gfx.DrawRectangle(XBrushes.White, new XRect(220 + 67 * (i / 10) - 7, 551 + (15 * (i % 10) + (i % 10) / 4 * 3 - (i % 10) / 8), 44, 11));
                    //    gfx.DrawString(popis3[i], font1, XBrushes.Black, new XRect(245 + 67 * (i / 10) - 7, 551 + (15 * (i % 10) + (i % 10) / 4 * 3), 0, 20), XStringFormats.TopCenter);

                    //}
                    //else
                    //{
                    if (i >= 40) break;
                    gfx.DrawRectangle(XBrushes.White, new XRect(220 + 67 * (i / 10), 551 + (15 * (i % 10) + (i % 10) / 4 * 3 - (i % 10) / 8) + pomak, 50, 11));
                    gfx.DrawString(popis3[i], font1, XBrushes.Black, new XRect(245 + 67 * (i / 10) + (i / 30) * 10, 551 + (15 * (i % 10) + (i % 10) / 4 * 3) + pomak, 0, 20), XStringFormats.TopCenter);
                    //}
                }
                //gfx.DrawRectangle(XBrushes.White, new XRect(98, 566, 70, 11));
                //gfx.DrawString(popis2[29], font1, XBrushes.Black, new XRect(98, 566, 0, 20), XStringFormats.TopLeft);
            }

            //Console.WriteLine(PDFNewDoc.Pages[0].Contents.);
            //PDFNewDoc.Save(textBox9.Text);
            //Process.Start(textBox9.Text);

            //for (int index = 0; index < PDFDoc.Pages[0].Contents.Elements.Count; index++)
            //{
            PdfDictionary.PdfStream stream = PDFDoc.Pages[0].Contents.Elements.GetDictionary(0).Stream;
            string outputText = new PDFTextExtractor().ExtractTextFromPDFBytes(stream.Value);
            //break;

            //}
            outputText = outputText.Substring(0, outputText.IndexOf("Date"));
            int pom = 0;
            for (int i = 0; i < outputText.Length; i++)
            {
                if (outputText[i] > 47 && outputText[i] < 58) { pom = i; break; }
            }
            outputText = outputText.Substring(pom);
            PDFNewDoc.Save("Izv " + outputText.Replace('/', '_') + ".pdf");

            //Console.WriteLine(.Contents);

            Process.Start("Izv " + outputText.Replace('/', '_') + ".pdf");
        }


        private Size MeasureString(string candidate,FontFamily fontF,FontStyle fontS,FontWeight fontW,FontStretch fontSt,double fontSi)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(fontF, fontS, fontW, fontSt),
                fontSi,
                Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            konvertiraj();
        }

        private void konvertiraj(int pomak=0)
        {
            string[] popis2 = new string[48];
            popis2[0] = textBox1.Text;
            popis2[1] = textBox2.Text;
            popis2[2] = textBox3.Text;
            popis2[3] = textBox4.Text;
            popis2[4] = textBox5.Text;
            popis2[5] = textBox6.Text;
            popis2[6] = textBox7.Text;
            popis2[7] = textBox8.Text;
            popis2[8] = textBox16.Text;
            popis2[9] = textBox11.Text;
            popis2[10] = textBox12.Text;
            popis2[11] = textBox13.Text;
            popis2[12] = textBox15.Text;
            popis2[13] = textBox17.Text;
            popis2[14] = textBox18.Text;
            popis2[15] = textBox19.Text;
            popis2[16] = textBox20.Text;
            popis2[17] = textBox21.Text;
            popis2[18] = textBox22.Text;
            popis2[19] = textBox23.Text;
            popis2[20] = textBox24.Text;
            popis2[21] = textBox25.Text;
            popis2[22] = textBox26.Text;
            popis2[23] = textBox27.Text;
            popis2[24] = textBox28.Text;
            popis2[25] = textBox29.Text;
            popis2[26] = textBox30.Text;
            popis2[27] = textBox31.Text;
            popis2[28] = textBox32.Text;
            popis2[29] = textBox33.Text;
            popis2[30] = textBox34.Text;
            popis2[31] = textBox35.Text;
            popis2[32] = textBox36.Text;
            popis2[33] = textBox37.Text;
            popis2[34] = textBox38.Text;
            popis2[35] = textBox39.Text;
            popis2[36] = textBox40.Text;
            popis2[37] = textBox41.Text;
            popis2[38] = textBox42.Text;
            popis2[39] = textBox43.Text;
            popis2[40] = textBox44.Text;
            popis2[41] = textBox45.Text;
            popis2[42] = textBox46.Text;
            popis2[43] = textBox47.Text;
            popis2[44] = textBox48.Text;
            popis2[45] = textBox49.Text;
            popis2[46] = textBox50.Text;
            popis2[47] = textBox15a.Text;
            string[] popis3 = new string[50];

            int i = 1;
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Name == "Polje" + i) { popis3[i - 1] = tb.Text; i++; }

            }

            if (textBox9.Text.Length > 0)
                try
                {
                    nesto(popis2, popis3,pomak);
                }
                catch
                {
                    MessageBox.Show("Greška kod konvertiranja!");
                }
            else MessageBox.Show("Potrebno odabrat PDF datoteku!");
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF documents (.pdf)|*.pdf";

            dlg.RestoreDirectory = true;
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                textBox9.Text = filename;

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e) // dodaj
        {
            if (textBox10.Text.Length > 0)
            {
                int b = postoji(textBox10.Text);
                if (b != -1)
                {
                    spremi2b(b);
                }
                else
                {
                    spremib(textBox10.Text);
                }
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e) // briši
        {
            if (comboBox1.Text.Length > 0 && comboBox1.SelectedIndex != -1 && comboBox1.Text != "Standard")
            {
                string messageBoxText = "Sigurno želite izbrisati projekt:" + comboBox1.Text + "?";

                string caption = "Konverter";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            try
                            {
                                int b = postoji(comboBox1.Text);
                                brisi(b);
                            }
                            catch
                            {
                                MessageBox.Show("Neuspjeh");
                            }
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                            break;
                        }
                }

            }
        }

        private void brisi(int a)
        {
            db.Delete("Tablica", String.Format("Projekt = {0}", "\"" + popis[a] + "\""));
            popis.RemoveAt(a);
            comboBox1.ItemsSource = new ObservableCollection<string>(popis);

        }


        List<string> popis = new List<string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            boxovi = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox11, textBox12, textBox13, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, Polje21, Polje22, Polje23, Polje24, Polje25, Polje26, Polje27, Polje28, Polje29, Polje30 };
            //db = new SQLiteDatabase();
            //String query = "create table Tablica (Projekt varchar(20), textBox1 varchar(50), textBox2 varchar(50), textBox3 varchar(50), textBox4 varchar(50), textBox5 varchar(50), textBox6 varchar(50), textBox7 varchar(50), textBox8 varchar(50), textBox11 varchar(50), textBox12 varchar(50), textBox13 varchar(50), textBox15 varchar(50), textBox16 varchar(50), textBox17 varchar(50), textBox18 varchar(50), textBox19 varchar(50), textBox20 varchar(50), textBox21 varchar(50), textBox22 varchar(50), textBox23 varchar(50), textBox24 varchar(50), textBox25 varchar(50), textBox26 varchar(50), textBox27 varchar(50), textBox28 varchar(50), textBox29 varchar(50), textBox30 varchar(50), textBox31 varchar(50), textBox32 varchar(50), textBox33 varchar(50), textBox34 varchar(50), textBox35 varchar(50), textBox36 varchar(50), textBox37 varchar(50), textBox38 varchar(50), textBox39 varchar(50), textBox40 varchar(50), textBox41 varchar(50), textBox42 TEXT, textBox43 TEXT, textBox44 varchar(50), textBox45 varchar(50), textBox46 TEXT, textBox47 TEXT)";
            //db.ExecuteNonQuery(query);
            try
            {
                db = new SQLiteDatabase();
                DataTable recipe;
                String query = "select Projekt from Tablica;";
                recipe = db.GetDataTable(query);
                // The results can be directly applied to a DataGridView control
                //recipeDataGrid.DataSource = recipe;

                // Or looped through for some other reason
                foreach (DataRow r in recipe.Rows)
                {
                    //MessageBox.Show(r["Projekt"].ToString());
                    //MessageBox.Show(r["Date"].ToString());


                    popis.Add(r["Projekt"].ToString());
                }


            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                //this.Close();
            }
            comboBox1.ItemsSource = new ObservableCollection<string>(popis);
        }


        private void spremib(string s)
        {
            //SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, String> data = new Dictionary<String, String>();

            data.Add("Projekt", s);
            foreach (TextBox t in boxovi)
            {
                data.Add(t.Name.ToString(), t.Text.Replace("'", "''"));
            }
            try
            {
                db.Insert("Tablica", data);
                popis.Add(s);
                comboBox1.ItemsSource = new ObservableCollection<string>(popis);
                comboBox1.SelectedItem = s;
                MessageBox.Show("Uspješno spremljeno!");
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }



        }

        private void spremi2b(int i)
        {


            Dictionary<String, String> data = new Dictionary<String, String>();
            //DataTable rows;


            foreach (TextBox t in boxovi)
            {
                data.Add(t.Name.ToString(), t.Text.Replace("'", "''"));
            }



            try
            {
                db.Update("Tablica", data, String.Format("Projekt = {0}", "\"" + popis[i] + "\""));
                MessageBox.Show("Uspješno spremljeno!");
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }







        }

        private void comboT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {

                try
                {

                    DataTable recipe;
                    String query = "select * from Tablica WHERE (Projekt = \"" + comboBox1.Text + "\")";
                    recipe = db.GetDataTable(query);
                    // The results can be directly applied to a DataGridView control
                    //recipeDataGrid.DataSource = recipe;

                    // Or looped through for some other reason
                    foreach (DataRow r in recipe.Rows)
                    {

                        foreach (TextBox t in boxovi)
                        {
                            t.Text = r[t.Name.ToString()].ToString();
                        }

                    }


                }
                catch (Exception fail)
                {
                    String error = "The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n\n";
                    MessageBox.Show(error);
                    this.Close();
                }


            }
        }

        private int postoji(string a)
        {
            int i = 0;
            foreach (string s in popis)
            {
                if (s == a)
                {

                    return i;

                }
                i++;

            }

            return -1;
        }

        private void button1a_Click(object sender, RoutedEventArgs e)
        {
            konvertiraj(11);
        }

        private double pretvori(object b)
        {
            double rezultat;
            string a = b.ToString();
            bool isNum = double.TryParse(a, NumberStyles.Any, CultureInfo.InvariantCulture, out rezultat);

            if (isNum)
                rezultat = double.Parse(a.Replace(",", "."), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-us"));
            else
                rezultat = 0;

            return rezultat;
        }

    }
}
