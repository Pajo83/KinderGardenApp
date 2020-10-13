using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KinderGarden.Core
{
   public class Group
   {
        public int Id { get; set; }
        [Required]
        public GroupType? Type { get; set; }
        public string Name { get; set; }
        public List<Kid> kids { get; set; }
        public Kindergardens Kindergarden { get; set; }
        public int KindergardenId { get; set; }
        
    }
}
