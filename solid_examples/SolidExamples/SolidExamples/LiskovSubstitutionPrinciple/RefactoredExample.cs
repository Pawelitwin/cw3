namespace SolidExamples.LiskovSubstitutionPrinciple;

public class Bird
{
}

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : Bird, IFlyingBird
{
    public void Fly()
    {
        Console.WriteLine("Sparrow flying.");
    }
}

public class Penguin : Bird
{
    // Penguin does not implement IFlyingBird, so it's not expected to fly
}