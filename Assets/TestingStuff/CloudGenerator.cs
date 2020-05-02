using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudGenerator : MonoBehaviour
{
    public Image cloudImage;
    public float speed;
    public List<Sprite> cloudSprites;

    int cloudWidth;
    int cloudHeight;
    int speedAdjustment;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log((Screen.width + cloudWidth) / 2);

        speedAdjustment = (int) UnityEngine.Random.Range(0, speed / 3);

        cloudWidth = (int) cloudImage.GetComponent<RectTransform>().rect.width;
        cloudHeight = (int)cloudImage.GetComponent<RectTransform>().rect.height;

        cloudImage.sprite = cloudSprites[UnityEngine.Random.Range(0, cloudSprites.Count)];
        cloudImage.transform.position = new Vector3(-((Screen.width / 2) + (cloudWidth)/2) + this.transform.position.x, (Screen.height / 2) - (cloudHeight / 2) - UnityEngine.Random.Range(0, Screen.height / 4) + this.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cloudImage.transform.Translate((speed+ speedAdjustment)*Time.deltaTime, 0, 0);
        if(cloudImage.transform.position.x >= ((Screen.width + cloudWidth) / 2)+this.transform.position.x)
        {
            cloudImage.sprite = cloudSprites[UnityEngine.Random.Range(0, cloudSprites.Count)];
            cloudImage.transform.position = new Vector3(-((Screen.width / 2) + (cloudWidth) / 2) + this.transform.position.x, (Screen.height / 2) - (cloudHeight / 2) - UnityEngine.Random.Range(0, Screen.height / 4) + this.transform.position.y, 0);
            speedAdjustment = (int)UnityEngine.Random.Range(0, speed / 3);
        }
    }
}
