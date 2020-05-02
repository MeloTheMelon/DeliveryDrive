using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

    public float startSpeed = 10f;
    float speedIncrease = 0.5f;

    float lane1ZPos = 7.5f;
    float lane2ZPos = 4.5f;


    float endZValue = 7.1f;

    private bool gyroEnabled;
    private Gyroscope gyro;

    private Vector2 touchStart = Vector2.zero;
    private Vector2 touchDif = Vector2.zero;
    private float threshold = 150f;

    private UIHandler scoreBoard;

    private bool bulletCooldownBool = false;

    private bool gamePause = false;

    // Start is called before the first frame update
    void Start()
    {
        endZValue = this.transform.position.z;
        gyroEnabled = enableGyro();
        scoreBoard = GameObject.FindGameObjectsWithTag("UI")[0].GetComponent<UIHandler>();
}

    // Update is called once per frame
    void Update()
    {

        if (gyroEnabled)
        {
            Vector3 rotation = gyro.attitude.eulerAngles;
            if (rotation.y < 330 && rotation.y > 280)
                endZValue = lane2ZPos;
            if (rotation.y > 30 && rotation.y < 90)
                endZValue = lane1ZPos;
        }

        if (Input.touches.Length != 0)
        {
            //Tap to shoot package
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (Input.touches[0].position.x < Screen.width / 2)
                {
                    Debug.Log("Touch Left");
                    areaBullet(1);
                }
                else
                {
                    Debug.Log("Touch Right");
                    areaBullet(-1);
                }
            }
        }

        if (Mathf.Abs(this.transform.position.z - endZValue) > 0.001f)
        {
            float lerpVal = (Mathf.Lerp(this.transform.position.z, endZValue, Time.deltaTime*10));
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, lerpVal);
            Debug.Log("This Z Pos: " + this.transform.position.z + ", endZValue: " + endZValue + ", lerpVal " + lerpVal);
        }

        if (Input.GetKeyDown(KeyCode.A) && this.transform.position.z != lane1ZPos)
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, lane1ZPos);
            endZValue = lane1ZPos;
            Debug.Log("Set endzValue: " + lane1ZPos);
            Debug.Log("Difference: " + Mathf.Abs(this.transform.position.z - endZValue));
        }

        if (Input.GetKeyDown(KeyCode.D) && this.transform.position.z != lane2ZPos)
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, lane2ZPos);
            endZValue = lane2ZPos;
            Debug.Log("Set endzValue: " + lane2ZPos);
            Debug.Log("Difference: " + Mathf.Abs(this.transform.position.z - endZValue));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            areaBullet(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            areaBullet(-1);
        }

        this.transform.Translate(new Vector3((startSpeed + (speedIncrease * scoreBoard.getScore()))*Time.deltaTime, 0, 0));
        //this.transform.LookAt(new Vector3(this.transform.position.x + 2, this.transform.position.y, endZValue));

        if (Input.GetKeyDown(KeyCode.P))
        {
            //PlayerPrefs.SetString("Highscores", "0 0 0 0 0");
            //PlayerPrefs.SetString("Highscore", "0");
            PlayerPrefs.DeleteKey("Tutorial");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            togglePause();
        }


    } 

    public float getEndZValue()
    {
        return endZValue;
    }

    private void shootBullet(int leftOrRight)
    {
        GameObject spawnedBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0,0,leftOrRight)), out hit, Mathf.Infinity))
        {
            
            spawnedBullet.GetComponent<BulletController>().setMoveTowards(hit.transform.gameObject);
            
        }
        spawnedBullet.GetComponent<BulletController>().setDirection(leftOrRight);
    }

    private void areaBullet(int leftOrRight)
    {

        if (!bulletCooldownBool)
        {

            RaycastHit hit;
            GameObject hitObject = null;
            Vector3 raycastDir = new Vector3(1f, 0, leftOrRight);

            GameObject spawnedBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);

            StartCoroutine(bulletCooldown());

            for (float i = 0; i <= 3f; i += 0.05f)
            {
                raycastDir.x = 3f - i;
                Debug.DrawRay(transform.position, transform.TransformDirection(raycastDir) * 10, Color.yellow);
                if (Physics.Raycast(transform.position, transform.TransformDirection(raycastDir), out hit, Mathf.Infinity))
                {
                    try
                    {
                        if (hit.transform.gameObject.GetComponent<HitManager>().needsDelivery)
                        {
                            hitObject = hit.transform.gameObject;
                            break;
                        }
                        else
                        {
                            if (hitObject == null)
                                hitObject = hit.transform.gameObject;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            if (hitObject != null)
                spawnedBullet.GetComponent<BulletController>().setMoveTowards(hitObject);
        }
    }

    private void togglePause()
    {
        if (gamePause)
        {
            Time.timeScale = 1;
            gamePause = false;
        }
        else
        {
            Time.timeScale = 0;
            gamePause = true;
        }
    }

    private bool enableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    IEnumerator bulletCooldown()
    {
        bulletCooldownBool = true;
        yield return new WaitForSeconds(0.5f);
        bulletCooldownBool = false;
    }

    public void playScoreSound()
    {
        this.GetComponent<AudioSource>().Play();
    }

}
