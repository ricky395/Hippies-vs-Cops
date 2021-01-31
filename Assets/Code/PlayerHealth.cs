using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    float maxHealth;
    public float health = 100;

    CopManager manager;

	void Start ()
    {
        maxHealth = health;
        manager = GetComponent<CopManager>();
    }
	
	public void UpdateHealth(float points)
    {
        health += points;
        if (health <= 0)
        {
            if (this.name == "SceneManager") //este script se aplica también a SceneManager
                GetComponent<LoseGame>().GameLost();

            else
            {
                //Destroy(this.gameObject);
                manager.UpdateDeath();
            }
        }

        if (health > maxHealth)
            health = maxHealth;
    }

    public bool IsFullHP()
    {
        return maxHealth == health;
    }
}
