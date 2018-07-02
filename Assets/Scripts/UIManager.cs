using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPText;
    public HealthManager playerHealth;

    public Slider manaBar;
    public Text ManaText;
    public ManaManager playerMana;

    private static bool UIExists;

	// Use this for initialization
	void Start ()
    {
        // This is to keep UI from duplicating as the game changes scenes
        // might not need this later on

        PreserveUI();

    }

    /// <summary>
    /// Preserves UI when game scene changes.
    /// </summary>
    private void PreserveUI()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }


    // Update is called once per frame
    void Update () {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
        HPText.text = "HP: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;

        manaBar.maxValue = playerMana.maxMana;
        manaBar.value = playerMana.currentMana;
        ManaText.text = "Mana: " + playerMana.currentMana + "/" + playerMana.maxMana;

    }
}
