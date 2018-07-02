using AdData;
using AdData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdServices
{
    public class AdService : IAdData
    {
        private AdContext _context;
        
        public AdService(AdContext context)
        {
            _context = context;
        }

        public IEnumerable<Ad> GetAds()
        {
            return _context.Ads;
        }

        public IEnumerable<Category> GetCategoriy()
        {
            return _context.Categories;
        }
    }
}
