namespace MojoRobo.Common.Constants
{
    /// <summary>
    /// UI Settings
    /// </summary>
    public class Globals
    {
        public const int BlockCount = 5;
        public const int GridLineWeight = 1;
        public const int DirectionsSequenceOrigin = 3;
        public static readonly char[] DirectionsSequenceNorth = { '3', '5', '8', 'N', 'E', 'S', 'W' };
        public static readonly char[] DirectionsSequenceSouth = { '3', '1', '8', 'S', 'E', 'N', 'W' };
        public static readonly char[] DirectionsSequenceEast = { 'S', '8', '1', 'E', 'S', 'W', 'N' };
        public static readonly char[] DirectionsSequenceWest = { '1', '3', '5', 'W', 'N', 'E', 'S' };
    }
}
