using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    public GameObject ground;

    private GameObject lastGround;

    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        //GameObject firstGround = Instantiate(ground, new Vector3(-7.0f, -4.3f, 0.0f), Quaternion.identity);
        //firstGround.transform.parent = this.transform;
        //firstGround.GetComponent<Platform>().SetMeterText(0);

        for(int i = 0;  i < 301; i++)
        {
            if(i == 0)
            {
                GameObject _firstGround = Instantiate(ground);
                _firstGround.transform.parent = this.transform;
                _firstGround.GetComponent<Platform>().SetMeterText(i);
                _firstGround.transform.position = new Vector3(-7.0f, -4.3f, 0.0f);
                
               // Debug.Log(_firstGround.transform.position.x - (_firstGround.transform.localScale.x * 0.5f));
                lastGround = _firstGround;
            }
            if (i > 0)
            {
                float lastGroundRightEndX = -10.0f;
                float lastGroundWidth = lastGround.transform.localScale.x;
                float lastGroundStartX = lastGround.transform.position.x - (lastGroundWidth / 2);
                float lastGroundEndX = lastGroundStartX + lastGroundWidth;

                lastGroundRightEndX = Mathf.Max(lastGroundRightEndX, lastGroundEndX);

                GameObject _ground = Instantiate(ground);
                _ground.transform.parent = this.transform;
                _ground.GetComponent<Platform>().SetMeterText(i);

                //float groundWidth = _ground.transform.localScale.x;
                float width = _ground.GetComponent<Renderer>().bounds.size.x;
                // float groudCenter = lastGroundRightEndX + groundWidth / 2;
                float groudCenter = lastGroundRightEndX + width - 0.15f;
                //Debug.Log(groudCenter);

                _ground.transform.position = new Vector3(groudCenter, -4.3f, 0.0f);

                lastGround = _ground;
            }
        }
    }    
}
