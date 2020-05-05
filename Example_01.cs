using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using PDFjet.NET;


/**
 *  Example_01.cs
 *  We will draw the American flag using Box, Line and Point objects.
 */
public class Example_01 {

    public Example_01() {

        PDF pdf = new PDF(new BufferedStream(
                new FileStream("Example_01.pdf", FileMode.Create)));
        pdf.SetTitle("Hello");
        pdf.SetAuthor("Eugene");
        pdf.SetSubject("Example");
        pdf.SetKeywords("Hello World This is a test");
        pdf.SetCreator("Application Name");

        String fileName = "linux-logo.png";
        EmbeddedFile file1 = new EmbeddedFile(
                pdf,
                fileName,
                new FileStream("images/" + fileName, FileMode.Open, FileAccess.Read),
                false);     // Don't compress images.

        fileName = "Example_02.cs";
        EmbeddedFile file2 = new EmbeddedFile(
                pdf,
                fileName,
                new FileStream(fileName, FileMode.Open, FileAccess.Read),
                true);      // Compress text files.

        Page page = new Page(pdf, Letter.PORTRAIT);

        Box flag = new Box();
        flag.SetLocation(100.0f, 100.0f);
        flag.SetSize(190.0f, 100.0f);
        flag.SetColor(Color.white);
        flag.DrawOn(page);

        float[] xy = new float[] {0f, 0f};
        float sw = 7.69f;       // stripe width
        Line stripe = new Line(0.0f, sw/2, 190.0f, sw/2);
        stripe.SetWidth(sw);
        stripe.SetColor(Color.oldgloryred);
        for (int row = 0; row < 7; row++) {
            stripe.PlaceIn(flag, 0.0f, row * 2 * sw);
            xy = stripe.DrawOn(page);
        }

        Box union = new Box();
        union.SetSize(76.0f, 53.85f);
        union.SetColor(Color.oldgloryblue);
        union.SetFillShape(true);
        union.PlaceIn(flag, 0.0f, 0.0f);
        union.DrawOn(page);

        float h_si = 12.6f;    // horizontal star interval
        float v_si = 10.8f;    // vertical star interval
        Point star = new Point(h_si/2, v_si/2);
        star.SetShape(Point.STAR);
        star.SetRadius(3.0f);
        star.SetColor(Color.white);
        star.SetFillShape(true);

        for (int row = 0; row < 6; row++) {
            for (int col = 0; col < 5; col++) {
                star.PlaceIn(union, row * h_si, col * v_si);
                xy = star.DrawOn(page);
            }
        }

        star.SetLocation(h_si, v_si);
        for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 4; col++) {
                star.PlaceIn(union, row * h_si, col * v_si);
                star.DrawOn(page);
            }
        }

        FileAttachment attachment = new FileAttachment(pdf, file1);
        attachment.SetLocation(100f, 300f);
        attachment.SetIconPushPin();
        attachment.SetIconSize(24f);
        attachment.SetTitle("Attached File: " + file1.GetFileName());
        attachment.SetDescription(
                "Right mouse click or double click on the icon to save the attached file.");
        attachment.DrawOn(page);

        attachment = new FileAttachment(pdf, file2);
        attachment.SetLocation(200f, 300f);
        attachment.SetIconPaperclip();
        attachment.SetIconSize(24f);
        attachment.SetTitle("Attached File: " + file2.GetFileName());
        attachment.SetDescription(
                "Right mouse click or double click on the icon to save the attached file.");
        attachment.DrawOn(page);

        pdf.Close();
    }


    public static void Main(String[] args) {
        Stopwatch sw = Stopwatch.StartNew();
        long time0 = sw.ElapsedMilliseconds;
        new Example_01();
        long time1 = sw.ElapsedMilliseconds;
        sw.Stop();
        Console.WriteLine("Example_01 => " + (time1 - time0));
    }

}   // End of Example_01.cs
