using MojoRobo.Common.Models;
using System;
using System.Windows.Forms;

namespace MojoRobo.Common.Interfaces
{
    public interface ILogger
    {
        void Update(TextBox logTextBox);
        void LogRegisterAction(BoardAction action);
        void LogExecutionStart();
        void LogExecution(BoardAction action);
        void LogExecutionEnd();
        void Log(string message);
        void Clear();
    }
}
