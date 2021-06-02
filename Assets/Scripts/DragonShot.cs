using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShot : MonoBehaviour
{
    public GameObject explosionFX;


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Debug.Log("Collided");

        Destroy(gameObject);
    }
}
