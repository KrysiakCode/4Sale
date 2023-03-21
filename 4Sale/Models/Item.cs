using System.ComponentModel.DataAnnotations;
using _4Sale.Enums;

namespace _4Sale.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ItemTypeEnum Type { get; set; }
    }
}
