using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI windForceText;
    public TextMeshProUGUI flyAngleText;
    public TextMeshProUGUI predictionText;
    public RectTransform directionWindIcon;
    public Transform windPartical;

    public GameObject GameOverPanel;
    public TextMeshProUGUI distanceTreveledText;
    public TextMeshProUGUI yourPredictionText;

    private int prediction;
    private int reward = 50;
    private int currentCoins;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        prediction = 0;
        GameOverPanel.SetActive(false);
    }
    public void WindForce(float _windForce)
    {
        _windForce *= 30;
        windForceText.text = _windForce.ToString("f1") + " ms";
    }
    public void WindDirection(Vector3 _direction)
    {        
        float angle = Mathf.Atan2(_direction.y - 0.0f, _direction.x - 0.0f) * Mathf.Rad2Deg;

        //Debug.Log(angle);
        directionWindIcon.eulerAngles = new Vector3(0.0f, 0.0f, angle);
        windPartical.eulerAngles = new Vector3(-angle, 90.0f, 0.0f);
    }
    public void FlyAngle(float _angle)
    {
        flyAngleText.text = _angle.ToString("f0") + "°";
    }
    public void PredictionButton(int _num)
    {
        prediction += _num;
        predictionText.text = prediction.ToString() + " m";
    }
    public void GameOver(int _distance)
    {
        GameOverPanel.SetActive(true);
        yourPredictionText.text = prediction.ToString();
        //здесь нужно показывать дистанцию на экран и сравнивать с прогнозом
        if (prediction + 1 == _distance || prediction - 1 == _distance || prediction == _distance)
        {
            currentCoins += reward;
            distanceTreveledText.text = _distance.ToString();
            distanceTreveledText.color = Color.green;
        }
        else if(prediction + 2 == _distance || prediction - 2 == _distance)
        {
            currentCoins += reward / 2;
            distanceTreveledText.text = _distance.ToString();
            distanceTreveledText.color = Color.yellow;
        }
        else if(prediction - 2 < _distance || prediction + 2 > _distance)
        {
            currentCoins += 0;
            distanceTreveledText.text = _distance.ToString();
            distanceTreveledText.color = Color.red;
        }
        Debug.Log(_distance);
        Time.timeScale = 0.0f;
    }
}
