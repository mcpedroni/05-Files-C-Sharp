using System;
using System.IO;
using System.Globalization;

namespace Files {
    class Program {

        static void Main(string[] args) {

            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try {
                string[] lines = File.ReadAllLines(sourceFilePath);

                //return the directory of folder without file
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                //new path directory
                string targetFolderPath = sourceFolderPath + @"\out";
                //nem path file
                string targetFilePath = targetFolderPath + @"\summary.csv";
                //create directory
                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath)) {
                    foreach (string line in lines) {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.name + ", " + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }

            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
