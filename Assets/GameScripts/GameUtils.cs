using UnityEngine;
using System.Collections;

namespace GameUtils
{
    public enum GameCommand : uint
    {
        UNKNOWN = 0,
        MENU_COMMAND = 1,
        SHADER_TOGGLE = 2,
        INVERT_TOGGLE = 3,
        PLAYER_HORIZONTAL = 4,
        PLAYER_VERTICAL = 5,
        LIGHT_SPEED = 6,
    }
	
}
