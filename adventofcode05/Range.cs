namespace adventofcode2023
{
    public class Range
    {
        private long _SourceRange;
        private long _DestinationRange;
        private long _Length;
        private long _Difference;

        public Range(long sourceRange, long destinationRange, long length)
        {
            _SourceRange = sourceRange;
            _DestinationRange = destinationRange;
            _Length = length;
            _Difference = destinationRange - sourceRange;
        }
    }

}
