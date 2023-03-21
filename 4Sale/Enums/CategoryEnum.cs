using System.ComponentModel.DataAnnotations;

namespace _4Sale.Enums
{
    public enum CategoryEnum
    {
        [Display(Name = "Typ przedmiotu")]
        ItemType,
        [Display(Name = "Kolor przedmiotu")]
        ItemColor
    }
}
