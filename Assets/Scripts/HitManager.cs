using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    GameObject scoreBoard;
    public bool needsDelivery = false;
    public Sprite deliveryIcon;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("UI");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       if(scoreBoard.GetComponent<UIHandler>().nextDelivery.sprite == deliveryIcon)
        {
            needsDelivery = true;
        }
        else
        {
            needsDelivery = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            Debug.Log("Score!");
            if (needsDelivery)
            {
                player.GetComponent<PlayerController>().playScoreSound();
                scoreBoard.GetComponent<UIHandler>().addScore(1);
                scoreBoard.GetComponent<UIHandler>().newDelivery();
            }
        }
    }

}
