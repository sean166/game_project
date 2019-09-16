using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Game_Project
{
    class GameEngin : ICharacterAtribute

    {
        public int Atk { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Hp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Def { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int turn = 0;

        public void Fight()
        {
            turn++;
            Hp = Hp - (Atk - Def);
        }

        public void Gamover()
        {
            if (Hp == 0 )
            {
                MessageDialog result = new MessageDialog("You Lose");
            }
            else
            {
                Fight();
            }
        }

       
    }
}
