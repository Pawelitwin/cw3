public class Program
{
    public static void Main(string[] args)
    {
        double weight = ReadWeightFromUser();
        double height = ReadHeightFromUser();

        double bmi = CalculateBMI(weight, height);
        string bmiClassification = GetBMIClassiffication(bmi);
        
        Console.WriteLine($"Your BMI is: {bmi} ({bmi})");
    }

    public static double ReadWeightFromUser()
    {
        try
        {
            Console.WriteLine("Provide your weight (kg):");
            double weight = double.Parse(Console.ReadLine());

            return weight;
        }catch(Exception ex)
        {
            throw new ArgumentException("Invalid weight", ex);
        }
    }
    
    public static double ReadHeightFromUser()
    {
        try
        {
            Console.WriteLine("Provide your height (m):");
            double height = double.Parse(Console.ReadLine());

            return height;
        }catch(Exception ex)
        {
            throw new ArgumentException("Invalid height", ex);
        }
    }
    
    public static double CalculateBMI(double weight, double height)
    {
        if (weight <= 0 || height <= 0)
            throw new ArgumentException("Weight and height must be greater than 0");
        
        return Math.Round(weight / (height * height), 2);
    }

    public static string GetBMIClassiffication(double bmi)
    {
        if (bmi < 18.5)
            return "You are underweight";
        
        if (bmi >= 18.5 && bmi < 24.9)
            return "You are normal weight";

        if (bmi >= 25 && bmi < 29.9)
            return "You are overweight";
        
        return "You are much more overweight";
    }
}