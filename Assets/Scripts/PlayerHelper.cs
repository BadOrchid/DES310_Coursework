using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper
    : MonoBehaviour {
    public static bool CheckType(PlayerType type, TwoPlayerControls player) {
        return player.type == type;

    }

    public static TwoPlayerControls[] Find() {
        return FindObjectsByType<TwoPlayerControls>(FindObjectsSortMode.None);

    }


}
