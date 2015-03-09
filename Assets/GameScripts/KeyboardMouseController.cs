using UnityEngine;
using System.Collections;
using CustomController;
using GameUtils;

public class KeyboardMouseController : MonoBehaviour, IController
{
    private ControllerCommandHandler mControllerCommand = null;
	public event ControllerCommandHandler CommandsFired
    {
        add
        {
            mControllerCommand += value;
        }
        remove
        {
            mControllerCommand -= value;
        }
    }
}
