using System;

namespace Orange.Data.Entities
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Movie Movie { get; set; }
    }
}
