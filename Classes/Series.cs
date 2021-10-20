namespace SeriesRegistration.app
{
    public class Series : BaseEntity
    {
        private Genre Genre {get; set;}

        private string Title {get; set;}

        private string Description {get; set;}

        private int Year {get; set;}

        private bool Excluded {get; set;}


        public Series(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string back = "";
            back += "Genre: " + this.Genre + "\r\n";
            back += "Title: " + this.Title + "\r\n";
            back += "Description: " + this.Description + "\r\n";
            back += "Releasing Year: " + this.Year + "\r\n";
            back += "Excluded: " + this.Excluded;
            return back;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnExcluded()
        {
            return this.Excluded;
        }

        public void Exclude()
        {
            this.Excluded = true;
        }
    }
}