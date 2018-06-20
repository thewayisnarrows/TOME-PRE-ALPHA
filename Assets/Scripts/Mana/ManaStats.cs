using UnityEngine;

public class ManaStats
{
    public ManaStats()
    {
        OverManaGain = 0;
        TotalManaGain = 0;
        TotalManaLost = 0;
    }

    public void getManaStats()
    {
        Debug.Log("Total healing: " + TotalManaGain.ToString());
        Debug.Log("Total damage: " + TotalManaLost.ToString());
        Debug.Log("overhealing: " + OverManaGain.ToString());
    }

    public int OverManaGain { get; set; }

    public int TotalManaLost { get; set; }

    public int TotalManaGain { get; set; }
}
