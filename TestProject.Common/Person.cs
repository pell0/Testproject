using System;

namespace TestProject.Common
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id} : {Name}";
        }
    }
}
