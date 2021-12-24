using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins=0;
    public TextMeshProUGUI numberOfCoinsText;
    
    public static int currentHealth = 100;
    public Slider healthBar;

    public static bool gameOver;
    public static bool winLevel;

    public GameObject gameOverPanel;

    public float timer = 0;

    void Start()
    {
        
        gameOver = winLevel = false;
    }

    void Update()
    {
        //Hiển thị coins
        numberOfCoinsText.text = "coins:" + numberOfCoins;

        //Update the slider value
        healthBar.value = currentHealth;

        //game over
        if(currentHealth < 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            currentHealth = 100;
            numberOfCoinsText.text="coins:" + numberOfCoins;
        }

        if( FindObjectsOfType<Enemy>().Length ==0)
        {
            //Win Level
            winLevel = true;
            timer += Time.deltaTime;
            if(timer > 5)
            {
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextLevel == 5)
                    SceneManager.LoadScene(0);

                if(PlayerPrefs.GetInt("ReachedLevel", 1) < nextLevel)
                    PlayerPrefs.SetInt("ReachedLevel", nextLevel);

                SceneManager.LoadScene(nextLevel);
            }

        }
    }
}
