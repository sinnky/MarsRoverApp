using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum DirectionEnum
    {
        [Display(Name = "N")]
        North = 1,

        [Display(Name = "E")]
        East = 2,

        [Display(Name = "S")]
        South = 3,

        [Display(Name = "W")]
        West = 4,
    }
}