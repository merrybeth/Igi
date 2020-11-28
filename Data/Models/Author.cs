using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Author
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string DateOfBirth { set; get; }
        public string DateOfDeath { set; get; }
        public string LifeDescription { set; get; }
    }
}