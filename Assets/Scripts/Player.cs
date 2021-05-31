using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon weapon;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFire();
        }
        else if (Input.GetMouseButton(1))
        {
            OnVacuum();
        }
    }

    public void OnFire()
    {
        weapon.Fire(transform.forward);
    }

    public void OnVacuum()
    {
        weapon.Vacuum();
    }
}
