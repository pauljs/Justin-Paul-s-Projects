using System;
using System.IO;
using System.Collections;using System.Collections.Generic;
using System.Text;

using PDFjet.NET;


/**
 *  Example_04.cs
 *
 *  The PDF generated by this example program will only work with Adobe Reader 8
 *  or Foxit Reader v2.0 or higher versions. It also requires the Asian Font Packs
 *  from Adobe or Foxit Software respectively.
 */
public class Example_04 {

    public Example_04() {

        String fileName = "data/happy-new-year.txt";

        FileStream fos = new FileStream("Example_04.pdf", FileMode.Create);
        BufferedStream bos = new BufferedStream(fos);

        PDF pdf = new PDF(bos);
        pdf.setCompressor(Compressor.ORIGINAL_ZLIB);

        Font f1 = new Font(
                pdf,
                "AdobeMingStd-Light",       // Chinese (Traditional) font
                CodePage.UNICODE);
        Font f2 = new Font(
                pdf,
                "AdobeSongStd-Light",       // Chinese (Simplified) font
                CodePage.UNICODE);
        Font f3 = new Font(
                pdf,
                "KozMinProVI-Regular",      // Japanese font
                CodePage.UNICODE);
        Font f4 = new Font(
                pdf,
                "AdobeMyungjoStd-Medium",   // Korean font
                CodePage.UNICODE);

        Page page = new Page(pdf, Letter.PORTRAIT);

        f1.SetSize(14);
        f2.SetSize(14);
        f3.SetSize(14);
        f4.SetSize(14);

        double x_pos = 100.0;
        double y_pos = 20.0;
        StreamReader reader = new StreamReader(
                new FileStream(fileName, FileMode.Open));
        TextLine text = new TextLine(f1);
        String line = null;
        while ((line = reader.ReadLine()) != null) {
            if (line.IndexOf("Simplified") != -1) {
                text.SetFont(f2);
            } else if (line.IndexOf("Japanese") != -1) {
                text.SetFont(f3);
            } else if (line.IndexOf("Korean") != -1) {
                text.SetFont(f4);
            }
            text.SetText(line);
            text.SetPosition(x_pos, y_pos += 24);
            text.DrawOn(page);
        }
        reader.Close();

        pdf.Flush();
        bos.Close();
    }


    public static void Main(String[] args) {
        try {
            new Example_04();
        } catch (Exception e) {
            Console.WriteLine(e.StackTrace);
        }
    }

}   // End of Example_04.cs
