using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "dirt":
                StaticVar.SetDirt(StaticVar.GetDirt() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetDirt());
                break;
            case "seeds":
                StaticVar.SetSeeds(StaticVar.GetSeeds() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetSeeds());
                break;
            case "squash":
                StaticVar.SetSquash(StaticVar.GetSquash() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetSquash());
                break;
        }
    }
}
