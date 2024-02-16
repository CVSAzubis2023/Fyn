using Pac_Man.GameLogic;
using System.Linq.Expressions;

namespace Pac_Man
{
    public class ghost : movableObject
    {
        #region Vars

        private double[] posPlayer;

        private short behavior;

        #endregion

        #region Constructors

        public ghost(string name, short x) 
        {
            this.name = name;
            this.behavior = x;
        }

        #endregion

        #region Methods
        
        public short getBehavior()
        {
            return behavior;
        }

        public void ai()
        {
            switch (behavior)
            {
                case 0:
                    aiRed();
                    break;
                case 1:
                    aiBlue();
                    break;
                case 2:
                    aiYellow();
                    break;
                case 3:
                    aiPurple();
                    break;
                default:
                    throw new System.Exception();
            }
        }

        private double aiRed()
        {
            if (posPlayer[0] < pos[0])
            {
                //move left
                return pos[0] - speed;
            }
            else if (posPlayer[0] > pos[0])
            {
                //move right
                return pos[0] + speed;
            }
            else if (posPlayer[1] < pos[1])
            {
                //move up
                return pos[1] - speed;
            }
            else if (posPlayer[1] > pos[1])
            {
                //move down
                return pos[1] + speed;
            }
            return 0;
        }

        private void aiYellow() 
        {
            
        }

        private void aiBlue()
        {

        }

        private void aiPurple()
        {

        }


        #endregion
    }
}