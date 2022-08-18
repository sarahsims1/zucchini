using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float offSet;

    [SerializeField]
    private GameObject levelMarks;

    void Update()
    {
        if(fallTrigger.hit)
        {
            levelMarks.SetActive(false);
            Follow();
        }
    }

    void Follow()
    {
        transform.position = new Vector3(player.position.x, player.position.y + offSet, -10);
    }
}
