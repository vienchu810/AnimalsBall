using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScen : MonoBehaviour
{
    // Start is called before the first frame update
     public string sceneName;
    private int highScore = 0;
      public Text highScoreText; 

     private void  Start()
     {
         highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        highScoreText.text = "Best Score: " + highScore.ToString();
     }
    // Start is called before the first frame update
    public void ChangeScene()
    {
      

        SceneManager.LoadScene(sceneName);
    }

}
