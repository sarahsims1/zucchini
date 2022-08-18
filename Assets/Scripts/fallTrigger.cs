using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrigger : MonoBehaviour
{
    public static bool hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            hit = true;
            Debug.Log("Hit!");
    }
}
