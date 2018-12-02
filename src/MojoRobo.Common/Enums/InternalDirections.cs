using System.ComponentModel;

namespace MojoRobo.Common.Enums
{
    public enum InternalDirections
    {
        [Description("EAST")]
        EAST1 = '3',

        [Description("SOUTH")]
        SOUTH1 = '5',

        [Description("WEST")]
        WEST1 = '8',

        [Description("NORTH")]
        NORTH1 = '1',

        [Description("NORTH")]
        NORTH2 = 'N',

        [Description("EAST")]
        EAST2 = 'E',

        [Description("SOUTH")]
        SOUTH2 = 'S',

        [Description("WEST")]
        WEST2 = 'W'
    }
}
