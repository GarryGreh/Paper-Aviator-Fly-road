using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI windForceText;
    public TextMeshProUGUI flyAngleText;
    public TextMeshProUGUI predictionText;
    public RectTransform directionWindIcon;
    public Transform windPartical;

    private int prediction;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
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
        //здесь нужно показывать дистанцию на экран и сравнивать с прогнозом
       Debug.Log(_distance);
        Time.timeScale = 0.0f;
    }
}
