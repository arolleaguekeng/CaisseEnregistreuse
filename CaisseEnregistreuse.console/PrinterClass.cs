using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System;

namespace CaisseEnregistreuse.console
{
    public class PrinterClass
    {
        private StreamReader streamToPrint;
        private Font printFont;


        public void PrintDoc(string file)
        {
            streamToPrint = new StreamReader
                  (file);
            try
            {
                printFont = new Font("Arial", 10);
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler
                   (this.Pd_PrintPage);
                pd.Print();
                Console.WriteLine("Printing start");
            }
            finally
            {
                streamToPrint.Close();
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }


    }
}