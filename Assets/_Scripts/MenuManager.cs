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
    public PaperPlaneData[] paperPlaneDatas;
    public TextMeshProUGUI planeNameText;
    public TextMeshProUGUI pricePlaneButtonText;
    public GameObject iconCoin;
    public TextMeshProUGUI weightPlaneText;
    public TextMeshProUGUI windResistanceText;
    public Button payButton;
    private int indexPlane;
    private int coins = 0;
    private int price;
    private int saveCountPlane;
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
        if (PlayerPrefs.HasKey("SaveIndexPay"))
        {
            saveCountPlane = PlayerPrefs.GetInt("SaveIndexPay");
        }
        else
        {
            saveCountPlane = 0;
        }
        //Debug.Log(saveCountPlane);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
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
    public void SelectPayButton()
    {
       if(saveCountPlane >= indexPlane)
        {
            PlayerPrefs.SetInt("CurrentSelectPlane", indexPlane);
            SceneManager.LoadScene("GameScene");
        }
        else if (saveCountPlane + 1 == indexPlane)
        {
            Pay();
        }
    }
    public void Pay()
    {
        coins -= price;
        saveCountPlane++;
        PlayerPrefs.SetInt("SaveIndexPay", saveCountPlane);
        payButton.interactable = true;
        pricePlaneButtonText.text = "Select";
        iconCoin.SetActive(false);
    }
    public void ShopButton()
    {
        shopPanel.SetActive(true);
        payButton.interactable = true;
        DataPlane(0);
    }
    public void ShopHomeButton()
    {
        shopPanel.SetActive(false);
    }
    public void ChangePlane(int _indexPlane)
    {
        indexPlane += _indexPlane;

        if (indexPlane > 3)
        {
            indexPlane = 0;
        }
        else if (indexPlane < 0)
        {
            indexPlane = 3;
        }        
        DataPlane(indexPlane);
    }
    public void DataPlane(int _index)
    {
        planeImg.sprite = paperPlaneDatas[_index].SpritePlane;
        planeNameText.text = paperPlaneDatas[_index].NamePlane;
        weightPlaneText.text = paperPlaneDatas[_index].WeightPlaneText;
        windResistanceText.text = paperPlaneDatas[_index].WindResistanceText;
        if(saveCountPlane >= _index)
        {
            payButton.interactable = true;
            pricePlaneButtonText.text = "Select";
            iconCoin.SetActive(false);            
        }
        else if (saveCountPlane + 1 == _index)
        {
            if (coins >= paperPlaneDatas[_index].PricePlane)
            {
                payButton.interactable = true;
            }
            else
            {
                payButton.interactable = false;
            }
            pricePlaneButtonText.text = paperPlaneDatas[_index].PricePlane.ToString();
            iconCoin.SetActive(true);            
        }
        else if(saveCountPlane + 1 < _index)
        {
            payButton.interactable = false;
            pricePlaneButtonText.text = paperPlaneDatas[_index].PricePlane.ToString();
            iconCoin.SetActive(true);            
        }
    }
}
