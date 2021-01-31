using UnityEngine;
using System.Collections;

public class SpriteMovement : MonoBehaviour {

    float gridJumpMovement;
    Transform tr;
    Rigidbody2D rb;
    public int speed;
    int maxSpeed = 10;
    public bool isEnemy;
    float count;
    bool isMoving = true;

    float timeBetweenMoves;
    float minTimeBetweenMoves = 0.15f;
    float maxTimeBetweenMoves = 0.5f;

    CopManager manager;

    void Start ()
    {
        if (isEnemy)
            gridJumpMovement = -0.2f;

        else gridJumpMovement = 0.2f;
        
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

        manager = GetComponent<CopManager>();
        
        timeBetweenMoves = Mathf.Lerp(minTimeBetweenMoves, maxTimeBetweenMoves, (float) speed / (float) maxSpeed);

        float v = maxTimeBetweenMoves - timeBetweenMoves;
        timeBetweenMoves = minTimeBetweenMoves + v;
	}

    void Update()
    {
        count += Time.deltaTime;

        if (count > timeBetweenMoves)
        {
            Movement();
            count = 0;
        }
    }
	
     void Movement()
    {
        if (isMoving)
            tr.position = new Vector2(tr.position.x + gridJumpMovement, tr.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Limits"))
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Cop"))
                GameObject.Find("SceneManager").GetComponent<PlayerHealth>().UpdateHealth(-1);
            
            //Destroy(this.gameObject);
            manager.UpdateDeath();
        }
    }

    public void SetMovement(bool state)
    {
        isMoving = state;
    }
}
