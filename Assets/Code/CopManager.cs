using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopManager : MonoBehaviour
{
    public float totalDistance = 0;
    public float totalHealth = 0;
    public float totalDamage = 0;

    public float healthSum = 10;

    PlayerHealth p_health;

	void Start ()
    {
        p_health = GetComponent<PlayerHealth>();
	}

    public void UpdateDamage()
    {
        ++totalDamage;
    }

    public void UpdateDeath()
    {
        totalHealth += p_health.health;

        if (p_health.health > 0)
            totalHealth += healthSum;

        // Paso de datos
        // Muerte
    }
}
