using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.PingPong(Time.time * 60, 90), 0));
    }
}
