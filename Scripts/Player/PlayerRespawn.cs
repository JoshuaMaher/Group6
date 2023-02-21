using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private AudioClip checkpointNoise;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UImanager uiMan;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiMan = FindObjectOfType<UImanager>();
    }

    public void CheckForRespawn()
    {
        if(currentCheckpoint == null)
        {
            uiMan.GameOver();
            return;
        }

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointNoise);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
