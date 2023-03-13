using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class handleButton : MonoBehaviour
{
  public InputField theTextField;

  public void buttonBehaviour()
  {
    string userID = theTextField.text.ToString(); 
    PlayerPrefs.SetString("Name", userID);
    SceneManager.LoadScene("Level1");
  }

  public void Options()
  {
    SceneManager.LoadScene("Options");
  }

  public void Back()
  {
    SceneManager.LoadScene("_Menu");
  }

  public void Quit()
  {
    Application.Quit();
  }

  public void Refer()
  {
    SceneManager.LoadScene("References");
  }
  public void Retry()
  {
        SceneManager.LoadScene("Level1");
  }

}
