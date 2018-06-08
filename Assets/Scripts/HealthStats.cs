public class HealthStats
{
    private int overHealing;
    private int totalHealing;
    private int totalDamageTaken;

    public HealthStats()
    {
        this.OverHealing = 0;
        this.TotalHealing = 0;
        this.TotalDamageTaken = 0;
    }

    public int OverHealing
    {
        get
        {
            return overHealing;
        }

        set
        {
            overHealing = value;
        }
    }

    public int TotalHealing
    {
        get
        {
            return totalHealing;
        }

        set
        {
            totalHealing = value;
        }
    }

    public int TotalDamageTaken
    {
        get
        {
            return totalDamageTaken;
        }

        set
        {
            totalDamageTaken = value;
        }
    }
}
