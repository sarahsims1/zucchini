using System;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] g;

    [SerializeField]
    private GameObject leaf;

    public static GameObject thisCheck;

    public static bool Abort;

    private void Start()
    {
        if(tag.Equals("firstCheck"))
        {
            thisCheck = gameObject;
        }
    }
    void Update()
    {
        //If the checkpoint we're at is the current checkpoint...
        if(gameObject == thisCheck && Input.GetKeyDown(KeyCode.R))
        {
            //Teleport player to point, abort any growing plants
            player.transform.position = transform.position;
            Abort = true;

            //This is a lot of gobledeygook that ensures that if the player misses a checkpoint, grabs an item related to another checkpoint, then spawns back, that those items will respawn.
            //It's a lot of parent/child references. Each item related to the checkpoint is its child. 

            GameObject parent = transform.parent.gameObject;

            int numberOfCheckpoints = parent.transform.childCount;

            //For each checkpoint above and including this one...
            for (int i = numberOfCheckpoints-1; i > Convert.ToInt32(gameObject.name)-2; i--)
            {
                
                GameObject child = parent.transform.GetChild(i).gameObject;

                //We check the items related to the checkpoint.
                for (int j = child.gameObject.transform.childCount - 1; j > -1; j--)
                {
                    GameObject item = child.gameObject.transform.GetChild(j).gameObject;

                    //If they're deactivated, we reactivated them and deduct the items from our "inventory".
                    if (!item.activeSelf)
                    {
                        item.SetActive(true);
                        switch (item.tag)
                        {
                            case "dirt":
                                StaticVar.SetDirt(StaticVar.GetDirt() - 1);
                                break;
                            case "seeds":
                                StaticVar.SetSeeds(StaticVar.GetSeeds() - 1);
                                break;
                            case "squash":
                                StaticVar.SetSquash(StaticVar.GetSquash() - 1);
                                break;
                        }
                    }

                    //Turns ground back into leaves (sneaky)
                    else if(item.tag.Equals("ground"))
                    {
                        Instantiate(leaf, item.transform.position, item.transform.rotation).transform.parent = null;
                        Destroy(item);
                    }
                    //If they are active, we check tags. Anything thats not a pickup is a plant, and is destroyed.
                    else if(!item.tag.Equals("dirt") && !item.tag.Equals("seeds") && !item.tag.Equals("squash"))
                    {
                        Destroy(item);
                    }
                }
            }
        }
    }
    
    //This destroys old checkpoints to prevent confusion.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (thisCheck != null && thisCheck != gameObject)
            {
                //Turns the flag green for visual feedback (fancy words)
                GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                
                thisCheck = gameObject;
                for (int i = 0; i < Convert.ToInt32(gameObject.name) - 1; i++)
                {
                    transform.parent.gameObject.transform.GetChild(i).transform.DetachChildren();
                    transform.parent.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else thisCheck = gameObject;
        }
    }
}
