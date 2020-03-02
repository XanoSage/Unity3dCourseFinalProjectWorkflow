using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    class GameEvents
    {
    }

    public class HealthPointChangeEvent
    {
        public int HealthPoint;
    }

    public class GameStartEvent
    { }

    public class SpawnButtonClickEvent
    { }

    public class WeaponTakeEvent
    {
        public HumanModel Owner;
        public WeaponModel Weapon;
    }

    public class WeaponAddedEvent
    {
        public HumanBehaviour Owner;
        public WeaponController Weapon;
    }
}
