using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public PlayerController player;
    public Animator animator;
    private Vector3 direction;
    public GameObject tutor;
    //replay level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }
    public void hd()
    {
        tutor.SetActive(true);
    }
    
    public void dichuyenx()
    {
        float hInput = 1;
        if(Input.GetMouseButton(0));
        {
            direction.x = hInput * player.speed;
            animator.SetFloat("speed", Mathf.Abs(hInput));
        }
    }
}
