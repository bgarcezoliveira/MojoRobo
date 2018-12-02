using MojoRobo.Common.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MojoRobo.Common.Interfaces
{
    public interface IRobotStatus
    {
        BoardPosition GetPosition();
        Panel GetRobotPanel();
        bool GetIsPlaced();
        void SetIsPlaced(bool placed);
        void Update(bool? isPlaced = null, 
                    Panel robotPanel = null, 
                    BoardPosition position = null, 
                    List<Bitmap> imgs = null);
        string Report();
        void SetDirectionOrigin(char origin);
        char GetDirectionOrigin();
        List<Bitmap> GetImages();
    }
}
