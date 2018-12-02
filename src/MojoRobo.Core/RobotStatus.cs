using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MojoRobo.Core
{
    public class RobotStatus : IRobotStatus
    {
        #region Properties
        private bool IsPlaced { get; set; }
        private BoardPosition Position { get; set; }
        private Panel RobotPanel { get; set; }
        private char DirectionOrigin { get; set; }
        private List<Bitmap> Imgs { get; set; }
        #endregion

        #region Constructor
        public RobotStatus()
        {
        }
        #endregion

        #region Interface
        public string Report()
        {
            return IsPlaced ? $"[Robot in {Position.ToString()}]" :
                              "[Robot has not yet been placed]";
        }

        public void Update(bool? isPlaced = null,
                            Panel robotPanel = null,
                            BoardPosition position = null,
                            List<Bitmap> imgs = null)
        {
            if (isPlaced.HasValue)
            {
                IsPlaced = isPlaced.Value;
            }

            if (robotPanel != null)
            {
                RobotPanel = robotPanel;
            }

            if (position != null)
            {
                Position = position;
            }

            if (imgs != null)
            {
                Imgs = imgs;
            }
        }

        public BoardPosition GetPosition()
        {
            return Position;
        }

        public bool GetIsPlaced()
        {
            return IsPlaced;
        }

        public void SetIsPlaced(bool placed)
        {
            IsPlaced = placed;
        }

        public Panel GetRobotPanel()
        {
            return RobotPanel;
        }

        public void SetDirectionOrigin(char origin)
        {
            DirectionOrigin = origin;
        }

        public char GetDirectionOrigin()
        {
            return DirectionOrigin;
        }

        public List<Bitmap> GetImages()
        {
            return Imgs;
        }
        #endregion
    }
}
