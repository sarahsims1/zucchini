using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    /// <summary>
    /// Switches camera position and resizes it for each level
    /// </summary>
    /// 
    private Camera mainCam;

    [SerializeField]
    private float cameraSize;

    private bool thisCam;

    //finds the camera
    void Start()
    {
        mainCam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
    }

    // if we are in the level area, the camera switches
    void Update()
    {
        if(thisCam)
        {
            mainCam.transform.position = transform.position;
            mainCam.orthographicSize = cameraSize;
        }
    }

    //Collision checks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            thisCam = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            thisCam = false;
        }
    }
}
