using System.CodeDom.Compiler;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pac_Man
{
    public class player
    {
        private int lifes = 0;
        private int score = 0;

        private double speed = 4 * 8;

        private int orrientation = 0;
        private int tilesmoved = 0;

        private int posX = 0;
        private int posY = 0;

        private int newX = 0;
        private int newY = 0;

        public int getPosX()
        {
            return posX;
        }

        public int getPosY()
        {
            return posY;
        }

        public int getTilesMoved()
        {
            return tilesmoved;
        }
        

        public void setPos(int x, int y)
        {
            posX = x;
            posY = y;
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

        public void move(string sender, double x, double y)
        {
            tilesmoved++;

            newX = (int)x;
            newY = (int)y;
            
            setPos(newX, newY);
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

        public double getSpeed()
        {
            return speed;
        }

        public void setOrientation(int x)
        {
            orrientation = x;
        }
    }
}