using UnityEngine;

public class PlayerHandSoundPlayer : MonoBehaviour
{
    public AudioClip hitSound; // Assign this in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;

        if (hitSound != null)
        {
            audioSource.clip = hitSound;
            Debug.Log("Hit sound assigned to player hand: " + hitSound.name);
        }
        else
        {
            Debug.LogError("Hit sound is null on player hand.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("Player hand hit target: " + other.gameObject.name);
            PlayHitSound();
        }
    }

    void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            Debug.Log("Playing hit sound from player hand.");
            audioSource.PlayOneShot(hitSound);
        }
        else
        {
            Debug.LogError("AudioSource or hitSound is null on player hand.");
        }
    }
}
