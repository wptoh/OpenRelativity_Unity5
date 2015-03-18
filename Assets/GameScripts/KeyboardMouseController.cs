using UnityEngine;
using System.Collections;
using CustomController;
using GameUtils;

public class KeyboardMouseController : MonoBehaviour, IController
{
    private System.Collections.Generic.List<ControllerCommandEventArgs> mCommandList = new System.Collections.Generic.List<ControllerCommandEventArgs>();

    private static KeyboardMouseController mInstance = null;
    public static KeyboardMouseController Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject inputListenerGO = new GameObject("KeyboardMouseController");
                mInstance = inputListenerGO.AddComponent<KeyboardMouseController>();
                GameObject.DontDestroyOnLoad(inputListenerGO);
            }
            return mInstance;
        }
    }

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

    private void Update()
    {
        ReadInput();
        DispatchCommands();
    }

    private void ReadInput()
    {
        if (Input.GetButtonDown("Menu Key"))
        {
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.MENU_COMMAND));
        }
        if (Input.GetButtonDown("Shader"))
        {
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.SHADER_TOGGLE));
        }
        if (Input.GetButtonDown("Invert Button"))
        {
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.INVERT_TOGGLE));
        }
    }

    private void DispatchCommands()
    {
        if (mControllerCommand != null)
        {
            mControllerCommand(this, mCommandList.ToArray());
        }
        mCommandList.Clear();
    }
}
