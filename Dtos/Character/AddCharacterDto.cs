using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreprac.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Saad";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass MClass { get; set; } = RpgClass.Knght;    
    }
}