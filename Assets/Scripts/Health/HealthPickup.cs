
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount;
    [SerializeField] private AudioClip pickupNoise;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupNoise);
            collision.GetComponent<Health>().AddHealth(healthAmount);
            gameObject.SetActive(false);

        }
    }

}
