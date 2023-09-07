using System.CodeDom.Compiler;
using System.Windows.Input;

namespace Pac_Man
{
    public class player
    {
        private int lifes = 3;
        private int score = 0;
        private int orrientation = 0;

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

        public void move(object sender)
        {
            switch (sender)
            {
                case "w":
                    break;
                case "a":
                    break;
                case "s":
                    break;
                case "d":
                    break;
                default :
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