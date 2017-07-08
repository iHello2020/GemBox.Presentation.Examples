using System;
using GemBox.Presentation;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        PresentationDocument presentation = new PresentationDocument();

        // Create new presentation slide.
        Slide slide = presentation.Slides.AddNew(SlideLayoutType.Custom);

        // Create first text box.
        TextBox textBox = slide.Content.AddTextBox(ShapeGeometryType.RoundedRectangle, 2, 2, 8, 8, LengthUnit.Centimeter);

        // Set shape outline format.
        textBox.Shape.Format.Outline.Fill.SetSolid(Color.FromName(ColorName.DarkGray));

        // Create first paragraph with single run element.
        TextRun run = textBox.AddParagraph().AddRun("Shows how to use text boxes with GemBox.Presentation component.");
        run.Format.Bold = true;

        // Create empty paragraph.
        textBox.AddParagraph();

        // Create (mixed-element) paragraph.
        TextParagraph paragraph = textBox.AddParagraph();

        // Create and add a run element.
        run = paragraph.AddRun("Today's date: ");

        // Create and add a "DateTime" text field element.
        TextField field = paragraph.AddField(TextFieldType.DateTime);

        // Create empty paragraph.
        textBox.AddParagraph();

        // Create (multi-line) paragraph.
        paragraph = textBox.AddParagraph();

        // Create and add a first run element.
        run = paragraph.AddRun("This is a ...");

        // Create and add a line break element.
        TextLineBreak lb = paragraph.AddLineBreak();

        // Create and add a second run element.
        run = paragraph.AddRun("... multi-line paragraph.");

        // Create second text box.
        textBox = slide.Content.AddTextBox(ShapeGeometryType.RoundedRectangle, 12, 2, 8, 4, LengthUnit.Centimeter);

        // Set shape outline format.
        textBox.Shape.Format.Outline.Fill.SetSolid(Color.FromName(ColorName.DarkGray));

        // Create a list.
        paragraph = textBox.AddParagraph();
        run = paragraph.AddRun("This is a paragraph list:");

        paragraph = textBox.AddParagraph();
        paragraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        run = paragraph.AddRun("First list item");

        paragraph = textBox.AddParagraph();
        paragraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        run = paragraph.AddRun("Second list item");

        paragraph = textBox.AddParagraph();
        paragraph.Format.List.NumberType = ListNumberType.DecimalPeriod;
        run = paragraph.AddRun("Third list item");

        presentation.Save("Text Boxes.pptx");
    }
}
