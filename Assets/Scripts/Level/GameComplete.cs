using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameComplete : MonoBehaviour
{
    [SerializeField] AudioClip ggSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.tag == "Player")
        SceneManager.LoadScene("Complete");
        SoundManager.instance.PlaySound(ggSound);
    }
}
