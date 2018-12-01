using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IRobotStatus
    {
        void Update(bool isPlaced, BoardPosition position = null);
        string Report();
    }
}
