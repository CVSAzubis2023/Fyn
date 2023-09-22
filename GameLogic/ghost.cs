namespace Pac_Man
{
    public class ghost
    {
        private int posX;
        private int posY;

        private int speed;
        private int state;
        
        public void move(int posPlayerX, int posPlayerY)
        {
            if (posPlayerX > posX)
            {
                    //try to move up;
            }

            if (posPlayerX < posX)
            {
                //try to move down
            }

            if (posPlayerY > posY)
            {
                // try to move right
            }
            if (posPlayerY < posY)
            {
                // try to move left
            }
        }

        public int getPosX()
        {
            return posX;
        }

        public int getPosY()
        {
            return posY;
        }
    }
}