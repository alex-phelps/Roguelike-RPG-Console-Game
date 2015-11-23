using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public enum EnemyType
    {
        rat,
        weakZombie
    }

    public enum RandomItemType
    {
        basicHealthTonic
    }

    public enum WeaponEffect
    {
        none,
        penetrate,
        burn,
        wisdom,
        midas
    }

    public enum StatusEffect
    {
        none,
        burned
    }
}
