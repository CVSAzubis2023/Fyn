namespace PacMan
{
    public class player
    {
        private int lifes;
        private int score;

        private int posX;
        private int posY;

        public int getPosX()
        {
            return posX;
        }

        public int getPosY()
        {
            return posY;
        }

        public int getLifes()
        {
            return lifes;
        }

        public void setLifes(int x)
        {
            lifes = x;
        }
    }
}