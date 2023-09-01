using System.CodeDom.Compiler;

namespace Pac_Man
{
    public class player
    {
        private int lifes;
        private int score;
        private int orrientation;

        private int posX;
        private int posY;

        public int getPos()
        {
            return posX & posY;
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

        public void move(int newX, int newY)
        {
            
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