using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{   
    #region Definitons
    public static GameButtons Instance;
    public bool gameOver;
    public int score;
    private int star_;
    [SerializeField] private GameObject LosePopUp;
    [SerializeField] private List<GameObject> StarImages;
    [SerializeField] private Text ScoreText;

    #endregion
    private void Awake() 
    {
        if(Instance)
        {
            Destroy(Instance);
        }

        Instance = this;  

        QualitySettings.vSyncCount = 0;  
    }
    private void Start() 
    {
        gameOver = false;  
        star_ = 0; 
        score = 0;
    }
    private void Update() 
    {
        if(gameOver)
        {
            doGameOver();
        }
    }
    #region Methods
    private void doGameOver()// oyunu bitiren method
    {   
        LosePopUp.SetActive(true);
        Time.timeScale = 0;
        starCreate();
        showScore();
    }
    private void starNumber()//oyun sonunda score a göre ekranda belirecek yıldız sayısını ayarlayan method.
    {   
        if(score >= 30)
        {
            star_ = 5;
        }
        else if(score >= 20)
        {
            star_ = 4;
        }
        else if(score >= 10)
        {
            star_ = 3;
        }
        else if(score >= 3)
        {
            star_ = 2;
        }
        else
        {
            star_ = 1;
        }

    }
    private void starCreate()//oyun sonunda yıldızların açılması
    {   
        starNumber();
        for(int star = 0 ; star < star_ ; star++)
        {
            StarImages[star].SetActive(true);
        }
    }

    private void showScore()//oyun sonunda skorun gösterilmesi için.
    {
        ScoreText.text =$"Score : {score}";
    }
     public void LoadScene(string sceneName)//sahne yüklemek gerektiğinde kullanılacak.
    {    
        SceneManager.LoadScene(sceneName);
    }
    
    #endregion
}
