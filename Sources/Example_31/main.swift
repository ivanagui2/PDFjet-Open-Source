import Foundation
import PDFjet


/**
 *  Example_31.swift
 *
 */
public class Example_31 {

    public init() throws {

        if let stream = OutputStream(toFileAtPath: "Example_31.pdf", append: false) {

            let pdf = PDF(stream)
            let page = Page(pdf, Letter.PORTRAIT)

            let f1 = try Font(
                    pdf,
                    InputStream(fileAtPath: "fonts/Noto/NotoSansDevanagari-Regular.ttf.stream")!,
                    Font.STREAM)
            f1.setSize(15.0)

            let f2 = try Font(
                    pdf,
                    InputStream(fileAtPath: "fonts/Droid/DroidSans.ttf.stream")!,
                    Font.STREAM)
            f2.setSize(15.0)

            let str = try String(contentsOfFile: "data/marathi.txt", encoding: .utf8)

            let textBox = TextBox(f1, str, 500.0, 300.0)
            textBox.setFallbackFont(f2)
            textBox.setLocation(50.0, 50.0)
            textBox.setNoBorders()
            textBox.drawOn(page)

            let textLine = TextLine(f1, "असम के बाद UP में भी CM कैंडिडेट का ऐलान करेगी BJP?")
            textLine.setFallbackFont(f2)
            textLine.setLocation(50.0, 175.0)
            textLine.drawOn(page)

            page.setPenColor(Color.blue)
            page.setBrushColor(Color.blue)
            page.fillRect(50.0, 200.0, 200.0, 200.0)

            let gs = GraphicsState()
            gs.set_CA(0.5)  // The stroking alpha constant
            gs.set_ca(0.5)  // The nonstroking alpha constant
            page.setGraphicsState(gs)

            page.setPenColor(Color.green)
            page.setBrushColor(Color.green)
            page.fillRect(100.0, 250.0, 200.0, 200.0)

            page.setPenColor(Color.red)
            page.setBrushColor(Color.red)
            page.fillRect(150, 300, 200.0, 200.0)

            // Reset the parameters to the default values
            page.setGraphicsState(GraphicsState())

            page.setPenColor(Color.orange)
            page.setBrushColor(Color.orange)
            page.fillRect(200, 350, 200.0, 200.0)

            page.setBrushColor(0x00003865)
            page.fillRect(50, 550, 200.0, 200.0)

            pdf.close()
        }
    }

}   // End of Example_31.swift

let time0 = Int64(Date().timeIntervalSince1970 * 1000)
_ = try Example_31()
let time1 = Int64(Date().timeIntervalSince1970 * 1000)
print("Example_31 => \(time1 - time0)")
