namespace Model_Classes
{
    public interface FileReader
    {
        public String[] readFile(String fileName);
        public void display(String[] fileContent);
    }

    public interface FileWriter
    {
        public void writeFile(String fileName, String content);
    }

    //Implementation
    public class FileReaderImpl : FileReader
    {
        public String[] readFile(String fileName)
        {
            String[] content;
            String filePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, fileName);

            if (File.Exists(filePath))
            {
                content = File.ReadAllLines(filePath);
            }
            else
            {
                Console.WriteLine("ERROR: File not found");
                content = new String[0];
            }

            return content;
        }

        public void display(String[] fileContent)
        {
            foreach (String line in fileContent)
            {
                Console.WriteLine(line);
            }
        }
    }

    public class FileWriterImpl : FileWriter
    {
        public void writeFile(String fileName, String content)
        {
            String filePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, fileName);
            File.WriteAllText(filePath, content);
        }
    }

    public class GradeCalculator
    {
        private String[] fileContent;

        public GradeCalculator()
        {
            fileContent = new String[0];
        }

        public GradeCalculator(String[] fileContent)
        {
            this.fileContent = fileContent;
        }

        public String calculate()
        {
            String outputContent = "";

            foreach (String line in fileContent)
            {
                String[] studentScore = line.Split(",");
                int score = 0;
                for(int i = 2; i < studentScore.Length; i++)
                {
                    score += Int32.Parse(studentScore[i]);
                }
                score /= 10;

                outputContent += line + "," + score + "," + calculateGrade(score) + System.Environment.NewLine;
            }

            return outputContent.Trim();
        }

        private String calculateGrade(int score)
        {
            if (90 <= score && score <= 100) return "A";
            else if (80 <= score && score < 90) return "B";
            else if (70 <= score && score < 80) return "C";
            else if (60 <= score && score < 70) return "D";
            else if (0 <= score && score < 60) return "F";

            return null;
        }
    }
}
