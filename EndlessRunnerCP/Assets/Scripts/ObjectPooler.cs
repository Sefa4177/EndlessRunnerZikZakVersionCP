using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Definitions
    public static ObjectPooler Instance; 
    [SerializeField] private GameObject pooledObjectRoad; // Havuz için Road Objesının prefabı
    [SerializeField] private GameObject pooledObjectCoin; // Havuz için coin Objesının prefabı
    [SerializeField] private GameObject pooledObjectObstacle; // Havuz için Obstacle Objesının prefabı
    [SerializeField] private int  pooledAmount; // Ekstra olarak pool a eklenıcek eleman sayısı yedek gibi
    List<GameObject> pooledObjectsRoad; // Road objesi için havuz 
    List<GameObject> pooledObjectsCoin; // Coin objesi için havuz 
    List<GameObject> pooledObjectsObstacle; // Obstacle objesi için havuz 
    #endregion

    private void Awake() 
    {
        if(Instance)
        {
            Destroy(Instance);
        }

        Instance = this;    
    }
    void Start()
    {
        listDefinitions();
        roadPoolStartMethod();
        coinPoolStartMethod();
        obstaclePoolStartMethod(); 
    }

    #region Start Methods

    private void listDefinitions() // listlerin tanımlanıp örneklenmesi.
    {
        pooledObjectsRoad = new List<GameObject>();
        pooledObjectsCoin = new List<GameObject>();
        pooledObjectsObstacle = new List<GameObject>();
    }

    private void roadPoolStartMethod() // başlangıçta bulunan yol parçalarının ve sonradan eklenecek yol objelerının havuza eklenmesi
    {
        int childCounts = GameObject.Find("Roads").transform.childCount;

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject objR = (GameObject)Instantiate(pooledObjectRoad);
            objR.SetActive(false);
            pooledObjectsRoad.Add(objR);
        }
        for(int i = 0; i < childCounts; i++)
        {
            pooledObjectsRoad.Add(GameObject.Find("Roads").transform.GetChild(i).gameObject);
        }

    }

    private void coinPoolStartMethod() // coin objelerinin havuza eklenmesi
    {
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject objC = (GameObject)Instantiate(pooledObjectCoin);
            objC.SetActive(false);
            pooledObjectsCoin.Add(objC);
        }
    }

    private void obstaclePoolStartMethod() // obstacle objelerinin havuza eklenmesi
    {
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject objO = (GameObject)Instantiate(pooledObjectObstacle);
            objO.SetActive(false);
            pooledObjectsObstacle.Add(objO);
        }
    }
    #endregion

    #region Get Methods
    public GameObject GetPooledObjectRoad() //havuzdan bir road objesi cekilmesi işlemi ve eğer yoksa yeni bir tane üretilmesi işlemi
    {
        
        for(int i = 0; i < pooledObjectsRoad.Count; i++ )
        {
            if(!pooledObjectsRoad[i].activeInHierarchy)
            {
               return pooledObjectsRoad[i];
            }
        }

        GameObject objR = (GameObject)Instantiate(pooledObjectRoad);
        objR.SetActive(false);
        pooledObjectsRoad.Add(objR);
        return objR;
        
    }
    public GameObject GetPooledObjectCoin() //havuzdan bir coin objesi cekilmesi işlemi ve eğer yoksa yeni bir tane üretilmesi işlemi
    {
        
        for(int i = 0; i < pooledObjectsCoin.Count; i++ )
        {
            if(!pooledObjectsCoin[i].activeInHierarchy)
            {
               return pooledObjectsCoin[i];
            }
        }

        GameObject objC = (GameObject)Instantiate(pooledObjectCoin);
        objC.SetActive(false);
        pooledObjectsCoin.Add(objC);
        return objC;
        
    }
    public GameObject GetPooledObjectObstacle() //havuzdan bir pbstacle objesi cekilmesi işlemi ve eğer yoksa yeni bir tane üretilmesi işlemi
    {
        
        for(int i = 0; i < pooledObjectsObstacle.Count; i++ )
        {
            if(!pooledObjectsObstacle[i].activeInHierarchy)
            {
               return pooledObjectsObstacle[i];
            }
        }

        GameObject objO = (GameObject)Instantiate(pooledObjectObstacle);
        objO.SetActive(false);
        pooledObjectsObstacle.Add(objO);
        return objO;
        
    }

    #endregion
}
