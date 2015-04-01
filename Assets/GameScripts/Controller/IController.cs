using UnityEngine;
using System.Collections;

namespace CustomController
{
    public class ControllerCommandEventArgs
    {
        public uint CommandID;
        public object[] CommandArgs;

        public static ControllerCommandEventArgs Generate(uint commandID, params object[] args)
        {
            return new ControllerCommandEventArgs()
            {
                CommandID = commandID,
                CommandArgs = args,
            };
        }
    }

    public delegate void ControllerCommandHandler(object sender,ControllerCommandEventArgs[] args);

    public interface IController
    {
        event ControllerCommandHandler CommandsFired;
    }
}
