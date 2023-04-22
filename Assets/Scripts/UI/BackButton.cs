using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void Back2Menu()
    {
        SceneManager.LoadScene("_Menu");
    }
}