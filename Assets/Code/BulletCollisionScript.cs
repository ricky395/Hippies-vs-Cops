using UnityEngine;
using System.Collections;

public class BulletCollisionScript : MonoBehaviour
{
    string layerName;
    public float damageOrHealingPoints = 2;
    PlayerHealth ph;
    public bool isLSD;
    public bool isHealer;
    public float timeFreezed = 2;

    void Start()
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("HippieBullet"))
            layerName = "Cop";

        else if (this.gameObject.layer == LayerMask.NameToLayer("CopBullet"))
            layerName = "Hippie";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ph = collision.gameObject.GetComponent<PlayerHealth>();
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
            if (!ph.IsFullHP() && isHealer) //si no esta a full hp y es proyectil de curacion
            {
                ph.UpdateHealth(damageOrHealingPoints);
                Destroy(this.gameObject);
            }

            else if (!isHealer)
            {
                if (!isLSD)
                    ph.UpdateHealth(-damageOrHealingPoints);

                else
                    collision.gameObject.GetComponent<AttackTypeByClass>().SetFreezeValues(this.gameObject, true, timeFreezed);

                Destroy(this.gameObject);
            }

        }
    }
}
