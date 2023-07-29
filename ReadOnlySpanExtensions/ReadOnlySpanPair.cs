namespace ReadOnlySpanExtensions
{
    public readonly ref struct ReadOnlySpanPair<T>
    {
        public ReadOnlySpan<T> First { get; }
        public ReadOnlySpan<T> Second { get; }

        public ReadOnlySpanPair(ReadOnlySpan<T> first, ReadOnlySpan<T> second)
        {
            First = first;
            Second = second;
        }
    }
}