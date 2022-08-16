using System;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] g;

    public static GameObject thisCheck;

    private void Start()
    {
        if(tag.Equals("firstCheck"))
        {
            thisCheck = gameObject;
        }
    }
    void Update()
    {
        if(gameObject == thisCheck && Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = transform.position;
            if (!tag.Equals("firstCheck")) 
            {
                
                foreach (GameObject a in g)
                {
                    if (a.activeSelf == false)
                    {
                        switch (a.tag)
                        {
                            case "dirt":
                                StaticVar.SetDirt(StaticVar.GetDirt() - 1);
                                break;
                            case "seed":
                                StaticVar.SetSeeds(StaticVar.GetSeeds() - 1);
                                break;
                            case "squash":
                                StaticVar.SetSquash(StaticVar.GetSquash() - 1);
                                break;
                        }
                    }
                    a.SetActive(true);
                }
                for (int i = 0; i < thisCheck.transform.childCount; i++)
                {
                    Destroy(thisCheck.transform.GetChild(i).gameObject);
                }
            }
            else
            {
                g[0].SetActive(true);
                g[1].SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (thisCheck != null && thisCheck != gameObject)
        {
            thisCheck = gameObject;
            for(int i = 0; i<Convert.ToInt32(gameObject.name)-1; i++)
            {
                transform.parent.gameObject.transform.GetChild(i).transform.DetachChildren();
                transform.parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else thisCheck = gameObject;
        Debug.Log("touched");
    }
}
