using Pac_Man.GameLogic;
using System.CodeDom.Compiler;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pac_Man
{
    public class player : movableObject
    {
        #region Vars

        protected int lifes = 0;
        protected int score = 0;
        protected int tilesmoved = 0;

        #endregion

        #region Construtors

        public player(string name, int x, int y)
        {
            base.name = name;
            base.posX = x;
            base.posY = y;
        }

        #endregion

        #region Methods

        public int getTilesMoved()
        {
            return tilesmoved;
        }

        public int getLifes()
        {
            return lifes;
        }

        public void setLifes(int x)
        {
            lifes = x;
        }

        public void decLifes()
        {
            lifes--;
        }

        public void incLifes()
        {
            lifes++;
        }

        public int getScore()
        {
            return score;
        }

        public void setScore(int x)
        {
            score = x;
        }

        public void incScore()
        {
            score++;
        }

        #endregion
    }
}