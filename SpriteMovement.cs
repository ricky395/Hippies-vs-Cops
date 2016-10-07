using UnityEngine;
using System.Collections;

public class SpriteMovement : MonoBehaviour {

    /// <summary>
    /// variable that manages the 'grid' movement
    /// </summary>
    float gridJumpMovement;

    /// <summary>
    /// Transform of the character. This script is attached to enemies, allies and projectiles
    /// </summary>
    Transform tr;

    /// <summary>
    /// Rigidbody of the GameObject
    /// </summary>
    Rigidbody2D rb;

    /// <summary>
    /// 'Velocity' of the GameObject
    /// </summary>
    public float timeBetweenMoves = 0.8f;

    /// <summary>
    /// Boolean that shows if the current Gameobject is ally or enemy
    /// </summary>
    public bool isEnemy;

    /// <summary>
    /// Timer
    /// </summary>
    float count;

    /// <summary>
    /// Movement state of GameObject
    /// </summary>
    bool isMoving = true;

    /// <summary>
    /// Initializes components and the movement direction
    /// </summary>
    void Start () {

        if (isEnemy) //If the gameobject is an enemy or an enemy projectile, it moves on the opposite direction (left)
            gridJumpMovement = -0.2f;

        else gridJumpMovement = 0.2f;
        
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

	}

    /// <summary>
    /// Manages the time between every move
    /// </summary>
    void Update()
    {
        count += Time.deltaTime;

        if (count > timeBetweenMoves)
        {
            Movement();
            count = 0;
        }
    }
	
    /// <summary>
    /// Moves the sprite
    /// </summary>
     void Movement()
    {
        if (isMoving)
            tr.position = new Vector2(tr.position.x + gridJumpMovement, tr.position.y);
    }

    /// <summary>
    /// Manages the colliders that the gameobject can collide with
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Limits")) //If the gameobject is out of the screen, its destroyed
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Cop"))
                GameObject.Find("SceneManager").GetComponent<PlayerHealth>().UpdateHealth(-1);
            
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Movement setter
    /// </summary>
    /// <param name="state"></param>
    public void SetMovement(bool state)
    {
        isMoving = state;
    }
}
