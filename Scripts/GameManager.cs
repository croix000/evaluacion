using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{ 
    private PlayerController player;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI powerText;
    int stoneCounter;
    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        player.onLifeStoneCollected += StoneCollected;
        player.onPowerUpdated += UpdatePowerUI;
        lifeText.text = "VIDAS: " + player.life;

        powerText.text = "Poder: " + player.power;
    }
    void StoneCollected()
    {
        stoneCounter++;

        if (stoneCounter == 3)
        {

            player.GiveLife();
            lifeText.text = "VIDAS: " + player.life;
        }
    }

    void UpdatePowerUI() {

        lifeText.text = "VIDAS: " + player.life;
        powerText.text = "Poder: " + player.power;
    }
}
