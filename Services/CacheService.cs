using EstalBook.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EstalBook.Services
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

        public void PutInParticipants(List<Participant> participants)
        {
            _cache.Set(_participantsKey, participants);
        }

        public List<Participant> GetParticipants()
        {
            List<Participant> participants = new List<Participant>();

            _cache.TryGetValue(_participantsKey, out participants);

            return participants;
        }
    }
}
