using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarden.Core
{
    public class Kindergardens
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Group> groups { get; set; }
        
    }
}
