using System;
using System.IO;
using GemBox.Presentation;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        PresentationDocument presentation = new PresentationDocument();

        string pathToResources = "Resources";

        // Create new slide.
        Slide slide = presentation.Slides.AddNew(SlideLayoutType.Custom);

        // Create a text box.
        TextBox textBox = slide.Content.AddTextBox(ShapeGeometryType.RoundedRectangle, 2, 2, 12, 4, LengthUnit.Centimeter);

        // Set shape fill and outline format.
        textBox.Shape.Format.Fill.SetSolid(Color.FromName(ColorName.OrangeRed));
        textBox.Shape.Format.Outline.Fill.SetSolid(Color.FromName(ColorName.Red));

        // Create a paragraph with single run element.
        TextRun run = textBox.AddParagraph().AddRun("Shows how to create and customize slide transitions using GemBox.Presentation API.");
        run.Format.Fill.SetSolid(Color.FromName(ColorName.White));
        run.Format.Bold = true;

        // Get slide transition information.
        SlideShowTransition transition = slide.Transition;

        // Set the transition type.
        transition.TransitionType = TransitionType.Fade;

        // Set the transition effect.
        transition.Effect = TransitionEffect.Smoothly;

        // Slide should advance automatically after 1 second.
        transition.AdvanceOnTime = true;
        transition.AdvanceAfterTime = 1000;

        // Slide should advance on mouse click.
        transition.AdvanceOnClick = true;

        // Set the transition speed.
        transition.Speed = TransitionSpeed.Slow;

        // Specify the sound to be played when the transition is activated.
        using (var stream = File.OpenRead(Path.Combine(pathToResources, "Applause.wav")))
            transition.PlaySound(stream);

        presentation.Save("SlideTransition.pptx");
    }
}
