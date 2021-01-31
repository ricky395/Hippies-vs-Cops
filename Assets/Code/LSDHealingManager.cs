using UnityEngine;

public class LSDHealingManager : MonoBehaviour {

    public float timeBetweenHealings = 3;
    public GameObject healingBullet;
    Transform line;

	void Start () {

        line = GameObject.Find("Line").GetComponent<Transform>();
        InvokeRepeating("Heal", 0.5f, timeBetweenHealings);
	}
	
    void Heal ()
    {
        Instantiate(healingBullet, new Vector2(line.position.x, this.transform.position.y), Quaternion.identity);
    }
	
}
