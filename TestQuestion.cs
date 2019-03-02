using System;
using System.IO;

namespace Test
{ 
	public class IllegalOperandsException : Exception
    {
        public IllegalOperandsException()
        {

        }

        public IllegalOperandsException(string message) : base(message)
        {

        }
    }

    public class IllegalInstructionException : Exception
    {
        public IllegalInstructionException()
        {

        }

        public IllegalInstructionException(string message) : base(message)
        {
           
        }
    }

    public class IllegalOperatorException : Exception
    {
        public IllegalOperatorException()
        {

        }

        public IllegalOperatorException(string message) : base(message)
        {

        }
    }
    public class FilePath
    {
        string inputPath,sourcePath,destinationPath,inputFileName;
		int firstNumber,secondNumber,values;
		bool isDone;
        public void GetAllFiles()
        {
            try
            {
                Console.WriteLine("Enter Path Directory.");
                inputPath = Console.ReadLine();
                DirectoryInfo DirectoryInWhichToSearch = new DirectoryInfo(@inputPath);

                FileInfo[] filesInDir = DirectoryInWhichToSearch.GetFiles("quest" + "*.txt*");
                if (filesInDir.Length > 0)
                {
                    Console.WriteLine("The files are:\n");
                    foreach (FileInfo foundFile in filesInDir)
                    {
                        string fullName = foundFile.Name;
                        Console.WriteLine(fullName);
                    }
                    PerformOperation();
                }
                else
                    Console.WriteLine("There are no files.");

            }
            catch (Exception e)
            {
                Console.WriteLine("No such Directory Found.");
            }
        }
		
        public void PerformOperation()
        {
            Console.WriteLine("Enter the file name on which you want to perform operation.");
            try
            {
                inputFileName = Console.ReadLine();
                DirectoryInfo DirectoryInWhichToSearch = new DirectoryInfo(@inputPath);
                FileInfo[] filesInDir = DirectoryInWhichToSearch.GetFiles("quest" + "*"+".txt*");
               
                foreach (FileInfo files in filesInDir)
                {
                    if (files.Name==inputFileName)
                    {
                        isDone = true;
                        sourcePath = "solved_" + inputFileName;
                        @destinationPath = System.IO.Path.Combine(@inputPath, @sourcePath);
                        File.Create(@destinationPath).Dispose();
                        Console.WriteLine("The solution fle is stored with file name {0}", sourcePath);
						
						Operation();
                    }
                }
                if(!isDone)
                {
                    Console.WriteLine("Wrong File Name");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No such file exists.");
            }
        }

        public void Operation()
        {
            bool isValid = false;
            string s = File.ReadAllText(@destinationPath);
            string[] words = s.Split(' ');

            if(words.Length<2)
            {
                try
                {
                    throw new IllegalInstructionException("INVALID INSTRUCTION");
                }
                catch (IllegalInstructionException ex)
                {
                    isValid = true;
                    File.AppendAllText(@destinationPath, ex.Message + Environment.NewLine);
                }
            }
            for (int i = 0; i < words.Length; i += 2)
            {
                bool isDone = Int32.TryParse(words[i], out values);
                if (!isDone)
                {
                    try
                    {
                        throw new IllegalOperandsException("INVALID OPERRAND");
                    }
                    catch (IllegalOperandsException ex)
                    {
                        isValid = true;
                        File.AppendAllText(@destinationPath, ex.Message + Environment.NewLine);
                    }
                 }
            }

            for(int i=1;i<words.Length;i+=2)
            {
                if (words[i] == "+" || words[i] == "-" || words[i] == "*" || words[i] == "/" || words[i] == "%")
                { }
                else
                {
                    try
                    {
                        throw new IllegalOperatorException("INVALID OPERATOR");
                    }
                    catch (IllegalOperatorException ex)
                    {
                        isValid = true;
                        File.AppendAllText(@destinationPath, ex.Message + Environment.NewLine);
                    }
                }
            }

            if(isValid==false)
            {
                Int32.TryParse(words[0], out firstNumber);
                Int32.TryParse(words[2], out secondNumber);
                string operand= words[1];
                switch (operand)
                {
                    case "+" :
                        File.AppendAllText(@destinationPath, firstNumber + secondNumber + Environment.NewLine);
                        break;

                    case "-":
                        File.AppendAllText(@destinationPath, firstNumber - secondNumber + Environment.NewLine);
                        break;

                    case "*":
                        File.AppendAllText(@destinationPath, firstNumber * secondNumber + Environment.NewLine);
                        break;

                    case "%":
                        File.AppendAllText(@destinationPath, firstNumber % secondNumber + Environment.NewLine);
                        break;

                    case "/":
                        File.AppendAllText(@destinationPath, firstNumber / secondNumber + Environment.NewLine);
                        break;
                }
               
            }
        }

        public static void Main()
        {
            FilePath fp = new FilePath();
            fp.GetAllFiles();
        }
    }
}
