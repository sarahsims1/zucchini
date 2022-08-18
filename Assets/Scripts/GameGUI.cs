using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameGUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dirt;
    [SerializeField]
    private TMP_Text seeds;
    [SerializeField]
    private TMP_Text squash;

    //Tagging on the audio here because it's simple.

    [SerializeField]
    private new AudioSource audio;

    [SerializeField]
    private AudioClip pop;
    void Start()
    {
        StaticVar.varChange += UpdateUI;
    }
    private void UpdateUI()
    {
        dirt.text = StaticVar.GetDirt().ToString();
        seeds.text = StaticVar.GetSeeds().ToString();
        squash.text = StaticVar.GetSquash().ToString();
        audio.PlayOneShot(pop);
    }
}
