using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLeaf : MonoBehaviour
{
    public GameObject ground;

    private GameObject thisLeaf;

    void Update()
    {
       if(CheckConditions() && Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(ground, thisLeaf.transform.position, thisLeaf.transform.rotation).transform.parent = checkpoint.thisCheck.transform;
            Destroy(thisLeaf);
            StaticVar.SetDirt(StaticVar.GetDirt() - 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("leaf"))
        {
            thisLeaf = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("leaf"))
        {
            thisLeaf = null;
        }
    }

    private bool CheckConditions()
    {
        if (StaticVar.GetDirt() == 0) return false;
        if (thisLeaf == null) return false;
        else return true;
    }
}
