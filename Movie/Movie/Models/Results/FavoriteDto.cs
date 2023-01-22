using System;

namespace Orange.Api.Models.Results
{
    public class FavoriteDto
    {
        public Guid Id { get; set; }
        public MovieDto Movie { get; set; }
    }
}
