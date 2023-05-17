
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField]
    private GameObject playerRef;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
       
    }

    void Paused()
    {
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        playerRef.GetComponent<movement>().canJump = false;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1;
        gameIsPaused = false;
        playerRef.GetComponent<movement>().canJump = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
