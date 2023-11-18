using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private AudioSource backgroundMusic;
    [SerializeField] private GameObject muteButton;
    private bool isMuted = false;

    void Start()
    {
        backgroundMusic = FindObjectOfType<AudioSource>();
        UpdateButtonText();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); 
    }
    
    public void MuteMusic()
    {
        isMuted = !isMuted;
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = isMuted;
        }
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        TextMeshProUGUI buttonText = muteButton.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = isMuted ? "Muted" : "Mute";
            buttonText.color = isMuted ? Color.red : Color.white; // Change color to red if muted, white when not
        }
    }
}

