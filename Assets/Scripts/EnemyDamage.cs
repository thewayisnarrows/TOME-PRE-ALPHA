using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public int damage;
    public GameObject damageParticleBurst;
    public Transform hitPoint;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthManager>().Hurt(damage);
            GameObject burstEffect = Instantiate(damageParticleBurst, hitPoint.position, hitPoint.rotation);
        }
    }
}
