using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{    
    [Header("Instruction")]
    public GameObject instruction;

    [Header("Settings")]
    public GameObject settingsPanel;

    [Header("AudioSettings")]
    public Sprite audioOn_sprite;
    public Sprite audioOff_sprite;
    public Image buttonAudioSetting;

    [Header("DifficultySettings")]
    public Image[] imageButtons;

    [Header("Coins")]
    public TextMeshProUGUI coinsText;

    [Header("Shop")]
    public GameObject shopPanel;
    public Image planeImg;
    public Sprite[] planes;
    public TextMeshProUGUI planeNameText;
    public TextMeshProUGUI pricePlaneButtonText;
    private int indexPlane;
    private List<int> purchasedPlanes = new List<int>();

    private int coins;

    private bool isAudioOn;


    private void Start()
    {
        PlayerPrefs.SetInt("indexDifficulty", 2);
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        coinsText.text = coins.ToString();
        Time.timeScale = 1.0f;
        isAudioOn = true;
        buttonAudioSetting.sprite = audioOn_sprite;
        if (PlayerPrefs.HasKey("SavePay"))
        {
            for(int i = 0; i < PlayerPrefs.GetString("SavePay").Length; i++)
            {
                purchasedPlanes[i] = ((int)char.GetNumericValue(PlayerPrefs.GetString("SavePay")[i]));
            }
        }
        else
        {
            purchasedPlanes[0] = 0;
        }
    }
    
    // Инструкция
    public void InstructionButton()
    {
        instruction.SetActive(true);
    }
    public void HomeButInstruction()
    {
        instruction.SetActive(false);
    }

    // Настройки
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }
    public void HomeButSettings()
    {
        settingsPanel.SetActive(false);
    }
    public void AudioSettingButton()
    {
        if (isAudioOn)
        {
            isAudioOn = false;
            buttonAudioSetting.sprite = audioOff_sprite;
            // отключение звуков
            AudioListener.volume = 0.0f;
        }
        else
        {
            isAudioOn = true;
            buttonAudioSetting.sprite = audioOn_sprite;
            // включение звуков
            AudioListener.volume = 1.0f;
        }
    }
    public void DifficultySetting(int _index)
    {        
        for(int i = 0; i < imageButtons.Length; i++)
        {
            if(i != _index)
            {
                imageButtons[i].color = new Color(1, 1, 1, 0);
            }
            else if(i == _index)
            {
                imageButtons[i].color = new Color(1, 1, 1, 1);
            }
        }
        PlayerPrefs.SetInt("indexDifficulty", _index);
        // потом взять аргумент и сохранить
        // ну а потом загрузить этот аргумент в игровой сцене в контроллере - 
        // где настраивается ветер и угол, чтобы их отключать-включать
        // в зависимости от цифры аргумента
        // а enum здесь видимо и не нужен
    }
    public void PlayButton()
    {
        for (int i = 0; i < purchasedPlanes.Count; i++)
        {
            if (indexPlane == purchasedPlanes[i])
            {
                SceneManager.LoadScene("GameScene");
            }
            // 
        }
    }
    public void ShopButton()
    {
        shopPanel.SetActive(true);
        planeImg.sprite = planes[indexPlane];
    }
    public void ShopHomeButton()
    {
        shopPanel.SetActive(false);
    }
    public void ChangePlane(int _indexPlane)
    {
        indexPlane += _indexPlane;
        if(indexPlane > 3)
        {
            indexPlane = 0;
        }
        else if(indexPlane < 0)
        {
            indexPlane = 3;
        }
        planeImg.sprite = planes[indexPlane];
        switch(indexPlane)
        {
            case 0:
                planeNameText.text = "Dart paper plane";
                break;
            case 1:
                planeNameText.text = "Glider paper plane";
                break;
            case 2:
                planeNameText.text = "Arrow paper plane";
                break;
            case 3:
                planeNameText.text = "Canard paper plane";
                break;
        }
    }
}
