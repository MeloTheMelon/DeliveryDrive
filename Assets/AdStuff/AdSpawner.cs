using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdSpawner : MonoBehaviour
{

    public GameObject adHandler;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("AdCounter"))
            PlayerPrefs.SetInt("AdCounter", 0);

        if(GameObject.FindGameObjectsWithTag("adObject").Length == 0)
        {
            GameObject aH = Instantiate(adHandler);
            DontDestroyOnLoad(aH);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
