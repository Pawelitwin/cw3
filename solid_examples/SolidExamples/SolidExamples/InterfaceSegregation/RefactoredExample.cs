namespace SolidExamples.InterfaceSegregation;

public interface IDocumentOperations
{
    void SaveDocument(string content);
    string ReadDocument(int id);
    void PrintDocument(int id);
}

public interface IImageOperations
{
    void SaveImage(byte[] image);
    byte[] ReadImage(int id);
    void PrintImage(int id);
}

public class DocumentManager : IDocumentOperations
{
    public void SaveDocument(string content) { /* Implementation */ }
    public string ReadDocument(int id) { /* Implementation */ return ""; }
    public void PrintDocument(int id) { /* Implementation */ }
}

public class ImageManager : IImageOperations
{
    public void SaveImage(byte[] image) { /* Implementation */ }
    public byte[] ReadImage(int id) { /* Implementation */ return new byte[0]; }
    public void PrintImage(int id) { /* Implementation */ }
}