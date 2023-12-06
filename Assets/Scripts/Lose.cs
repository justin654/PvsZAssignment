using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lose : MonoBehaviour
{
    [SerializeField] private string loseSceneName = "GameOver";
    [SerializeField] private AudioClip eatingBrainsSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = eatingBrainsSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            PlayEatingBrainsSound();
            StartCoroutine(WaitAndLoadScene());
        }
    }

    private void PlayEatingBrainsSound()
    {
        audioSource.Play();
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return
            new WaitForSeconds(audioSource.clip.length); // we wait for the clip length before loading next scene
        SceneManager.LoadScene(loseSceneName);
    }
}