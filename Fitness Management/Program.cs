using Fitness_Management.Class_Management;
using Fitness_Management.Models;
using Fitness_Management.Booking_Management;
using Fitness_Management.Reports;
class Program
{   
    public static void Main()
    {
        DataStorage dataStorage = new DataStorage();
        WorkoutClass workoutClass = new WorkoutClass();
        BookingManagement classBook = new BookingManagement();
        SimpleReport report = new SimpleReport();

        bool execute = true;
        while (execute)
        {
            string[] operations = { "1. Add a class", "2. View all available classes", "3. Update capacity of a class",
            "4. Book a class", "5. Cancel a booking", "6. Available classes", "7. View Active Bookings",
            "8. View most popular class", "9. Booking rate per class", "10. Exit"};
            foreach (string operation in operations)
            {
                Console.WriteLine(operation);
            }
            Console.Write($"Select from the above options (1-{operations.Length}): ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    workoutClass.RegisterClass(dataStorage.classBio);
                    break;
                case 2:
                    workoutClass.ViewClasses(dataStorage.classBio);
                    break;
                case 3:
                    workoutClass.UpdateClassCapacity(dataStorage.classBio);
                    break;
                case 4:
                    classBook.BookClass(dataStorage.classBio, dataStorage.bookings);
                    break;
                case 5:
                    classBook.CancelBooking(dataStorage.classBio, dataStorage.bookings);
                    break;
                case 6:
                    workoutClass.AvailableClasses(dataStorage.classBio);
                    break;
                case 7:
                    classBook.ActiveBookings(dataStorage.classBio, dataStorage.bookings);
                    break;
                case 8:
                    report.PopularClass(dataStorage.classBio, dataStorage.bookings);
                    break;
                case 9:
                    report.BookingRatePerClass(dataStorage.classBio, dataStorage.bookings);
                    break;
                case 10:
                    execute = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}