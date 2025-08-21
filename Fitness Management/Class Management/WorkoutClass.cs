using Fitness_Management.Models;
namespace Fitness_Management.Class_Management
{
    class WorkoutClass
    {
        public void RegisterClass(Dictionary<int, ClassInfo> classBio)
        {
            int classId = 1;
            bool addMore = true;
            while (addMore)
            {
                Console.Write("Enter a class name: ");
                string className = Console.ReadLine();

                Console.Write("Enter Trainer name: ");
                string trainer = Console.ReadLine();

                Console.Write("Enter MaxCapacity of the class: ");
                int maxCapacity = Convert.ToInt32(Console.ReadLine());

                var classData = new ClassInfo
                {
                    ClassName = className,
                    Trainer = trainer,
                    MaxCapacity = maxCapacity,
                    AvailableSlots = maxCapacity
                };
                classBio[classId++] = classData;
                Console.Write("Add another class? (y/n): ");
                addMore = Console.ReadLine()?.ToLower() == "y";
            }
        }
        public void ViewClasses(Dictionary<int, ClassInfo> classBio)
        {
            if(classBio.Count > 0)
            {
                Console.WriteLine("\nBelow are the available classes with their available slots\n");
                foreach(var classData in classBio)
                {
                    Console.WriteLine($"Class Name: {classData.Value.ClassName} | Availabile slots: {classData.Value.AvailableSlots}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n****No classes currently available****\n");
            }
        }
        public void UpdateClassCapacity(Dictionary<int, ClassInfo> classBio)
        {
            if(classBio.Count > 0 )
            {
                int id = 1;
                foreach (var classData in classBio)
                {
                    Console.WriteLine($"{id++}. {classData.Value.ClassName} => Capacity: {classData.Value.MaxCapacity}");
                }
                Console.Write($"Enter Class to update (1-{classBio.Count}): ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (classBio.ContainsKey(option))
                {
                    Console.Write("Enter Max Capacity: ");
                    classBio[option].MaxCapacity = Convert.ToInt32(Console.ReadLine());
                    classBio[option].AvailableSlots = classBio[option].MaxCapacity;
                    Console.WriteLine($"Max Capacity for the class \"{classBio[option].ClassName}\" is now updated");
                    Console.WriteLine($"Max Capacity for the class \"{classBio[option].ClassName}\" is {classBio[option].MaxCapacity}");
                }
                else
                {
                    Console.WriteLine("\n****Invalid Option****\n");
                }
            }
            else
            {
                Console.WriteLine("\n****No classes currently available to update its capacity****\n");
            }
        }
        public void AvailableClasses(Dictionary<int, ClassInfo> classBio)
        {
            if (classBio.Count > 0)
            {
                var availableClasses = classBio.Where(c => c.Value.AvailableSlots > 0).ToList();

                if (availableClasses.Count > 0 )
                {
                    foreach (var classData in availableClasses)
                    {
                        Console.WriteLine($"Class Name: {classData.Value.ClassName} | available slots => {classData.Value.AvailableSlots}");
                    }
                }
                else
                {
                    Console.WriteLine("\n****available classes found but unfortunately no slots have been found****\n");
                }
            }
            else
            {
                Console.WriteLine("\n****No available classes found****\n");
            }
        }
    }
}