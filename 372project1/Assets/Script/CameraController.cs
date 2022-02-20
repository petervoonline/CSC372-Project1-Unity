using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This class is controlling the camera movement by updating the camera location by its x position, y position, and z position.
[serializeField] means you can update the player position on the Unity IDE not only from C# script.
*/
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

    }
}
