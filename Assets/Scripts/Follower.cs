using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Vector3 relativePos;

    // Start is called before the first frame update
    void Start()
    {
        relativePos = transform.position - Player.Instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = relativePos - (transform.position - Player.Instance.transform.position);
        transform.position += offset;
    }
}
