using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    private MainCharacter player;
    private Slider healthBar;
    private TextMeshProUGUI hpText;
    private TextMeshProUGUI accuracyText;
    private TextMeshProUGUI dodgeText;

    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        player = GameObject.Find("Player").GetComponent<MainCharacter>();
        hpText = GameObject.Find("hp").GetComponent<TextMeshProUGUI>();
        accuracyText = GameObject.Find("accuracy").GetComponent<TextMeshProUGUI>();
        dodgeText = GameObject.Find("dodgeChance").GetComponent<TextMeshProUGUI>();

        healthBar.maxValue = player.maxHealthPoints;
        healthBar.value = healthBar.maxValue;
        player.onHealthChanged += UpdateHealthBar;

        hpText.text = player.maxHealthPoints.ToString();
        accuracyText.text = player.accuracy.ToString();
        dodgeText.text = player.dodgeChance.ToString();
    }

    private void OnDisable()
    {
        player.onHealthChanged -= UpdateHealthBar;
    }


    private void UpdateHealthBar(float currentHp)
    {
        healthBar.value = currentHp;    
    }

}
