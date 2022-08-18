using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //The plant stalk and platforms to be spawned
    [SerializeField]
    private GameObject plant;

    [SerializeField]
    private GameObject plantPlat;

    //Plant height, adjustable from editor
    [SerializeField]
    private int plantHeight;

    //The time is takes for pieces of the stalk to appear
    [SerializeField]
    private float growthTime;

    //The offset of platforms from the stalk
    [SerializeField]
    private float offSet;

    //Planting process controls
    private float time;

    private bool ready;

    private bool right;

    //where the stalk will spawn
    private Vector3 place;

    private Quaternion turn;

    //How many stalks have spawned
    private int grown;

    private int platformsGrown;

    private int plantsGrown;

    private GameObject g;


    private void Start()
    {
        
    }
    void Update()
    {
        //If the checkpoint has aborted, we stop growing the plant.
        if(checkpoint.Abort)
        {
            ready = false;
        }

        //If the player has dirt and seeds, and presses E, we can plant. Also, abort is turned off
        if(Input.GetKeyDown(KeyCode.E)  && !ready && ConditionCheck())
        {
            checkpoint.Abort = false;
            ready = true;
            g = new GameObject();
            StaticVar.SetDirt(StaticVar.GetDirt() - 1);
            StaticVar.SetSeeds(StaticVar.GetSeeds() - 1);
            place = transform.position - new Vector3(0,GetComponent<SpriteRenderer>().bounds.size.y/2);
            turn = transform.rotation;
        }

        //Starts the timer for growing effect
        if(ready)
        {
            time += Time.deltaTime;  
        }

        //Spawns parts of the stalk
        if (ready && time > growthTime && grown < plantHeight)
        {
            Instantiate(plant, place, turn).transform.parent = g.transform;

            //Associates plant with the current checkpoint so it can be destroyed if need be.
            if (checkpoint.thisCheck != null) g.transform.parent = checkpoint.thisCheck.transform;

            //On every third stalk spawn, we spawn a platform
            if (grown % 3 == 0 && grown != 0)
            {
                GameObject leek = Instantiate(plantPlat, place + new Vector3(offSet*Right(right),0,0), turn);
                leek.transform.parent = g.transform;
                if (right) leek.GetComponent<SpriteRenderer>().flipX = true;
                platformsGrown++;
                if (right) right = false; else right = true;
            }

            //Placement moves up, timer resets
            place += new Vector3(0, plant.GetComponent<SpriteRenderer>().bounds.size.y, 0);
            time = 0;
            grown++;
        }

        //If we reach the plant height, we stop
        else if(grown==plantHeight)
        {
            ready = false;
            plantsGrown++;
            grown = 0;
        }
    }

    //Method to determine whether a platform should spawn on the right or left
    private int Right(bool right)
    {
        if (right) return 1; else return -1;
    }

    //Checks conditions (did I really need to comment that)
    private bool ConditionCheck()
    {
        if (!GetComponent<Controller>().onGround) return false;
        if (StaticVar.GetDirt() == 0) return false;
        if (StaticVar.GetSeeds() == 0) return false;
        else return true;
    }

}
