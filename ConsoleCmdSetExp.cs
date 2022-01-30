﻿using System.Collections.Generic;

namespace _7DTD_Test
{
    public class ConsoleCmdSetExp : ConsoleCmdAbstract
    {
        public override string[] GetCommands() => new string[1]
        {
            "setexp"
        };

        public override string GetDescription()
        {
            return "Set your experience";
        }

        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            if (GameManager.IsDedicatedServer)
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output(
                    "cannot execute setexp on dedicated server, please execute as a client");
            if (_params.Count < 1)
            {
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("setexp requires experience as integer");
            }
            else
            {
                EntityPlayerLocal primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
                if (int.TryParse(_params[0], out var result))
                {
                    if (result < 0)
                    {
                        SingletonMonoBehaviour<SdtdConsole>.Instance.Output("experience must be 0 or more.");
                    }
                    else
                    {
                        primaryPlayer.Buffs.SetCustomVar("_xpOther", result);
                    }
                }
                else
                    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("experience must be a integer.");
            }
        }
    }
}