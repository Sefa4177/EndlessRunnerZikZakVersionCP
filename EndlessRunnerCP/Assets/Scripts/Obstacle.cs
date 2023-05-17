using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) // engele çarptığında oyunu durdur.
    {   
        if(other.gameObject.name.Equals("Character"))
        {
            Clock.instance.stopClock = true;
            GameButtons.Instance.gameOver = true;
        }
    } 
    private void OnTriggerEnter(Collider other) // kullanıcı carpmadan geçince 4 sanıye bekle ve objeyı havuza gönder.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            Invoke("sendObjectToPool", 4f);
        }   
    }

    private void sendObjectToPool() // set active i false yaparak havuza gönderme işlemi.
    {
        gameObject.SetActive(false);
    }

}
