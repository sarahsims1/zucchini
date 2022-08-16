using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

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
    private GameObject greenBox;

    [SerializeField]
    private GameObject groundPlat;

    private bool checkPointsExplained;

    [SerializeField]
    private GameObject arrows;

    [SerializeField]
    private GameObject cp;

    [SerializeField]
    private GameObject wall;

    private bool insideBox;

    private bool onGroundPlat;

    private bool checkTouched;

    void Start()
    {
        StartCoroutine(TutorialTalk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TutorialTalk()
    {
        tutorialText.text = "Hi! My name is Marge. I'm here to teach you a little bit about gardening. The first this you need? Dirt and seed! You can pick them up over there. Use the A and D or arrow keys to move.";
        yield return new WaitUntil(() => !tt1.activeSelf && !tt2.activeSelf);
        tutorialText.text = "Great! Now you can plant them. My patented \"Lightning Leeks (TM)\" will grow up in no time! Press E inside of that green box over there to plant the leek and get up on that big squash leaf.";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.1f);
        if (insideBox)
        {
            StartCoroutine(TutorialCont());
        }
        else
        {
            tutorialText.text = "Great job! You can plant the leeks anywhere, but, uh... I don't think you can reach the leaf. Here let me give you some more seeds and dirt.";
            StaticVar.SetSeeds(1);
            StaticVar.SetDirt(1);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForSeconds(0.1f);
            if (insideBox)
            {
                StartCoroutine(TutorialCont());
            }
            else
            {
                tutorialText.text = "Umm... I did mention to plant it inside the green box, right? Here, try again.";
                StaticVar.SetSeeds(1);
                StaticVar.SetDirt(1);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                yield return new WaitForSeconds(0.1f);
                if (insideBox)
                {
                    StartCoroutine(TutorialCont());
                }
                else
                {
                    tutorialText.text = "I don't think you're quite getting the idea... INSIDE the box. The box is right here.";
                    arrows.SetActive(true);
                    StaticVar.SetSeeds(1);
                    StaticVar.SetDirt(1);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                    yield return new WaitForSeconds(0.1f);
                    if (insideBox)
                    {
                        StartCoroutine(TutorialCont());
                    }
                    else
                    {
                        tutorialText.text = "Alright, that does it. You're doing this on purpose, aren't you? Well FINE. If you don't want to play the game, you don't have to. Seeds don't grow on trees, ya know! Well--uh, nevermind. HERE. (Press E to Continue)";
                        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                        yield return new WaitForSeconds(0.1f);
                        StaticVar.SetFailed(true);
                        SceneManager.LoadScene("WinLose");

                    }
                }
            }
        }
    }

    private IEnumerator TutorialCont()
    {
        wall.SetActive(false);
        tutorialText.text = "Awesome job! Climb on up!";
        yield return new WaitUntil(() => !tt3.activeSelf && !tt4.activeSelf);
        tutorialText.text = "Of course, you can't plant on leaves. That's just silly. Why don't you try planting on that chunk of hovering earth over there instead?";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) && StaticVar.GetSeeds() == 0);
        yield return new WaitForSeconds(0.1f);
        if (onGroundPlat)
        {
            tutorialText.text = "Great! Hey, see that flagpole? That's a checkpoint. Once you touch one, you can press R to come back to it and reset any mistakes you may have made. Don't be afraid to use them if you get stuck!";
            yield return new WaitUntil(() => checkTouched);
            tutorialText.text = "Great job. That's about everything! Try to get as many squash as you can for the pie, okay?";
            yield return new WaitForSecondsRealtime(5);
            bg.SetActive(false);
            tutorialText.text = "";
        }
        else 
        {
            tutorialText.text = "Oh... seems you've softlocked yourself. Uh, I was going to explain checkpoints later, but now seems like a good time. If you press R, you'll be brought back to that flagpole, and the seeds and dirt will come back!";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
            yield return new WaitForSeconds(0.1f);
            tutorialText.text = "Awesome! You can do that as many times as you like, but bear in mind from now on, your plants will also dissappear, okay?";
            yield return new WaitForSecondsRealtime(6);
            tutorialText.text = "Anyway, that's about everything! Try to get as many squash as you can for the pie, okay?";
            yield return new WaitForSecondsRealtime(5);
            bg.SetActive(false);
            tutorialText.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == greenBox)
        {
            insideBox = true;
            Debug.Log("Touching!");
        }
        if(collision.gameObject == cp)
        {
            checkTouched = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == groundPlat)
        {
            onGroundPlat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == greenBox)
        {
            insideBox = false;
            Debug.Log("Not Touching!");
        }
        if (collision.gameObject == cp)
        {
            checkTouched = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == groundPlat)
        {
            onGroundPlat = false;
        }
    }
}
