using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGetToPool : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // tetiklenince en uca yeni yol oluştur ve geçtiğimiz yolu havuza gönder.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            Invoke("sendObjectToPool", 3f); // daha güzel görünüm için 3 saniye bekle.
            triggerGenerateRoad();
        }   
    }

    private void sendObjectToPool() // havuza gönder.
    {
        gameObject.SetActive(false);
    }
    private void triggerGenerateRoad() // yeni yolu üret.
    {
        RoadGenerator.Instance.generateRoad();
    }
}
