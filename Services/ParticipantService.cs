using EstalBook.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EstalBook.Services
{
    public class ParticipantService
    {
        private ApplicationContext _context;

        public ParticipantService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> GetRandomPairAsync(int sex)
        {
            var participants = new List<Participant>();
            var random = new Random();

            // Get a random participant with the specified sex
            var participant = await Task.Run(() => GetRandomParticipantAsync(sex));
            if (participant == null)
            {
                return (null);
            }
            participants.Add(participant);

            // Get another random participant with the same sex
            var otherParticipant = await Task.Run(() => GetRandomParticipantAsync(sex));
            while (otherParticipant == null || otherParticipant == participant)
            {
                otherParticipant = await Task.Run(() => GetRandomParticipantAsync(sex));
            }
            participants.Add(otherParticipant);

            // Shuffle the list of participants and return the first two
            participants = participants.OrderBy(p => random.Next()).ToList();
            return participants;
        }

        public async Task<Participant> GetRandomParticipantAsync(int sex)
        {
            var participants = _context.Participants.Where(p => p.Sex == sex).ToList();

            if (participants.Count == 0)
            {
                return null;
            }

            var randomIndex = new Random().Next(participants.Count);
            return participants[randomIndex];
        }

        //public async void IncreaseRating(int id)
        //{
        //    //Participant participant = _context.Participants.Where(p => p.Id == id).FirstOrDefault();
        //    //participant.Rating++;
        //    var participant = await _context.Participants.FindAsync(id);

        //    if (participant != null)
        //    {
        //        participant.Rating++;
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
