using UnityEngine;
using System.Collections;

namespace CustomController
{
    public class ControllerCommandEventArgs
    {
        public uint CommandID;
        public object[] CommandArgs;
    }

    public delegate void ControllerCommandHandler(object sender, ControllerCommandEventArgs[] args);

    public interface IController
    {
        event ControllerCommandHandler CommandsFired;
    }
}
