using UnityEngine;
using System.Collections;
using CustomController;
using GameUtils;

public class KeyboardMouseController : MonoBehaviour, IController
{
    #region Singleton Declaration
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
    #endregion


    private System.Collections.Generic.List<ControllerCommandEventArgs> mCommandList = new System.Collections.Generic.List<ControllerCommandEventArgs>();

    private float mHorizontal = 0;
    private float mVertical = 0;
    private float mSpeedOfLight = 0;

    private float mMouseHorizontal = 0;
    private float mMouseVertical = 0;

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

        if (mHorizontal != Input.GetAxis("Horizontal"))
        {
            mHorizontal = Input.GetAxis("Horizontal");
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.PLAYER_HORIZONTAL, mHorizontal));
        }

        if (mVertical != Input.GetAxis("Vertical"))
        {
            mVertical = Input.GetAxis("Vertical");
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.PLAYER_VERTICAL, mVertical));
        }
        if (mSpeedOfLight != Input.GetAxis("Speed of Light"))
        {
            mSpeedOfLight = Input.GetAxis("Speed of Light");
            mCommandList.Add(ControllerCommandEventArgs.Generate((uint)GameUtils.GameCommand.LIGHT_SPEED, mSpeedOfLight));
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
