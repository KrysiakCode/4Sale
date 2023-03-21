using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

namespace _4Sale.Enums
{
    public enum ItemType
    {
        [Display(Name = "Torba podróżna")]
        TravelBag,
        [Display(Name = "Plecak")]
        BackPack,
    }
}
