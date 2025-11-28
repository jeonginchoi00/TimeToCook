using UnityEngine;

namespace Globals
{
    #region Game
    public enum Ingredient
    {
        TOMATO = 0,
        LETTUCE = 1,
        BEEF = 2,
        GROUNDBEEF = 3,
        BUN_TOP = 4,
        BUN_BOTTOM = 5,
        CHEESE = 6,
    }
    #endregion

    #region UI
    public enum PageType
    {
        NONE = 0,

        // Title
        TITLE = 100,

        // Game

    }

    public enum PopupType
    {
        NONE = 0,

        // Title

        // Game

    }
    #endregion

    #region Sound
    public enum SoundType
    {
        NONE = 0,
    }
    #endregion
}