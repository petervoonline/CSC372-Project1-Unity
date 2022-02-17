using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    private float len, startposition;
    public new GameObject camera;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position.x;
        len = GetComponent< SpriteRenderer > ().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startposition + distance, transform.position.y, transform.position.z);
    }
}
