using UnityEngine;

/*
    Basic Mana Manager for all objects with Mana.
*/
public class ManaManager : MonoBehaviour {

    public int maxMana;
    public int currentMana;
    /// <summary>
    /// Amount of mana to regen
    /// </summary>
    public int regenValue;
    /// <summary>
    /// Number of seconds between application of regenValue
    /// </summary>
    public float regenRate;


    public ManaStats manaStats = new ManaStats();


	// Use this for initialization
	void Start ()
    {
        SetMaxMana();
        ResetStats();

        InvokeRepeating("Regenerate", 0.0f, regenRate);
    }

    // Update is called once per frame
    void Update () {
		if (currentMana < 1)
        {
            manaStats.getManaStats();
            gameObject.SetActive(false);
        } 
	}

    private void ResetStats()
    {
        manaStats = new ManaStats();
    }
    
    /// <summary>
    /// Sets the maxMana property on object
    /// </summary>
    public void SetMaxMana()
    {
        currentMana = maxMana;
    }

    /// <summary>
    /// Applies damage to object
    /// </summary>
    /// <param name="damage">amount of damage to deal to an object</param>
    public void Hurt(int damage)
    {
        currentMana -= damage;
        manaStats.TotalManaLost += damage;
    }

    /// <summary>
    /// Heals the object for a given amount up to maxMana.
    /// </summary>
    /// <param name="mana">Amount to heal by.</param>
    public void Heal(int mana)
    {
        currentMana += mana;
        manaStats.TotalManaGain += mana;
        if (currentMana > maxMana)
        {
            manaStats.OverManaGain += currentMana - maxMana;
            SetMaxMana();
        }
    }

    private void Regenerate()
    {
        if (currentMana < maxMana)
        {
            currentMana += regenValue;
        }
    }
}


