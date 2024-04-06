namespace SolidExamples.InterfaceSegregation;

public interface IContentManager
{
    void SaveDocument(string content);
    string ReadDocument(int id);
    void PrintDocument(int id);
    void SaveImage(byte[] image);
    byte[] ReadImage(int id);
    void PrintImage(int id);
}

public class DocumentManager : IContentManager
{
    public void SaveDocument(string content) { /* Implementation */ }
    public string ReadDocument(int id) { /* Implementation */ return ""; }
    public void PrintDocument(int id) { /* Implementation */ }
    // The following methods are irrelevant for documents but must be implemented
    public void SaveImage(byte[] image) { throw new NotImplementedException(); }
    public byte[] ReadImage(int id) { throw new NotImplementedException(); }
    public void PrintImage(int id) { throw new NotImplementedException(); }
}

public class ImageManager : IContentManager
{
    // The following methods are irrelevant for images but must be implemented
    public void SaveDocument(string content) { throw new NotImplementedException(); }
    public string ReadDocument(int id) { throw new NotImplementedException(); }
    public void PrintDocument(int id) { throw new NotImplementedException(); }
    // Relevant image methods
    public void SaveImage(byte[] image) { /* Implementation */ }
    public byte[] ReadImage(int id) { /* Implementation */ return new byte[0]; }
    public void PrintImage(int id) { /* Implementation */ }
}