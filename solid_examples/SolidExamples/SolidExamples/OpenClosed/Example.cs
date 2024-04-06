namespace SolidExamples.OpenClosed;

public class Document
{
    public string Content { get; set; }
    public string Type { get; set; }
}

public class DocumentProcessor
{
    public void ProcessDocument(Document document)
    {
        if (document.Type == "Word")
        {
            Console.WriteLine("Processing Word document.");
        }
        else if (document.Type == "PDF")
        {
            Console.WriteLine("Processing PDF document.");
        }
        // New document types require this method to be modified
    }
}