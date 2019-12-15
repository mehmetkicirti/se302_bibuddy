using System.ComponentModel.DataAnnotations;
using BiBuddy.Entities.Abstract;

namespace BiBuddy.Entities.Concrete
{
    public class article:BaseEntity,IEntity
    {
        //Why we do not use DataAnnatotions => because it is a contradiction for Solid Principle S
        public string author{ get; set; }
        public string title { get; set; }
        public string journal { get; set; }
        public int? number { get; set; }
        public int? volume { get; set; }
        public string pages { get; set; }
        public string address { get; set; }
    }
}
