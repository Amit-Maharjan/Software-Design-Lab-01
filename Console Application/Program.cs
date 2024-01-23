using Model_Classes;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the name of the input file:");
        String inputFile = Console.ReadLine();
        Console.WriteLine("Enter the name of the output file:");
        String outputFile = Console.ReadLine();

        FileReader fileReader = new FileReaderImpl();
        String[] content = fileReader.readFile(inputFile);

        Console.WriteLine("----------Input Content----------");
        fileReader.display(content);

        GradeCalculator gradeCalculator = new GradeCalculator(content);
        String outputContent = gradeCalculator.calculate();
        
        FileWriter fileWriter = new FileWriterImpl();
        fileWriter.writeFile(outputFile, outputContent);
        
        Console.WriteLine("----------Output Content----------");
        fileReader.display(fileReader.readFile(outputFile));
    }
}
