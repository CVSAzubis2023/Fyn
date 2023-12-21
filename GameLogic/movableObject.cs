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

        protected double posX;
        protected double posY;
        protected double speed = 4 * 8;

        protected short orientation;

        #endregion

        #region Constructors

        public movableObject()
        {

        }

        #endregion

        #region Methods

        public void move(int x, int y)
        {
              
        }

        public short getOrientation()
        {
            return orientation;
        }

        public double[] getPos()
        {
            double[] pos = new double[2];
            pos[0] = this.posX;
            pos[1] = this.posY;

            return pos;
        }

        public void setPos(double x, double y)
        {
            this.posX = x;
            this.posY = y;
        }

        #endregion
    }
}
