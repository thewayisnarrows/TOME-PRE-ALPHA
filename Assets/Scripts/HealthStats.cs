using UnityEngine;

public class HealthStats
{
    public HealthStats()
    {
        OverHealing = 0;
        TotalHealing = 0;
        TotalDamageTaken = 0;
    }

    public void getHealthStats()
    {
        Debug.Log("Total healing: " + TotalHealing.ToString());
        Debug.Log("Total damage: " + TotalDamageTaken.ToString());
        Debug.Log("overhealing: " + OverHealing.ToString());
    }

    public int OverHealing { get; set; }

    public int TotalDamageTaken { get; set; }

    public int TotalHealing { get; set; }
}
