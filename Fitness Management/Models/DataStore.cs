namespace Fitness_Management.Models
{
    class DataStorage
    {
        public Dictionary<int, ClassInfo> classBio = new();
        public List<MemberInfo> bookings = new List<MemberInfo>();
    }
}
