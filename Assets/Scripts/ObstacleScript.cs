using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;
    MapGen mapGenScript;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        mapGenScript = GameObject.FindGameObjectsWithTag("MapGen")[0].GetComponent<MapGen>();
        this.transform.rotation = Quaternion.Euler(0, 270, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);

        if (this.transform.position.x < mapGenScript.getLastMapTilePosX() - 5)
        {
            mapGenScript.spawnObstacles();
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.transform.tag == "Player")
        {
            GameObject scoreBoard = GameObject.FindGameObjectWithTag("UI");
            PlayerPrefs.SetInt("Score", int.Parse(scoreBoard.GetComponent<UIHandler>().scoreText.text));
            SceneManager.LoadScene("GameOver");
        }
    }
}
