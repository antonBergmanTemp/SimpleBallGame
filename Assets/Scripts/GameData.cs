using System;

[Serializable]
public class GameData
{
    public int[] Records;

    public GameData()
    {
        Records = new int[3] { 0, 0, 0 };
    }
}