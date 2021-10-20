using System;

namespace SeriesRegistration.app
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        
        static void Main(string[] args)
        {
            
            string userOption = GetUserOption();

            while (userOption.ToUpper() !="X")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    
                    case "2":
                        InsertSeries();
                        break;

                    case "3":
                        AttSeries();
                        break;

                    case "4":
                        ExcludeSeries();
                        break;

                    case "5":
                        ViewSeries();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();        

                }
            
                userOption = GetUserOption(); 
            }
        
            Console.WriteLine("Thank you for using our services");
        }

        private static void ListSeries()
        {
            
            Console.WriteLine("List Series");

            var list = repository.List();
            
            if (list.Count == 0)
            {
                Console.WriteLine("No series registered");
                return;
            }

            foreach (var series in list)
            {
                var excluded = series.returnExcluded();

                Console.WriteLine("#ID {0}: - {1} *{2}*", series.returnId(), series.returnTitle(), 
                (excluded ? "Excluded" : ""));
            }
        }

        private static void InsertSeries()
        {
            
            Console.WriteLine("Insert a new series");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Enter a genre among the options above: ");
            int entryGenreName = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the series' name: ");
            string entryTitle = Console.ReadLine();

            Console.WriteLine("Type in the series' release date: ");
            int entryDate = int.Parse(Console.ReadLine());

            Console.WriteLine("Type in the series' description: ");
            string entryDescription = Console.ReadLine();

            Series newSeries = new Series(id: repository.NextId(),
            genre: (Genre)entryGenreName, 
            title: entryTitle, 
            year: entryDate, 
            description: entryDescription);

            repository.Insert(newSeries);
        
        }

        private static void AttSeries()
        {
            
            Console.WriteLine("Enter the series' ID");
            int SeriesIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Enter a genre among the options above: ");
            int entryGenreName = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the series' name: ");
            string entryTitle = Console.ReadLine();

            Console.WriteLine("Type in the series' release date: ");
            int entryDate = int.Parse(Console.ReadLine());

            Console.WriteLine("Type in the series' description: ");
            string entryDescription = Console.ReadLine();

            Series attSeries = new Series(id: SeriesIndex,
            genre: (Genre)entryGenreName, 
            title: entryTitle, 
            year: entryDate, 
            description: entryDescription);

            repository.Att(SeriesIndex, attSeries);
        
        }

        private static void ExcludeSeries()
        {
            
            Console.WriteLine("Enter the series' ID");
            int SeriesIndex = int.Parse(Console.ReadLine());

            repository.Exclude(SeriesIndex);
        
        }

        private static void ViewSeries()
        {
            
            Console.WriteLine("Enter the series' ID");
            int SeriesIndex = int.Parse(Console.ReadLine());

            var series = repository.ReturnPerId(SeriesIndex);

            Console.WriteLine(series);
        
        }

        private static string GetUserOption()
        {
            
            Console.WriteLine();
            Console.WriteLine("Welcome");
            Console.WriteLine("Select the desired option");

            Console.WriteLine("1. List series");
            Console.WriteLine("2. Insert new series");
            Console.WriteLine("3. Att series");
            Console.WriteLine("4. Exclude series");
            Console.WriteLine("5. View series");
            Console.WriteLine("C. Clean screen");
            Console.WriteLine("X. Quit");
            Console.WriteLine();

            string UserOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return UserOption;

        }
    }
}
