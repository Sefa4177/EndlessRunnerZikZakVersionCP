using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //objenın ustunden geçince altını toplama işlemini çalıştır.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            sendObjectToPool();
            collectGold();
        }   
    }
    private void OnBecameInvisible() // kamera açısından çıkınca çalış.
    {
        if(gameObject.activeInHierarchy)
        {
            sendObjectToPool();
        }
        
    }

    private void collectGold() // altın toplandı
    {
        GameButtons.Instance.score+= 1;
    }

    private void sendObjectToPool() // objeyı havuza gönder
    {
        gameObject.SetActive(false);
    }
}
