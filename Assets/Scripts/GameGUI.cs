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
    void Start()
    {
        StaticVar.varChange += UpdateUI;
    }
    private void UpdateUI()
    {
        dirt.text = StaticVar.GetDirt().ToString();
        seeds.text = StaticVar.GetSeeds().ToString();
        squash.text = StaticVar.GetSquash().ToString();
    }
}
