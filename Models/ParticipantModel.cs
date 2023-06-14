namespace EstalBook.Models
{
    public class ParticipantModel
    {
        public int Rating { get;private set; } 
        public string ImagePath { get; private set; }

        public ParticipantModel()
        {
            Rating = 0;
            ImagePath = "";
        }

        public void IncrementRating()
        {
            Rating++;
        }

        public void SetRating(int rating)
        {
            Rating = rating;
        }

        public void SetImagePath(string path)
        {
            ImagePath = path;
        }
    }
}
