using System.Collections.Generic;
using System.Linq;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class ActionsValidationManager : IActionsValidationManager
    {
        #region Properties
        #endregion

        #region Constructor
        public ActionsValidationManager()
        {

        }

        #endregion

        #region Interface
        public bool ValidateActions(IEnumerable<BoardAction> actions)
        {
            throw new System.NotImplementedException();
        }

        //TODO: move error messages to resource file
        public IEnumerable<string> ValidatePlaceInput(string X, string Y, string F)
        {
            List<string> errorList = new List<string>();

            if (string.IsNullOrEmpty(X))
            {
                errorList.Add("X is empty");
            }
            else if (!int.TryParse(X, out int x))
            {
                errorList.Add("X is invalid. Please provide an integer value");
            }

            if (string.IsNullOrEmpty(Y))
            {
                errorList.Add("Y is empty");
            }
            else if (!int.TryParse(Y, out int y))
            {
                errorList.Add("Y is invalid. Please provide an integer value");
            }

            if (string.IsNullOrEmpty(F))
            {
                errorList.Add("F is empty");
            }
            else if (!char.TryParse(F, out char f))
            {
                errorList.Add("F is invalid. Please provide an char value");
            }
            else if (!typeof(Directions)
                        .GetEnumValues()
                        .Cast<Directions>()
                        .Any(d => ((char)d).ToString().ToLower() == f.ToString().ToLower()))
            {
                errorList.Add("F is an unrecognised direction");
            }

            return errorList.Count == 0 ? null : errorList;
        }
        #endregion
    }
}
