using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KinderGarden.Core
{
    public class Parents
    {
        public int Id { get; set; }
        [Required]
        public string ImeTatko { get; set; }
        [Required]
        public string ImeMajka { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Municipality { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public List<Kid> kids { get; set; }
    }
}
