using System.Collections.Generic;

namespace _7DTD_Test
{
    public class ConsoleCmdSetSkillpoints : ConsoleCmdAbstract
    {
        public override string[] GetCommands() => new string[1]
        {
            "setskillpoints"
        };

        public override bool IsExecuteOnClient => true;

        public override string GetDescription()
        {
            return "Set your free skillpoints";
        }

        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            if (GameManager.IsDedicatedServer)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output(
                    "cannot execute setskillpoints on dedicated server, please execute as a client");
                return;
            }
                
            if (_params.Count < 1)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setskillpoints requires skillpoints as integer");
            }
            else
            {
                EntityPlayerLocal primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
                if (int.TryParse(_params[0], out var result))
                {
                    if (result < 0)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output("skillpoints must be 0 or more.");
                    }
                    else
                    {
                        primaryPlayer.Progression.SkillPoints = result;
                    }
                }
                else
                    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("skillpoints must be a integer.");
            }
        }

       
    }
}