using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Project
{
    public class Characters
    {
        public int Atk { get; set; }
        public int Hp { get; set; }
        public int Def { get; set; }

        //private int _attack;
        //private int _heath;
        //private int _defence;

        public void UpdateValues(int atk, int hp, int def)
        {
            Atk = atk;
            Hp = hp;
            Def = def;
        }
    }
}
