using Fitness_Management.Models;

namespace Fitness_Management.Reports
{
    class SimpleReport
    {
        public void PopularClass(Dictionary<int, ClassInfo> classBio, List<MemberInfo> bookings)
        {
            if(bookings.Count > 0)
            {
                var popularClass = bookings.GroupBy(b => b.ClassId).OrderByDescending(g => g.Count()).First();

                Console.WriteLine($"\nThe most popular class is {classBio[popularClass.Key].ClassName} wih a booking slots of {popularClass.Count()}\n");
            }
        }
        public void BookingRatePerClass(Dictionary<int, ClassInfo> classBio, List<MemberInfo> bookings)
        {
            if (bookings.Count > 0) 
            {
                var bookingRates = bookings.GroupBy(b=>b.ClassId);
                foreach(var bookingRate in bookingRates)
                {
                    var average = (bookingRate.Count()/(double)classBio[bookingRate.Key].MaxCapacity) * 100;
                    Console.WriteLine($"\nthe average booking of \"{classBio[bookingRate.Key].ClassName} is {average:F2}%\"\n");
                }
            }
            else
            {
                Console.WriteLine("\nThere is no active bookings right now\n");
            }
        }
    }
}