using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    bool canPutSprite = true;
    bool simple = true;
    bool lessSimple = false;
    bool hardMan = false;
    public int health;
    private int score;
    private int waspNum = 0;
    //private int waveCount = 0;
    //private int wave = 0;

    public Text scoreText;

    public GameObject flower;
    public GameObject butterfly;
    public GameObject boss;
    public GameObject enemyPrefab;
    public GameObject beez;
    private GameObject clone;

    public GameObject[] healthSprite = new GameObject[5];



    // Use this for initialization
    void Start () {
        health = 10; //full health
        score = 0; // no score yet

        UpdateScore();

        //StartCoroutine(SpawnWaves());
        InvokeRepeating("SimpleEnemies", 2f, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(score > 25 && simple)
        {
            CancelInvoke("SimpleEnemies");
            InvokeRepeating("LessSimpleEnemies", 5f, 9f);
            simple = false;
            lessSimple = true;
        } else if (score > 50 && lessSimple)
        {
            CancelInvoke("LessSimpleEnemies");
            InvokeRepeating("HardMan", 2f, 8f);
            lessSimple = false;
            hardMan = true;
        } else if (score > 100 && hardMan)
        {
            CancelInvoke("HardMan");
            Invoke("boss", 5f);
            hardMan = false;
            //InvokeRepeating("HardMan", 2f, 50f);
        }
        //       //UpdateScore();
        //make sure health is good first
        if (health > 10)
        {
            health = 10;
        }
        else if (health< 0)
        {
            health = 0;
        }

        //fix sprite according to health
        if (health >= 9 && health <= 10 && canPutSprite)
        {
            clone = Instantiate(healthSprite[4], transform.position, transform.rotation);
            canPutSprite = false;
        } else if (health >= 7 && health <= 8 && canPutSprite)
        {
            clone = Instantiate(healthSprite[3], transform.position, transform.rotation);
            canPutSprite = false;
        } else if (health >= 5 && health <= 6 && canPutSprite)
        {
            clone = Instantiate(healthSprite[2], transform.position, transform.rotation);
            canPutSprite = false;
        } else if (health >= 3 && health <= 4 && canPutSprite)
        {
            clone = Instantiate(healthSprite[1], transform.position, transform.rotation);
            canPutSprite = false;
        } else if (health >= 1 && health <=2 && canPutSprite)
        {
            clone = Instantiate(healthSprite[0], transform.position, transform.rotation);
            canPutSprite = false;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (health < 1)
        {
            ResetScore();
            SceneManager.LoadScene("3-restart");
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    //public void AddHealth(int newHealthValue)
    //{
    //    health += newHealthValue;
    //    Destroy(clone);
    //    canPutSprite = true;
    //    Debug.Log("health: " + health);
    //}

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Im here");
        Debug.Log("Score: " + score);
    }

    public void ResetScore()
    {
        health = 6;
        score = 0;
        UpdateScore();
    }

    void SimpleEnemies()
    {
        // if (waveCount < 3)
        //{
        for (int i = 4; i > waspNum; i--)
        {
            Vector2 spawnPos = new Vector2(Random.Range(8f, 10f), Random.Range(-5f, 5f));
            GameObject wasp = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Destroy(wasp, 15f);
        }
    }

    void LessSimpleEnemies()
    {
        Vector2 spawnPos3 = new Vector2(Random.Range(7f, 9f), Random.Range(-5f, 5f));
        GameObject flow = Instantiate(flower, spawnPos3, Quaternion.identity);
        for (int i = 4; i > waspNum; i--)
        {
            Vector2 spawnPos = new Vector2(Random.Range(8f, 10f), Random.Range(-5f, 5f));
            GameObject wasp = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Destroy(wasp, 15f);

            Vector2 spawnPos2 = new Vector2(Random.Range(7f, 9f), Random.Range(-5f, 5f));
            GameObject wasp2 = Instantiate(beez, spawnPos2, Quaternion.identity);
            Destroy(wasp2, 15f);
        }
        Vector2 spawnPos4 = new Vector2(Random.Range(7f, 9f), Random.Range(-5f, 5f));
        GameObject butter = Instantiate(butterfly, spawnPos4, Quaternion.identity);

        Destroy(flow, 20f);
        Destroy(butter, 20f);

    }

    void HardMan()
    {
        Vector2 spawnPos5 = new Vector2(8f, Random.Range(-4f, 4f));
        GameObject spicy = Instantiate(boss, spawnPos5, Quaternion.identity);
        SceneManager.LoadScene("4-end");
    }

        // Debug.Log("infor"+waveCount);
        // }

        //if (waveCount < 3 && waspNum == 0)
        //{
        //  waspNum = 4;
        //waveCount++;
        //  Debug.Log(waveCount);
        //}
        //if(waveCount >= 3)
        //{
        //    Invoke("levelComplete", 5f);
        // }
 

    //void LevelComplete()
    //{
    //    SceneManager.LoadScene("3-restart");
    //}

    //void MakeEnemies()
    //{
    //    if (score >= 10 && wave == 0)
    //    {
    //        wave = 1;
    //        for (int i = 0; i < waspNum; i++)
    //        {
    //            Vector2 spawnPos = new Vector2(Random.Range(10f, 12f), Random.Range(-5f, 5f));
    //            GameObject hornet = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    //        }
    //        //waspNum *= 2;
    //    }

    //    if (score >= 20 && wave == 1)
    //    {
    //        wave = 2;
    //        for (int i = 0; i < waspNum * 2; i++)
    //        {
    //            Vector2 spawnPos = new Vector2(Random.Range(10f, 12f), Random.Range(-5f, 5f));
    //            GameObject hornet = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    //        }
    //    }
    //}
}

//ienumerator spawnwaves()
//{
//    yield return new waitforseconds(startwait);
//    while (true)
//    {
//        for (int i = 0; i < hazardcount; i++)
//        {
//            vector3 spawnposition = new vector3(random.range(-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
//            quaternion spawnrotation = quaternion.identity;
//            instantiate(hazard, spawnposition, spawnrotation);
//            yield return new waitforseconds(spawnwait);
//        }

//        yield return new waitforseconds(wavewait);
//    }
//}
