using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider volumeSlider;
    public AudioSource audioSource;
    public TMP_Text HowToPlayText;
    public TMP_Text pageNumber;
    public Image  HowToPlayImage;
    public float minValue = 0f;
    public float maxValue = 150f;

    [SerializeField] private GameObject  brightnessPanel;

    private string[] texts = { "Use WASD To Control Your Character", "Go With Any Merchant and Start Trading", "Click On Items You Want to Buy or Sell" , "Stand On A Magic Stone To Make Money , There Is A Way To Make Infinite Money Tyr To Find It" };
    [SerializeField] private Sprite[] images;
    private int currentIndex = 0;

    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    public void OnBrightnessChanged(float value)
    {
        float brightness = brightnessSlider.value;
        brightnessPanel.GetComponent<Image>().color = new Color(0, 0, 0, brightness);
    }

    public void OnVolumeChanged(float value)
    {
        float volume = volumeSlider.value;
        audioSource.volume = volume;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    public void StartGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadNextPage()
    {
        currentIndex++;
        
        if (currentIndex >= texts.Length)
        {
            currentIndex = 0;
        }
        
        DisplayContentAtCurrentIndex();
    }
    
    public void LoadBackPage()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = texts.Length - 1; 
        }
        
        DisplayContentAtCurrentIndex();
    }
    
    private void DisplayContentAtCurrentIndex()
    {
        HowToPlayText.text = texts[currentIndex];
        HowToPlayImage.sprite = images[currentIndex];
        pageNumber.text = (currentIndex + 1).ToString();
    }
}
