using System;
using System.IO;
using GemBox.Presentation;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        PresentationDocument presentation = PresentationDocument.Load("CloneDestination.pptx");

        string pathToFileDirectory = "Resources";

        var sourcePresentation = PresentationDocument.Load(Path.Combine(pathToFileDirectory, "CloneSource.pptx"));

        // Use context so that references between 
        // shapes and slides are maintained between all cloning operations.
        var context = CloneContext.Create(sourcePresentation, presentation);

        // Clone all drawings from the first slide of another presentation 
        // into the first slide of the current presentation.
        foreach (var drawing in sourcePresentation.Slides[0].Content.Drawings)
            presentation.Slides[0].Content.Drawings.AddClone(drawing, context);

        // Establish explicit mapping between slides so that 
        // hyperlink on the second slide is correctly cloned.
        context.Set(sourcePresentation.Slides[0], presentation.Slides[0]);

        // Clone the second slide from another presentation.
        presentation.Slides.AddClone(sourcePresentation.Slides[1], context);

        presentation.Save("Cloning.pptx");
    }
}
