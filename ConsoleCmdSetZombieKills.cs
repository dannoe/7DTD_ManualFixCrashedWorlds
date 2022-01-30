using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _7DTD_Test
{
    public class ConsoleCmdSetZombieKills : ConsoleCmdAbstract
    {
        public override string[] GetCommands() => new string[1]
        {
            "setzombiekills"
        };

        public override string GetDescription()
        {
            return "Set your zombiekills";
        }

        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            if (GameManager.IsDedicatedServer)
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("cannot execute setzombiekills on dedicated server, please execute as a client");
            if (_params.Count < 1)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setzombiekills requires kills as integer");
            }
            else
            {
                EntityPlayerLocal primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
                if (int.TryParse(_params[0], out var result))
                {
                    if ( result <= 0)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output("kills must be 1 or more.");
                    }
                    else
                    {
                        primaryPlayer.KilledZombies = result;
                    }
                }
                else
                    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("kills must be a integer.");
            }
        }
    }
}
