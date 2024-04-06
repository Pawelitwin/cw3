namespace SampleAppRefactoredUnitTests;

public class UnitTest1
{
    [Fact]
    public void GetBMIClassiffication_Should_Return_You_Are_Underweight_For_BMI_15()
    {
        // Arrange
        double bmi = 15;
        
        // Act
        string result = Program.GetBMIClassiffication(bmi);
        
        // Assert
        Assert.Equal("You are underweight", result);
    }
    
    [Fact]
    public void GetBMIClassiffication_Should_Return_You_Are_Normal_Weight_For_BMI_20()
    {
        // Arrange
        double bmi = 20;
        
        // Act
        string result = Program.GetBMIClassiffication(bmi);
        
        // Assert
        Assert.Equal("You are normal weight", result);
    }
}