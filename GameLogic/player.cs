using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Input;

namespace Pac_Man
{
    public class player
    {
        private int lifes = 3;
        private int score = 0;

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

        public void move(string sender)
        {
            tilesmoved++;
            Debug.WriteLine(sender);
            switch (sender)
            {
                case "w":
                    Debug.WriteLine("Up");
                    break;
                case "a":
                    Debug.WriteLine("Left");
                    break;
                case "s":
                    Debug.WriteLine("Down");
                    break;
                case "d":
                    Debug.WriteLine("Right");
                    break;
                case "Up":
                    Debug.WriteLine("Up");
                    break;
                default :
                    Debug.WriteLine("Default");
                    break;
            }
            
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
        
        
    }
}