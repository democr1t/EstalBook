namespace EstalBook.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        //public byte[]? ProfileImage { get; set; }

        public int Sex { get; set; }

        public string ProfileImage { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        public void IncrementRating()
        {
            Rating++;
        }

        public void SetRating(int rating)
        {
            Rating = rating;
        }

        //public void SetProfileImage(byte[] profileImage)
        //{
        //    ProfileImage = profileImage;
        //}
    }
}
