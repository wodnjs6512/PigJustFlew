using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objLooper : MonoBehaviour
{
    public float spawnWait = 0.5f;
    public float startWait = 1f;
    public float waveWait = 2f;
    public Vector2 spawnValues;
    public BirdMovement birdMove;
    public float offsetX;

    public GameObject obj;
    public GameObject hazard;
    public GameObject cloud1, cloud0;
    public GameObject gem;
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    // Update is called once per frame

    private void Start()
    {
        GameObject birdObj = GameObject.Find("Player");
        birdMove = birdObj.GetComponent<BirdMovement>();
        StartCoroutine(spawnObj());
        StartCoroutine(spawnObjCloud());
    }

    private void Update()
    {
        spawnValues.x = birdMove.transform.position.x + offsetX;
    }
    IEnumerator spawnObjCloud()
    {
        yield return new WaitForSeconds(0.3f);
        while (!birdMove.dead)
        {
            spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y + 5f, spawnValues.y + 7f),0f);
            spawnRotation = Quaternion.identity;

            if (Random.Range(0, 1) == 0)
                {
                    Instantiate(cloud0, spawnPosition, spawnRotation);
                }
                else
                {
                    Instantiate(cloud1, spawnPosition, spawnRotation);
                } 
            yield return new WaitForSeconds(0.7f);
        }
    }
    IEnumerator spawnObj()
    {
        int waveMax = 4;
        spawnRotation = Quaternion.Euler(0,0,0);
        yield return new WaitForSeconds(startWait);
        while (!birdMove.dead)
        {
            for (int rep = 1; rep < 4; rep++)
            {
                if (birdMove.dead) break;
                for (int i = 0; i < waveMax; i++)
                {
                    // Debug.Log("gen");
                   
                    if (birdMove.dead) break;

                    float value = (Random.Range(0f, 10f));
                    // gem gen
                    if (value > 9.3f)
                    {
                        spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y - 5f, spawnValues.y + 5f));
                        Instantiate(gem, spawnPosition, spawnRotation);
                    }
                    //bar gen
                    else if (value > 4f)
                    {
                        yield return new WaitForSeconds(spawnWait);
                        float bar = Random.Range(-spawnValues.y -5f, spawnValues.y + 5f);
                        spawnPosition = new Vector3(spawnValues.x, bar);
                        Instantiate(hazard, spawnPosition, spawnRotation);
                        if (Random.Range(0f, 1f) > 0.7f)
                        {
                            if (Random.Range(0, 1) == 0) { 
                                spawnPosition = new Vector3(spawnValues.x, bar + 5f);
                            }
                            else
                            {
                                spawnPosition = new Vector3(spawnValues.x, bar -5f);
                            }
                            Instantiate(hazard, spawnPosition, spawnRotation);
                        }
                    }
                    //feed gen
                    else {
                        spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y - 5f, spawnValues.y + 5f));
                        Instantiate(obj, spawnPosition, spawnRotation);
                    }

                    yield return new WaitForSeconds(spawnWait);
                }
            }
            if (waveMax < 30)
            {
                waveMax++;
            }
            else if (spawnWait > 0.2f)
            {
                spawnWait = spawnWait - 0.05f;
            }
            
        }

    }
}
