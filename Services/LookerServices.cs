//using FindTheFifth.Models;
//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.Memory;

//namespace FindTheFifth.Services
//{
//    public class LookerServices
//    {
//        private IMemoryCache _cache;
//        public int Count { get; private set; }

//        public LookerServices(IMemoryCache cache)
//        {
//            _cache = cache;
//            Count = 0;
//            LookerModel looker1 = new LookerModel("nomistor", "gold");
//            LookerModel looker2 = new LookerModel("grimenick", "silver");
//            _cache.Set(looker1.Id, looker1);
//            _cache.Set(looker2.Id, looker2);
//        }

//        public LookerModel Get(int id)
//        {
//            LookerModel looker;

//            if (_cache.TryGetValue(id, out looker))
//                return looker;
//            else return null;
//        }

//        public void SetInCache(LookerModel looker)
//        {
//            _cache.Set(looker.Id, looker);
//            Count++;
//        }

//        public void DeleteFromCache(int id)
//        {
//            _cache.Remove(id);
//        }

//        public List<LookerModel> ReturnAll()
//        {
//            List<LookerModel> lookers = new List<LookerModel>();
//            LookerModel looker;
//            int count = 1;

//            while(Get(count) != null)
//            {
//                looker = Get(count);
//                lookers.Add(looker);
//                count++;
//                //Count++;
//            }

//            return lookers;
//        }
//    }
//}
