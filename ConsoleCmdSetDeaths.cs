using System.Collections.Generic;

namespace _7DTD_Test
{
    public class ConsoleCmdSetDeaths : ConsoleCmdAbstract
    {
        public override string[] GetCommands() => new string[1]
        {
            "setdeaths"
        };

        public override string GetDescription()
        {
            return "Set your number of deaths";
        }

        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            if (GameManager.IsDedicatedServer)
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output(
                    "cannot execute setdeaths on dedicated server, please execute as a client");
            if (_params.Count < 1)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setdeaths requires deaths as integer");
            }
            else
            {
                EntityPlayerLocal primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
                if (int.TryParse(_params[0], out var result))
                {
                    if (result < 0)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output("deaths must be 0 or more.");
                    }
                    else
                    {
                        primaryPlayer.Died = result;
                    }
                }
                else
                    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setdeaths must be a integer.");
            }
        }

       
    }
}