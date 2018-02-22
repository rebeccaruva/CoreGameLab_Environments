//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class EnemySpawn : MonoBehaviour {

//    public GameObject enemyPrefab;

//    public int score = 0;
//    private int waspNum = 0;
//    private int waveCount = 0;
//    private int wave = 0;

//	// Use this for initialization
//	void Start () {
//        //run MakeEnemies once, but wait 10 seconds
//        //Invoke("MakeEnemies", 10f);

//        //run MakeEnemies, wait 0 seconds, and run every 5 seconds
//        //InvokeRepeating("MakeEnemies", 0f, 2f);

//        //MakeEnemies();

//        InvokeRepeating("simpleEnemies", 2f, 10f);

//    }
	
//	// Update is called once per frame
//	void Update () {
        
//	}

//    void simpleEnemies()
//    {
//       // if (waveCount < 3)
//        //{
//            for (int i = 4; i > waspNum; i--)
//            {
//                Vector2 spawnPos = new Vector2(Random.Range(10f, 12f), Random.Range(-5f, 5f));
//                GameObject wasp = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
//            }
//           // Debug.Log("infor"+waveCount);
//       // }

//        //if (waveCount < 3 && waspNum == 0)
//        //{
//          //  waspNum = 4;
//            //waveCount++;
//          //  Debug.Log(waveCount);
//        //}
//        //if(waveCount >= 3)
//        //{
//        //    Invoke("levelComplete", 5f);
//       // }
//    }

//    void levelComplete()
//    {
//        SceneManager.LoadScene("3-restart");
//    }

//    //void MakeEnemies() {
//    //    if (score >= 10 && wave == 0)
//    //    {
//    //        wave = 1;
//    //        for (int i = 0; i < waspNum; i++)
//    //        {
//    //            Vector2 spawnPos = new Vector2(Random.Range(10f, 12f), Random.Range(-5f, 5f));
//    //            GameObject hornet = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
//    //        }
//    //        //waspNum *= 2;
//    //    }

//    //    if (score >= 20 && wave == 1)
//    //    {
//    //        wave = 2;
//    //        for (int i = 0; i < waspNum*2; i++)
//    //        {
//    //            Vector2 spawnPos = new Vector2(Random.Range(10f, 12f), Random.Range(-5f, 5f));
//    //            GameObject hornet = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
//    //        }
//    //    }
//    //}
//}
