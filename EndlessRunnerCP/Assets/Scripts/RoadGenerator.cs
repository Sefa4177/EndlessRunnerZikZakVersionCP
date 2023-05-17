using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public static RoadGenerator Instance;
    public GameObject LastRoad; // en uçtaki yolun verisini tutmak için değişken.

    private void Awake() 
    {
        if(Instance)
        {
            Destroy(Instance);
        }

        Instance = this;    
    }

    #region Generate Methods
    public void generateRoad() // yol üretir
    {
        int randomIndex = Random.Range(0,2); // yolun yönünü belirlemek için rastgele index.
        int coinObstacleDecisor = Random.Range(0,5); // yeni üretilen yolda engel mi yoksa coin mi olacağını belirlemek için random sayı.

        GameObject nextRoad = LastRoad.transform.GetChild(randomIndex).gameObject; //random olarak yolun konumunun belirlenmesi.
        GameObject newRoad = ObjectPooler.Instance.GetPooledObjectRoad(); // örnekleme yapılması.

        // yeni yolun pozisyon ve rotasyonunun verilmesi.
        newRoad.transform.position = nextRoad.transform.position;
        newRoad.transform.rotation = nextRoad.transform.rotation;

        // üretilen yolun üzerinde oluşacak engel veya coinin üretilmesi ve hazırlanması.
        generateCoin(coinObstacleDecisor);
        generateObstacle(coinObstacleDecisor);

        newRoad.SetActive(true); // hazırlanan yeni yolun aktif hale getirilmesi

        LastRoad = newRoad; // son yolun yeni üretilen yol olarak değiştirilmesi bu şekilde sürekli en uçtaki yolun son yol olması sağlanır.
        
    }

    private void generateCoin(int coinObstacleDecisor) // bu method her çalıştığında yalnızca ya coin ya engel üretir 
    {
        
        if(coinObstacleDecisor == 0 || coinObstacleDecisor == 1) // eğer random sayı 0 veya 1 ise coin üret
        {   
            // örnekleme ve lokasyon belirlenmesi
            GameObject coinLocation = LastRoad.transform.GetChild(2).gameObject; 
            GameObject newCoin = ObjectPooler.Instance.GetPooledObjectCoin();

            // pozizyon ve rotasyon belirlenmesi.
            newCoin.transform.position = coinLocation.transform.position;
            newCoin.transform.rotation = coinLocation.transform.rotation;

            newCoin.SetActive(true);
        }
        
    }
    private void generateObstacle(int coinObstacleDecisor) // eğer random sayı 3 ise engel üret bunun biraz daha az ihtimal olmasını istedim bu yüzden coine göre az ihitmal verdim.
    {
        if(coinObstacleDecisor == 3)
        {
            // örnekleme ve lokasyon belirlenmesi
            GameObject obstacleLocation = LastRoad.transform.GetChild(2).gameObject;
            GameObject newObstacle = ObjectPooler.Instance.GetPooledObjectObstacle();

            // pozizyon ve rotasyon belirlenmesi.
            newObstacle.transform.position = obstacleLocation.transform.position;
            newObstacle.transform.rotation = obstacleLocation.transform.rotation;

            newObstacle.SetActive(true);
        }
        
    }
    #endregion
}
