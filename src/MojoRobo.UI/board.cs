using MojoRobo.Common.Interfaces;
using System;
using System.Windows.Forms;
using MojoRobo.Core.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace MojoRobo.UI
{
    public partial class Board : Form
    {
        private IBoardStatus BoardStatus { get; set; }
        private IRobotStatus RobotStatus { get; set; }
        private IActionsManager ActionManager { get; set; }
        private IUIBoardManager UIManager { get; set; }
        private ILogger Logger { get; set; }

        public Board(IBoardStatus boardStatus,
                    IRobotStatus robotStatus,
                    IActionsManager actionManager,
                    IUIBoardManager uiManager,
                    ILogger logger)
        {
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
            ActionManager = actionManager ?? throw new ArgumentNullException(nameof(actionManager));
            UIManager = uiManager ?? throw new ArgumentNullException(nameof(uiManager));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            InitializeComponent();

            BoardStatus.Update(boardPanelWidth: BoardPanel.Width,
                                boardPanelHeight: BoardPanel.Height,
                                roboPanelWidth: RoboPanel.Width,
                                boardPanel: BoardPanel);

            List<Bitmap> imgs = GetImageResources();

            RobotStatus.Update(isPlaced: false, 
                                robotPanel: RoboPanel,
                                imgs: imgs);

            Logger.Update(logTextBox: LogTextBox);
        }

        #region UI Event Handlers

        #region Draw
        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            UIManager.DrawGrid();
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
            UIManager.Place(XBlock: XPlaceTextBox.Text,
                            YBlock: YPlaceTextBox.Text,
                            F: FPlaceTextBox.Text);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            UIManager.Execute();
        }
        #endregion

        #region Logger
        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
            Logger.Clear();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            Logger.Log(RobotStatus.Report());
        }
        #endregion

        private List<Bitmap> GetImageResources()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream1 = myAssembly.GetManifestResourceStream("MojoRobo.UI.Images.east.png");
            Bitmap bmp1 = new Bitmap(myStream1);

            Stream myStream2 = myAssembly.GetManifestResourceStream("MojoRobo.UI.Images.north.png");
            Bitmap bmp2 = new Bitmap(myStream2);

            Stream myStream3 = myAssembly.GetManifestResourceStream("MojoRobo.UI.Images.south.png");
            Bitmap bmp3 = new Bitmap(myStream3);

            Stream myStream4 = myAssembly.GetManifestResourceStream("MojoRobo.UI.Images.west.png");
            Bitmap bmp4 = new Bitmap(myStream4);

            return new List<Bitmap>() { bmp1, bmp2, bmp3, bmp4 };
        }

        #endregion

        
    }
}
