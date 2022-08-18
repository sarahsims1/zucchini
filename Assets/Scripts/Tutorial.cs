using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

/// <summary>
/// I only needed to use any kind of dialog system for this part, so I threw together some coroutines. 
/// </summary>
public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject bg;

    [SerializeField]
    private TMP_Text tutorialText;

    [SerializeField]
    private GameObject tt1;

    [SerializeField]
    private GameObject tt2;

    [SerializeField]
    private GameObject tt3;

    [SerializeField]
    private GameObject tt4;

    [SerializeField]
    private GameObject tt5;

    private bool touchingTt6;

    [SerializeField]
    private GameObject cp;

    [SerializeField]
    private float offSetx;

    [SerializeField]
    private float offSety;

    private int counter;


    void Start()
    {
        StartCoroutine(TutorialTalk());
    }

    private void Update()
    {
        if(!tt5.activeSelf && counter == 0)
        {
            StartCoroutine(TutorialDirt());
            counter++;
        }
    }
    private IEnumerator TutorialTalk()
    {
        tutorialText.text = "Use the A and D or arrow keys to move.";
        yield return new WaitUntil(() => !tt1.activeSelf && !tt2.activeSelf);
        tutorialText.text = "Once you collect some dirt and one seed, you can Press E to plant a \"Lightning Leek (TM)\" Use it to climb to places that are out of reach.";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(TutorialCont());
    }

    private IEnumerator TutorialCont()
    {
        tutorialText.text = "If you make a mistake, hit R to go back to the last flagpole you touched.";
        yield return new WaitUntil(() => !tt3.activeSelf && !tt4.activeSelf);
        bg.transform.position += new Vector3(offSetx, offSety, 0);
        tutorialText.text = "Of course, you can't plant on leaves. That's just silly. Why don't you try planting on that chunk of hovering earth over there instead?";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) && StaticVar.GetSeeds() == 0);
        yield return new WaitForSeconds(0.1f);
        tutorialText.text = "Great job. That's about everything! Try to get as many squash as you can for the pie, okay?";
        yield return new WaitForSecondsRealtime(5);
        bg.transform.position += new Vector3(-offSetx, -offSety, 0);
        bg.SetActive(false);
        tutorialText.text = ""; 
    }

    private IEnumerator TutorialDirt()
    {
        tutorialText.text = "Sorry to keep bothering you, but I thought I would explain...";
        yield return new WaitForSeconds(3f);
        tutorialText.text = "If you have some extra dirt on you, try pressing Q while standing on a leaf.";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q) && touchingTt6);
        tutorialText.text = "Cool, right? What? did you think that this was just reqular old dirt? Now you can grow things there.";
        yield return new WaitForSecondsRealtime(5);
        tutorialText.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("leaf"))
        {
            touchingTt6 = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("leaf") && counter > 1)
        {
            //cheat to make the bool stay on false for one more frame
            touchingTt6 = false;
            counter++;
        }
    }

}
