using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Basic Health Manager for all objects with health.
*/
public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth; 
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth < 1)
        {
            gameObject.SetActive(false);
        } 
	}
    
    /// <summary>
    /// Applies damage to object
    /// </summary>
    /// <param name="damage">amount of damage to deal to an object</param>
    public void Hurt(int damage)
    {
        currentHealth -= damage;
    }

    /// <summary>
    /// Sets the maxHealth property on object
    /// </summary>
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
