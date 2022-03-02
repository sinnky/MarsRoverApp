using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum RoverCommandEnum
    {
        [Display(Name = "L")]
        Left = 1,

        [Display(Name = "R")]
        Rigth = 2,

        [Display(Name = "M")]
        Move = 3,
    }
}
