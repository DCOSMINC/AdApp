using AdData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdData
{
    public interface IAdData
    {
        IEnumerable<Category> GetCategoriy();
        IEnumerable<Ad> GetAds();
    }
}
