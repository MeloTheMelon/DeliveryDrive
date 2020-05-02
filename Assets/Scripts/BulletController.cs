using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    int direction = 1;
    GameObject moveTowards;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfter(2)); 
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowards == null)
        {
            transform.Translate(new Vector3(0, 0, direction) * speed * Time.deltaTime);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveTowards.transform.position, step);
        }
    }

    public void setDirection(int directionValue)
    {
        direction = directionValue;
    }

    public void setMoveTowards(GameObject target)
    {
        moveTowards = target;
    }

    private IEnumerator destroyAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

}
