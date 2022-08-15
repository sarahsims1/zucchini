
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private GameObject plant;

    [SerializeField]
    private int plantHeight;

    [SerializeField]
    private float growthTime;

    private float time;

    private bool ready;

    Vector3 place;

    Quaternion turn;

    int grown;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && StaticVar.GetDirt() > 1 && StaticVar.GetSeeds() > 1 && !ready)
        {
            ready = true;
            place = transform.position;
            turn = transform.rotation;
            grown = 0;
            
        }
        if(ready)
        {
            time += Time.deltaTime;  
        }
        if(ready && time > growthTime && grown<plantHeight)
        {
            Instantiate(plant, place, turn);
            place += new Vector3(0, plant.GetComponent<BoxCollider2D>().size.y * 5, 0);
            time = 0;
            grown++;
 
        }
        else if(grown==plantHeight)
        {
            ready = false;
        }
    }
}
