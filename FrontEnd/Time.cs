namespace FrontEnd
{
    public class Time
    {
        public int min;
        public int sec;

        public void Inc()
        {
            sec++;
            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
        }
    }
}