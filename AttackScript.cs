using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
    

    /// <summary>
    /// Character transform
    /// </summary>
    Transform tr;

    /// <summary>
    /// Character animator
    /// </summary>
    Animator animator;

    /// <summary>
    /// Minimum distance for the character to attack an enemy
    /// </summary>
    public float attackDistance = 1;

    /// <summary>
    /// Fire rate of character
    /// </summary>
    public float attackingSpeed = 2;

    /// <summary>
    /// Defines if the character is an enemy or not
    /// </summary>
    bool isPlayable;

    /// <summary>
    /// The layer the characters have
    /// </summary>
    string layerName;

    /// <summary>
    /// Direction of the projectile
    /// </summary>
    int direction;

    /// <summary>
    /// Detects if is shooting or not
    /// </summary>
    bool attacking = false;

    /// <summary>
    /// Reference to another class which manages different attack types
    /// </summary>
    AttackTypeByClass attackReference;

    /// <summary>
    /// Reference to the movements of characters
    /// </summary>
    SpriteMovement sm;

    /// <summary>
    /// Controls if the unit is the special unit 1
    /// </summary>
    public bool isGEO;

    /// <summary>
    /// Controls if the unit is the special unit 2
    /// </summary>
    public bool isStrong;

    /// <summary>
    /// Initializes all references and determines whether the unit is ally or enemy
    /// </summary>
    void Start () {

        attackReference = GetComponent<AttackTypeByClass>();
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        if (this.gameObject.layer == LayerMask.NameToLayer("Hippie")) //this is an ally and the direction of bullets and the target units are asigned.
        {
            direction = 1;
            layerName = "Cop";
            isPlayable = true;
        }

        else if (this.gameObject.layer == LayerMask.NameToLayer("Cop"))//this is an enemy and the direction of bullets and the target units are asigned.
        {
            direction = -1;
            layerName = "Hippie";
            isPlayable = false;
            sm = GetComponent<SpriteMovement>();
        }

	}
	

    /// <summary>
    /// Check if the character have an enemy on his front to begin the attack
    /// </summary>
	void Update () {

        Vector2 origin = tr.position;
        
        float xPos;

        if (isStrong)
            xPos = tr.position.x - 2;

        else xPos = tr.position.x;

        Debug.DrawLine(origin, new Vector2(xPos + direction * attackDistance, tr.position.y), Color.green);
        attacking = Physics2D.Linecast(origin, new Vector2(xPos + direction * attackDistance, tr.position.y), 1 << LayerMask.NameToLayer(layerName)); //Detects if there is, at least, one enemy

        if (attacking)
            Attacking();

        else NotAttacking();
	}

    /// <summary>
    /// Attack function
    /// </summary>
    void Attacking()
    {
        if (!isPlayable)
        {
            if (!isGEO) //if is not an advanced unit
                sm.enabled = false; //sprite movement stops while attacking
        }

        if (!attackReference.GetIsFreeze())
            animator.Play("attack");

        else animator.Play("idle");
    }

    /// <summary>
    /// Manages what happens when a unit stops attacking
    /// </summary>
    void NotAttacking()
    {
        if (!isPlayable)
        {
            sm.enabled = true;
        }
        animator.Play("idle");
    }

    public bool GetIsAttacking()
    {
        return attacking;
    }

    public float GetAttackingSpeed()
    {
        return attackingSpeed;
    }
}
