using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WeakSpot : MonoBehaviour
{
    private DragonEnemy parent;

    public GameObject deathFX;


    public void SetDragonParent(DragonEnemy newParent)
    {
        parent = newParent;
    }

    private void RemoveSelfFromParent()
    {
        parent.weakSpots.Remove(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWeapon"))
        {
            KillSelf();
        }
    }

    private void KillSelf()
    {
        //Create FX object
        if (deathFX != null) { Instantiate(deathFX, transform.position, Quaternion.identity); }

        RemoveSelfFromParent();

        //Destroy self
        Destroy(this.gameObject);
    }
}
