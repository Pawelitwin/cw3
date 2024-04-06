public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Provide your weight (kg):");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Provide your height (m):");
            double height = double.Parse(Console.ReadLine());

            double bmi = Math.Round(weight / (height * height), 2);

            Console.WriteLine($"Your BMI is: {bmi}");
            if (bmi < 18.5)
                Console.WriteLine("You are underweight");
            else if (bmi >= 18.5 && bmi < 24.9)
                Console.WriteLine("You are normal weight");
            else if (bmi >= 25 && bmi < 29.9)
                Console.WriteLine("You are overweight");
            else
                Console.WriteLine("You are much more overweight");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}