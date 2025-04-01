using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;//Pause menu game object


    /*private void Update()
    {
        //Create an if stateement to make a key interactive when the player wants to pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed - calling PauseGame()");
            PauseGame();//Call Pause game method to make the pausse menu visble
        }

    }*/
    public void PauseGame()
    {
        Debug.Log("The game pauses");
        pauseMenu.SetActive(true);//This will make the pause menu appear
    }
    public void HomePage()
    {
        SceneManager.LoadScene("SplashScreen");//Load the home page
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);//Resume the game
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Restart the game
        // Restart the Game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
