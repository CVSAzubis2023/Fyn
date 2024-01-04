using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.GameLogic
{
    public abstract class movableObject
    {
        #region Vars

        protected string name;

        //0 => x | 1 => y
        protected double[] pos = new double[2];
        protected double speed = 5 * 5;

        protected short orientation;

        #endregion

        #region Constructors

        public movableObject()
        {

        }

        #endregion

        #region Methods

        public void move(double[] pos)
        {
              
        }

        public double getSpeed()
        {
            return speed;
        }

        public void setOrientation(short x)
        {
            this.orientation = x;
        }

        public short getOrientation()
        {
            return orientation;
        }

        public double[] getPos()
        {
            return pos;
        }

        public void setPos(double x, double y)
        {
            this.pos[0] = x;
            this.pos[1] = y;
        }

        #endregion
    }
}
