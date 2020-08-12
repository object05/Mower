using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static float MOWER_WIDTH = 48f;
    public static float MOWER_HEIGHT = 64f;
    public static float MAX_MOWER_R_SPEED = 10;
    public static float MAX_MOWER_SPEED = 40;
    public static float TOUCH_RADIUS = 20;

    public static float WIDTH = 32 * 14;
    public static float HEIGHT = 32 * 24f;
    public static float W_WIDTH = 32 * 20;
    public static float W_HEIGHT = 32 * 100f;

    public static float POSITION_X = (W_WIDTH - MOWER_WIDTH) / 2;
    public static float POSITION_Y = 0;
    public static bool debug = true;
}
