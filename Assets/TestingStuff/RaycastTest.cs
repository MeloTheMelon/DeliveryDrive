using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 0, leftOrRight)), out hit, Mathf.Infinity))
        //{


        //Right Side
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(3f, 0, -1f) *20 ), Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 0.4f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 0.3f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 0.2f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 0.1f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 0.0f)) * 10, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.0f, 0, -1f)) * 20, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, -0.2f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, -0.3f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, -0.4f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, -0.5f)) * 10, Color.yellow);


        //Left Side
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.5f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.4f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.3f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.2f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.1f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 0.0f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, -0.1f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, -0.2f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, -0.3f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, -0.4f)) * 10, Color.yellow);
        //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, -0.5f)) * 10, Color.yellow);

        //  spawnedBullet.GetComponent<BulletController>().setMoveTowards(hit.transform.gameObject);

        //}
    }
}
