using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteTextTracking : MonoBehaviour
{
    Transform sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spritepos = sprite.position;
        spritepos.z = transform.position.z;
        transform.position = spritepos;
    }
}
