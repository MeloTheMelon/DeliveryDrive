using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public GameObject backgroundMusicSource;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Music").Length == 0)
        {
            GameObject bms = Instantiate(backgroundMusicSource);
            DontDestroyOnLoad(bms);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
