
namespace adventofcode2023
{
    public class Race
    {
        public long Time {get; set;}
        public long Distance {get; set;}
        private long WinCount {get; set;}

        public void CalculateWins()
        {
            long speed = 1;
            while(GetCurrentDistance(speed, Time) <= Distance)
            {
                speed++;
            }
            WinCount = Time - (2 * speed) + 1; // +1 because we already found the first one
        }

        public long ReturnWins()
        {
            return WinCount;
        }

        private static long GetCurrentDistance(long speed, long time)
        {
            return speed * (time - speed);
        }
    }





}