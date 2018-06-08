using UnityEngine;

/// <summary>
/// Methods associated with dealing damage to other objects and self.
/// </summary>
public class DamageManager {

    /// <summary>
    /// Deal damage to an object.
    /// </summary>
    /// <param name="target">Target object</param>
    /// <param name="damage">Amount of damage</param>
    public static void DealDamage (GameObject target, int damage)
    {
        HealthManager targetHealthManager = target.GetComponent<HealthManager>();
        if (targetHealthManager)
        {
            targetHealthManager.Hurt(damage);
        }
    }
}
