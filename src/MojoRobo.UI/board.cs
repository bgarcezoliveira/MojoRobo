using MojoRobo.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace MojoRobo.UI
{
    public partial class Board : Form
    {
        private IBoardStatus BoardStatus { get; set; }
        private IRobotStatus RobotStatus { get; set; }
        private IActionsManager ActionManager { get; set; }
        private IUIManager UIManager { get; set; }

        public Board(IBoardStatus boardStatus,
                    IRobotStatus robotStatus,
                    IActionsManager actionManager,
                    IUIManager uiManager)
        {
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
            ActionManager = actionManager ?? throw new ArgumentNullException(nameof(actionManager));
            UIManager = uiManager ?? throw new ArgumentNullException(nameof(uiManager));

            InitializeComponent();

            BoardStatus.Update(boardPanelWidth: BoardPanel.Width,
                                boardPanelHeight: BoardPanel.Height,
                                roboPanelWidth: RoboPanel.Width);

            RobotStatus.Update(isPlaced: false);
        }

        #region UI Event Handlers

        #region Draw
        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            UIManager.DrawGrid(panel: BoardPanel);
        }
        #endregion

        #region Commands
        private void RightButton_Click(object sender, EventArgs e)
        {
            UIManager.Right();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            UIManager.Left();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            UIManager.Move();
        }

        private void PlaceButton_Click(object sender, EventArgs e)
        {
            UIManager.Place(X: XPlaceTextBox.Text,
                            Y: YPlaceTextBox.Text,
                            F: FPlaceTextBox.Text);
        }
        #endregion

        #endregion

        //TODO: keep logic around - robo initially starts unpositioned
        //private void InitRoboPanelPosition()
        //{
        //    var ybottom = BoardPanel.Height - RoboPanel.Height - Offset;
        //    RoboPanel.Location = new Point(Offset, ybottom);
        //}

        //TODO: button events should raise actions in action manager
        //private void RightButton_Click(object sender, EventArgs e)
        //{
        //    var x = RoboPanel.Location.X + BlockSize;
        //    var currY = RoboPanel.Location.Y;
        //    if (CanMove(x, currY))
        //    {
        //        RoboPanel.Location = new Point(x, currY);
        //    }
        //}

        //private void LeftButton_Click(object sender, EventArgs e)
        //{
        //    var x = RoboPanel.Location.X - BlockSize;
        //    var currY = RoboPanel.Location.Y;
        //    if (CanMove(x, currY))
        //    {
        //        RoboPanel.Location = new Point(x, currY);
        //    }
        //}

        //private bool CanMove(int x, int y)
        //{
        //    return (x >= XBoundaries.Min && x <= XBoundaries.Max) &&
        //           (y >= YBoundaries.Min && y <= YBoundaries.Max);
        //}
    }
}
