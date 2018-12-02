using MojoRobo.Common.Models;
using MojoRobo.Common.Enums;

namespace MojoRobo.Core.Interfaces
{
    public interface IActionsTranslator
    {
        BoardAction TranslateAction(CommandTypes type, 
                                    int? XBlock = null, 
                                    int? YBlock = null, 
                                    char? F = null);

        BoardPosition TranslatePosition(CommandTypes type,
                                        int? X = null,
                                        int? Y = null,
                                        char? F = null);
    }
}
