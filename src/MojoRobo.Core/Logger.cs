using System.Windows.Forms;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;

namespace MojoRobo.Core
{
    public class Logger : ILogger
    {
        #region Properties
        private TextBox LogTextBox { get; set; }
        #endregion

        #region Constructor
        public Logger()
        {

        }
        #endregion

        #region Interface
        public void Clear()
        {
            LogTextBox.Text = string.Empty;
        }

        public void LogRegisterAction(BoardAction action)
        {
            string curr = LogTextBox.Text;
            string lineBreak = !string.IsNullOrEmpty(curr) ? "\r\n" : string.Empty;
            string register = $"-> Registered action: {action.ToStringRegister()}";
            LogTextBox.AppendText($"{lineBreak}{register}");
        }

        public void LogExecution(BoardAction action)
        {
            string curr = LogTextBox.Text;
            string lineBreak = !string.IsNullOrEmpty(curr) ? "\r\n" : string.Empty;
            string exec = $"-> Run action: {action.ToString()}";
            LogTextBox.AppendText($"{lineBreak}{exec}");
        }

        public void LogExecutionEnd()
        {
            string execStart = "\r\n=== Execution end\r\n";
            LogTextBox.AppendText($"{execStart}");
        }

        public void LogExecutionStart()
        {
            string execStart = "\r\n\r\n=== Execution start";
            LogTextBox.AppendText($"{execStart}");
        }

        public void Log(string message)
        {
            string curr = LogTextBox.Text;
            string lineBreak = !string.IsNullOrEmpty(curr) ? "\r\n" : string.Empty;
            LogTextBox.AppendText($"{lineBreak}{message}");
        }

        public void Update(TextBox logTextBox)
        {
            LogTextBox = logTextBox;
        }
        #endregion
    }
}
