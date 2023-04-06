
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace mp1
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            //AddSampleData();
            //SaveToFile("C:\\Users\\s23249\\source\\repos\\MAS_mp1\\mp1\\Data\\cars.json");
            ReadFromFile();
            SaveToFile("C:\\Users\\s23249\\source\\repos\\MAS_mp1\\mp1\\Data\\wczytane.json");
        }
        static void SaveToFile(string path)
        {
            List<Car> cars = Car.CarsExtent;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            var jsonString = JsonSerializer.Serialize(cars,options);
            File.WriteAllText(path, jsonString);
        }
        static void AddSampleData ()
        {
            Insurance insurance1 = new Insurance { ExpirationDate = new DateTime(2024, 4, 1), InsuranceId = "ABC123" };
            Insurance insurance2 = new Insurance { ExpirationDate = new DateTime(2023, 6, 30), InsuranceId = "DEF456" };
            Insurance insurance3 = new Insurance { ExpirationDate = new DateTime(2025, 12, 31), InsuranceId = "GHI789" };


            List<string> car1Equipment = new List<string> { "AC", "Bluetooth", "Navigation" };
            Car car1 = new Car("1HGCM82633A004352", new DateTime(2003, 1, 1), 100000, 147, "petrol", "Accord", "Honda", car1Equipment, "A very reliable car");
            car1.Insurance = insurance1;

            List<string> car2Equipment = new List<string> { "Sunroof", "Leather seats", "Backup camera" };
            Car car2 = new Car("1G1YJ2D7XE5001062", new DateTime(2014, 5, 1), 50000, 335, "petrol", "Corvette", "Chevrolet", car2Equipment, "A sleek and sporty car");
            car2.Insurance = insurance2;

            List<string> car3Equipment = new List<string> { "Hybrid", "Apple CarPlay", "Lane departure warning" };
            Car car3 = new Car("JTDKB20U883325536", new DateTime(2008, 8, 1), 200000, 73, "hybrid", "Prius", "Toyota", car3Equipment, "A fuel-efficient car");
            car3.Insurance = insurance3;

        }
        static void ReadFromFile() 
        {
            string jsonString = File.ReadAllText("C:\\Users\\s23249\\source\\repos\\MAS_mp1\\mp1\\Data\\cars.json");

            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonString);
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
            
        }
    }

}