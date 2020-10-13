using System;

namespace KinderGarden.Core
{
    public class Kid
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Age { get; set; }
        public Kindergardens Kindergarden { get; set; }
        public int? KindergardenId { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public Parents Parent { get; set;}
        public int? ParentId { get; set; }
        public DateTime AplicationDate { get; set; }
        public Statuses Status { get; set; }
    }
}
