using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Instruction")]
    public GameObject instruction;

    [Header("Settings")]
    public GameObject settingsPanel;

    public Sprite audioOn_sprite;
    public Sprite audioOff_sprite;
    public Image buttonAudioSetting;

    private bool isAudioOn;


    private void Start()
    {
        Time.timeScale = 1.0f;
        isAudioOn = true;
        buttonAudioSetting.sprite = audioOn_sprite;
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
        }
        else
        {
            isAudioOn = true;
            buttonAudioSetting.sprite = audioOn_sprite;
            // включение
        }
    }
}
