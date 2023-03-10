using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen; 
    [SerializeField] private GameObject pauseMenu;
    
    private void Awake()
    {
        endScreen.SetActive(false);
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeInHierarchy)
                Pause(false);
            else
                Pause(true);
        }
    }

    public void GameOver()
    {
        endScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause(bool pausing)
    {
        pauseMenu.SetActive(pausing);

        if(pausing)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void VolumeSound()
    {
        SoundManager.instance.ChangeVolumeSound(0.2f);
    }

    public void VolumeMusic()
    {
        SoundManager.instance.ChangeVolumeMusic(0.2f);
    }
}
