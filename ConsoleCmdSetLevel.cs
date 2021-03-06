using System.Collections.Generic;

namespace _7DTD_Test
{
    public class ConsoleCmdSetLevel : ConsoleCmdAbstract
    {
        public override string[] GetCommands() => new string[1]
        {
            "setlevel"
        };

        public override bool IsExecuteOnClient => true;

        public override string GetDescription()
        {
            return "Set your level";
        }

        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            if (GameManager.IsDedicatedServer)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("cannot execute setlevel on dedicated server, please execute as a client");
                return;
            }
                
            if (_params.Count < 1)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setlevel requires level as integer");
            }
            else
            {
                EntityPlayerLocal primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
                if (int.TryParse(_params[0], out var result))
                {
                    if ( result <= 0)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output("level must be 1 or more.");
                    }
                    else if (result > Progression.MaxLevel)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output(
                            $"level can not be higher as {Progression.MaxLevel}.");
                    }
                    else
                    {
                        primaryPlayer.Progression.Level = result;
                    }
                }
                else
                    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("level must be a integer.");
            }
        }
    }
}