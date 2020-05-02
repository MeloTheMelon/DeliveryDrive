using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SwipeTest : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 touchStart = Vector2.zero;
    private Vector2 touchDif = Vector2.zero;
    private float threshold = 150f;

    void Start()
    {
        Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.touches.Length != 0)
        {
            /*    

                if(Input.touches[0].phase == TouchPhase.Began)
                {
                    touchStart = Input.touches[0].position;
                }else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    if (Mathf.Sqrt(touchDif.x*touchDif.x + touchDif.y*touchDif.y) > threshold)
                    {
                        if(touchDif.x > 0)
                        {
                            Debug.Log("Swipe Left");
                        }
                        else
                        {
                            Debug.Log("Swipe Right");
                        }
                    }

                    touchStart = Vector2.zero;
                }
                touchDif = touchStart - Input.touches[0].position;
                
            */

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if(Input.touches[0].position.x < Screen.width / 2)
                {
                    Debug.Log("Touch Left");
                }
                else
                {
                    Debug.Log("Touch Right");
                }
            }

            

        }


    }
}
