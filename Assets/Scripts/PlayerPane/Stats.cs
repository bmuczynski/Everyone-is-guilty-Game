using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI hp, accuracy, dodgeChance;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        hp.text = "Health :"+ "0";
        accuracy.text = "Accuracy :"+"0";
        dodgeChance.text = "Dodge Chance :"+"0";
    }
}
