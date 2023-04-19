using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen; 
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject HTP;
    [SerializeField] private GameObject HTP2;

    private void Awake()
    {
        endScreen.SetActive(false);
        pauseMenu.SetActive(false);
        HTP.SetActive(false);
        HTP2.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(true);
        }
    }

    public void GameOver()
    {
        endScreen.SetActive(true);
    }

    public void Restart()
    {
        endScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
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

    public void HowToPlay()
    {
        HTP.SetActive(true);
    }
    public void Back1()
    {
        HTP.SetActive(false);
    }
    public void Next1()
    {
        HTP2.SetActive(true);
        HTP.SetActive(false);
    }
    public void Back2()
    {
        HTP2.SetActive(false);
        HTP.SetActive(true);
    }
}