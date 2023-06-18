namespace EstalBook.Models
{
    public class Participant
    {
        public int Id { get; private set; }
        public int Rating { get;private set; }
        public byte[] ProfileImage { get; set; }

        //public Participant(int id,int rating, byte[] profileImage)
        //{
        //    Id = id;
        //    Rating = rating;
        //    ProfileImage = profileImage;
        //}

        public void IncrementRating()
        {
            Rating++;
        }

        public void SetRating(int rating)
        {
            Rating = rating;
        }

        public void SetProfileImage(byte[] profileImage)
        {
            ProfileImage = profileImage;
        }
    }
}
