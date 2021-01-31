using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
    
    Transform tr;
    Animator animator;
    public float attackDistance = 1;
    public float attackingSpeed = 2;
    bool isPlayable;
    string layerName;
    int direction;
    bool attacking = false;
    AttackTypeByClass attackReference;
    SpriteMovement sm;
    public bool isGEO;
    public bool isStrong;

    void Start () {

        attackReference = GetComponent<AttackTypeByClass>();
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        if (this.gameObject.layer == LayerMask.NameToLayer("Hippie"))
        {
            direction = 1;
            layerName = "Cop";
            isPlayable = true;
        }

        else if (this.gameObject.layer == LayerMask.NameToLayer("Cop"))
        {
            direction = -1;
            layerName = "Hippie";
            isPlayable = false;
            sm = GetComponent<SpriteMovement>();
        }

	}
	
	void Update () {

        Vector2 origin = tr.position;
        
        float xPos;

        if (isStrong)
            xPos = tr.position.x - 2;

        else xPos = tr.position.x;

        Debug.DrawLine(origin, new Vector2(xPos + direction * attackDistance, tr.position.y), Color.green);
        attacking = Physics2D.Linecast(origin, new Vector2(xPos + direction * attackDistance, tr.position.y), 1 << LayerMask.NameToLayer(layerName));

        if (attacking)
            Attacking();

        else NotAttacking();
	}

    void Attacking()
    {
        if (!isPlayable)
        {
            if (!isGEO) //si no es una unidad avanzada
            sm.enabled = false; //se para mientras ataca
        }

        if (!attackReference.GetIsFreeze())
            animator.Play("attack");

        else animator.Play("idle");
    }

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
