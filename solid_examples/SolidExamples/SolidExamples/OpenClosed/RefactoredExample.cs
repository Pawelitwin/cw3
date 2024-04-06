namespace SolidExamples.OpenClosed.Refactored;

public interface IDocumentProcessor
{
    string DocumentType { get; }
    void Process(Document document);
}

public class WordProcessor : IDocumentProcessor
{
    public string DocumentType => "Word";

    public void Process(Document document)
    {
        Console.WriteLine("Processing Word document.");
    }
}

public class PdfProcessor : IDocumentProcessor
{
    public string DocumentType => "PDF";

    public void Process(Document document)
    {
        Console.WriteLine("Processing PDF document.");
    }
}

public class DocumentProcessor
{
    private readonly List<IDocumentProcessor> _processors;

    public DocumentProcessor(List<IDocumentProcessor> processors)
    {
        _processors = processors;
    }

    public void ProcessDocument(Document document)
    {
        var processor = _processors.FirstOrDefault(p => p.DocumentType == document.Type);
        processor?.Process(document);
    }
}