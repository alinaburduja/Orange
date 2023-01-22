using System;
using System.Collections.Generic;

namespace Orange.Data.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public int ExternalId { get; set; }
        public List<Genre> Genres { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
