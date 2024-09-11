using Extension;

namespace oraiFel0911
{
    internal class Program
    {
        public static bool IsValidSequence(string sequence)
        {

            Stack<char> stack = new();
            foreach (char bracket in sequence)
            {
                if (bracket == '(')
                {
                    stack.Push(bracket);
                }
                else if (bracket == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }

        public static int ValidSequences(string filename)
        {

            int count = 0;
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string sequence = line.Trim();
                    if (IsValidSequence(sequence))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            int result = ValidSequences(filename);
            int extensionResult = 0;
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1.feladat");
            Console.WriteLine($"{result} helyes szekvencia van");
            Console.WriteLine(new string('-', 40));
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string sequence = line.Trim();
                    if (sequence.IsValid())
                    {
                        extensionResult++;
                    }
                }
            }
            Console.WriteLine("2.feladat");
            Console.WriteLine($"{extensionResult} helyes szekvencia van");

            Console.WriteLine(new string('-',40));

            Console.WriteLine("3. feladat");

            string pathname = "people.csv";
            List<Person> people = new List<Person>();

            using (StreamReader reader = new StreamReader(pathname))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string firstName = parts[0];
                    string lastName = parts[1];
                    string id = parts[2];
                    int age = int.Parse(id.Split('-')[1]);

                    people.Add(new Person(firstName, lastName, age));
                }
            }

            Person legfiatalabb = people.OrderBy(p => p.Age).First();
            Person legidosebb = people.OrderByDescending(p => p.Age).First();

            double atlageletkor = people.Average(p => p.Age);

            Console.WriteLine($"Legfiatalabb személy: {legfiatalabb.FirstName} {legfiatalabb.LastName}, {legfiatalabb.Age} éves");
            Console.WriteLine(new string('-',3));
            Console.WriteLine($"Legidősebb személy: {legidosebb.FirstName} {legidosebb.LastName}, {legidosebb.Age} éves");
            Console.WriteLine(new string('-', 3));
            Console.WriteLine($"A fájlban szereplő személyek átlagos életkora: {atlageletkor:F2} év.");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("4.feladat");
            string peopleFilename = "people.csv";
            string dogsFilename = "dogs.csv";

            List<PeopleWithDogs> people2 = new List<PeopleWithDogs>();

            using (StreamReader reader = new StreamReader(peopleFilename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string firstName = parts[0];
                    string lastName = parts[1];
                    string id = parts[2];

                    people2.Add(new PeopleWithDogs(firstName, lastName, id));
                }
            }

            using (StreamReader reader = new StreamReader(dogsFilename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    string breed = parts[1];
                    string age = parts[2];
                    string ownerID = parts[3];
                    
                    Dog dog = new Dog(name, breed, age, ownerID);

                    PeopleWithDogs owner = people2.FirstOrDefault(p => p.ID == ownerID);
                    if (owner != null)
                    {
                        owner.Dogs.Add(dog);
                    }
                }
            }

            PeopleWithDogs legtobbKutya = people2.OrderByDescending(p => p.Dogs.Count).FirstOrDefault();

            Console.WriteLine($"A legtöbb kutyával rendelkező személy: {legtobbKutya.FirstName} {legtobbKutya.LastName} ({legtobbKutya.Dogs.Count} kutya)");

            Console.WriteLine(new string('-', 40));
        } 
  }
}



namespace Extension
{
    public static class StringExtension
    {
        public static bool IsValid(this string sequence)
        {
            Stack<char> stack = new();
            foreach (char bracket in sequence)
            {
                if (bracket == '(')
                {
                    stack.Push(bracket);
                }
                else if (bracket == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
