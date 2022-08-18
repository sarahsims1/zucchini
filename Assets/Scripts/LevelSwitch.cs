using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    private Camera mainCam;

    [SerializeField]
    private float cameraSize;

    [SerializeField]
    private float travelSpeed;

    private bool thisCam;
    void Start()
    {
        mainCam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisCam)
        {
            mainCam.transform.position = transform.position;
            mainCam.orthographicSize = cameraSize;
        }
    }

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
