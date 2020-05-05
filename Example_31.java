import java.io.*;
import java.util.*;

import com.pdfjet.*;


/**
 *  Example_31.java
 *
 */
public class Example_31 {

    public Example_31() throws Exception {

        PDF pdf = new PDF(
                new BufferedOutputStream(
                        new FileOutputStream("Example_31.pdf")));

        Page page = new Page(pdf, Letter.PORTRAIT);

        Font f1 = new Font(pdf,
                getClass().getResourceAsStream("fonts/Noto/NotoSansDevanagari-Regular.ttf"));
        f1.setSize(15f);

        Font f2 = new Font(pdf,
                getClass().getResourceAsStream("fonts/Droid/DroidSans.ttf"));
        f2.setSize(15f);

        StringBuilder buf = new StringBuilder();
        BufferedReader reader = new BufferedReader(new InputStreamReader(
                new FileInputStream("data/marathi.txt"), "UTF-8"));
        String line = null;
        while ((line = reader.readLine()) != null) {
            buf.append(line + "\n");
        }
        reader.close();

        TextBox textBox = new TextBox(f1, buf.toString(), 500f, 300f);
        textBox.setFallbackFont(f2);
        textBox.setLocation(50f, 50f);
        textBox.setNoBorders();
        textBox.drawOn(page);

        String str = "असम के बाद UP में भी CM कैंडिडेट का ऐलान करेगी BJP?";
        TextLine textLine = new TextLine(f1, str);
        textLine.setFallbackFont(f2);
        textLine.setLocation(50f, 175f);
        textLine.drawOn(page);


        page.setPenColor(Color.blue);
        page.setBrushColor(Color.blue);
        page.fillRect(50f, 200f, 200f, 200f);

        GraphicsState gs = new GraphicsState();
        gs.set_CA(0.5f);    // The stroking alpha constant
        gs.set_ca(0.5f);    // The nonstroking alpha constant
        page.setGraphicsState(gs);

        page.setPenColor(Color.green);
        page.setBrushColor(Color.green);
        page.fillRect(100f, 250f, 200f, 200f);

        page.setPenColor(Color.red);
        page.setBrushColor(Color.red);
        page.fillRect(150, 300, 200f, 200f);

        // Reset the parameters to the default values
        page.setGraphicsState(new GraphicsState());

        page.setPenColor(Color.orange);
        page.setBrushColor(Color.orange);
        page.fillRect(200, 350, 200f, 200f);

        page.setBrushColor(0x00003865);
        page.fillRect(50, 550, 200f, 200f);

        pdf.close();
    }


    public static void main(String[] args) throws Exception {
        long t0 = System.currentTimeMillis();
        new Example_31();
        long t1 = System.currentTimeMillis();
        System.out.println("Example_31 => " + (t1 - t0));
    }

}   // End of Example_31.java
