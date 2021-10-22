namespace OOPAssignment
{
    public interface ISurface
    {
        long Width { get; }
        long Height { get; }

        bool IsCoordinatesInBounds(Coordinates coordinates);
    }
}