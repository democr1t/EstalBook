//using FindTheFifth.Fabriques;
//using FindTheFifth.Models;
using EstalBook.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FindTheFifth.Services
{
    public class CacheService
    {
        private IMemoryCache _cache;
        private string _participantsKey;

        public CacheService(IMemoryCache cache)
        {
            _participantsKey = "participants";
            _cache = cache;
        }

        public void SetInParticipants(ParticipantModel participant)
        {
            List<ParticipantModel> participants = GetParticipants();

            participants.Add(participant);

            _cache.Set(_participantsKey, participants);
        }

        public List<ParticipantModel> GetParticipants()
        {
            List<ParticipantModel> participants = new List<ParticipantModel>();

            _cache.TryGetValue(_participantsKey, out participants);

            return participants;
        }
    }
}
