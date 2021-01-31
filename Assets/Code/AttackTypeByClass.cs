using UnityEngine;
using System.Collections;

public class AttackTypeByClass : MonoBehaviour
{
    public GameObject bulletObj;
    Transform bulletSpawn;
    AttackScript aS;
    bool prevBool;
    bool isFreeze;
    float timeFreezed = 0;
    GameObject bullet;
    bool isEnemy;

    CopManager manager;

    void Start()
    {
        aS = GetComponent<AttackScript>();
        bulletSpawn = GetComponentInChildren<Transform>();
        if (this.gameObject.layer == LayerMask.NameToLayer("Cop"))
            isEnemy = true;

        manager = GetComponent<CopManager>();
    }

    void Update()
    {
        if (prevBool != aS.GetIsAttacking())
        {
            if (aS.GetIsAttacking())
            {
                if (!isFreeze)
                    RepeatFunction();
            }

            else CancelInvoke();
        }

        prevBool = aS.GetIsAttacking();

        if (timeFreezed > 0)
        {
            UpdateMovement(false);
            timeFreezed -= Time.deltaTime;
        }

        else UpdateMovement(true);

    }
    
    void UpdateMovement(bool state)
    {
        if (isEnemy)
            this.GetComponent<SpriteMovement>().SetMovement(state);
    }

    void RepeatFunction()
    {
        InvokeRepeating("LaunchBullet", 0.5f, aS.GetAttackingSpeed());
    }

    void LaunchBullet()
    {
        if (!isFreeze)
        {
            Instantiate(bulletObj, this.transform.position, Quaternion.identity);
            manager.UpdateDamage();
        }
    }


    public void SetFreezeValues(GameObject bullet, bool state, float timeFreezed)
    {
        isFreeze = state;
        this.timeFreezed = timeFreezed;
        this.bullet = bullet;
    }

    public bool GetIsFreeze()
    {
        return isFreeze;
    }
}
