using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneControll : MonoBehaviour
{
    private float speed = 0.3f;
    private Vector3 direction;
    private float windPower;
    private Vector3 windDirection;
    public Slider flySpeed;
    public Slider flyAngle;

    private bool isLaunch;
    private float xDir, yDir;

    private Vector3 startPos;
    private float distance;

    private Rigidbody2D rb;

    private bool isStopRb;

    private void Start()
    {
        isStopRb = false;
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        isLaunch = false;

        xDir = RandomDirectionWind();
        yDir = RandomDirectionWind();

        windDirection = new Vector3 (xDir, yDir, 0.0f);
        GameManager.Instance.WindDirection(windDirection);
        RandomWind();

        startPos = transform.position;
    }
    private float RandomDirectionWind()
    {
        float _rand = Random.Range(-1.0f, 1.0f);
        return _rand;
    }
    private void RandomWind()
    {
        windPower = Random.Range(-0.7f, 0.999f);
        GameManager.Instance.WindForce(windPower);
    }
    private void FlySpeed()
    {
        speed = flySpeed.value;        
    }
    private void FlyAngle()
    {
        float angle = flyAngle.value;
        GameManager.Instance.FlyAngle(angle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        angle /= 100;
        direction = new Vector3(1.0f, angle, 0.0f);      
    }
    private void Update()
    {
        if (!isLaunch)
        {
            FlySpeed();
            FlyAngle();
        }
        distance = Vector3.Distance(startPos, transform.position);
        //Debug.Log(distance);
    }
    public void LaunchPlane()
    {
        isLaunch = true;
        rb.simulated = true;
        rb.AddForce((direction + windDirection) * (speed + windPower) * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isStopRb = true;
        }
    }
    private void FixedUpdate()
    {
        if (isStopRb)
        {
            if(rb.velocity.magnitude <= 0.3f)
            {
                Debug.Log(distance);
                GameManager.Instance.GameOver();                
            }
        }
    }
}