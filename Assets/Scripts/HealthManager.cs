using UnityEngine;

/*
    Basic Health Manager for all objects with health.
*/
public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int regenValue;
    public float regenRate;


    public HealthStats healthStats = new HealthStats();


	// Use this for initialization
	void Start ()
    {
        SetMaxHealth();
        ResetStats();

        InvokeRepeating("Regenerate", 0.0f, regenRate);
    }

    // Update is called once per frame
    void Update () {
		if (currentHealth < 1)
        {
            healthStats.getHealthStats();
            gameObject.SetActive(false);
        }
	}

    private void ResetStats()
    {
        healthStats = new HealthStats();
    }
    
    /// <summary>
    /// Sets the maxHealth property on object
    /// </summary>
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Applies damage to object
    /// </summary>
    /// <param name="damage">amount of damage to deal to an object</param>
    public void Hurt(int damage)
    {
        currentHealth -= damage;
        healthStats.TotalDamageTaken += damage;
    }

    /// <summary>
    /// Heals the object for a given amount up to max health.
    /// </summary>
    /// <param name="health">Amount to heal by.</param>
    public void Heal(int health)
    {
        currentHealth += health;
        healthStats.TotalHealing += health;
        if (currentHealth > maxHealth)
        {
            healthStats.OverHealing += currentHealth - maxHealth;
            SetMaxHealth();
        }
    }

    /// <summary>
    /// Adds current regenValue to currentHealth
    /// </summary>
    private void Regenerate()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += regenValue;
        }
    }
}


