using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float offSet;
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + offSet, -10);
    }
}
