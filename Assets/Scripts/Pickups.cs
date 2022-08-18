using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private new AudioSource audio;

    [SerializeField]
    private AudioClip pop;
    //Increments variables when picked up
    private void Start()
    {
        StaticVar.SetDirt(0);
        StaticVar.SetSeeds(0);
        StaticVar.SetSquash(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "dirt":
                StaticVar.SetDirt(StaticVar.GetDirt() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetDirt());
                audio.PlayOneShot(pop);
                break;
            case "seeds":
                StaticVar.SetSeeds(StaticVar.GetSeeds() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetSeeds());
                audio.PlayOneShot(pop);
                break;
            case "squash":
                StaticVar.SetSquash(StaticVar.GetSquash() + 1);
                collision.gameObject.SetActive(false);
                Debug.Log(StaticVar.GetSquash());
                audio.PlayOneShot(pop);
                break;
        }
    }
}
