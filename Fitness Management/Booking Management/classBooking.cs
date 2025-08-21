using Fitness_Management.Models;
namespace Fitness_Management.Booking_Management
{
    class BookingManagement
    {
        public void BookClass(Dictionary<int, ClassInfo> classBio, List<MemberInfo> bookings)
        {
            if (classBio.Count > 0)
            {
                Console.WriteLine("\nBelow are the available classes with their available slots\n");
                foreach (var classData in classBio)
                {
                    Console.WriteLine($"{classData.Key}. {classData.Value.ClassName} | Availabile slots: {classData.Value.AvailableSlots}");
                }
                Console.Write("Select from the above options: ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (classBio.ContainsKey(option)){
                    if (classBio[option].AvailableSlots > 0)
                    {
                        Console.Write("Enter your name: ");
                        string memberName = Console.ReadLine();
                        var memberData = new MemberInfo
                        {
                            ClassId = option,
                            MemberName = memberName
                        };
                        bookings.Add(memberData);
                        --classBio[option].AvailableSlots;
                        Console.WriteLine($"\"{memberName}\" has booked a slot in \"{classBio[option].ClassName}\" class\n");
                    }
                    else
                    {
                        Console.WriteLine("\n****Unfortunately all the slots have been booked****\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n****Invalid option****\n");
                }
            }
            else
            {
                Console.WriteLine("\n****No classes currently available****\n");
            }
        }
        public void CancelBooking(Dictionary<int, ClassInfo> classBio, List<MemberInfo> bookings)
        {
            if(bookings.Count > 0)
            {
                Console.Write("Enter you name: ");
                string name = Console.ReadLine();
                var removeMember = bookings.FirstOrDefault(m => m.MemberName == name);
                if (removeMember != null)
                {
                    ++classBio[removeMember.ClassId].AvailableSlots;
                    bookings.Remove(removeMember);
                    Console.WriteLine($"\n{name} has been removed from bookings\n");
                }
            }
        }
        public void ActiveBookings(Dictionary<int, ClassInfo> classBio, List<MemberInfo> bookings)
        {
            if(bookings.Count > 0)
            {
                Console.WriteLine();
                foreach(var member in bookings)
                {
                    int classId = member.ClassId;
                    Console.WriteLine($"\"{member.MemberName}\" has booked for \"{classBio[classId].ClassName}\"");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("****No active bookings found****");
            }
        }
    }
}
