namespace PacMan
{
    public class ghost
    {
        private int posX;
        private int posY;

        private int faceingDirection;

        private int stateAgression;

        public int getPosX()
        {
            return posX;
        }

        public void setPosX(int x)
        {
            posX = x;
        }

        public int getPosY()
        {
            return posY;
        }

        public void setPosY(int x)
        {
            posY = x;
        }
    }
}