using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSound : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        float lifeTime = GetComponent<AudioSource>().clip.length;
        Destroy(gameObject, lifeTime);
    }
}
