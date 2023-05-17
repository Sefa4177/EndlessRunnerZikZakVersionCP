using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Aşağı düşüşlerde oyunu durduran kod.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            Clock.instance.stopClock = true;
            GameButtons.Instance.gameOver = true;
        }   
    }
}
