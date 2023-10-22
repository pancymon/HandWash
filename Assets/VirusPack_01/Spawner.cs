using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public int v = 6;
    public float r = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    void Spawn()
    {
        Vector3 spawnPos = character1.transform.position+new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1, 1f));
        GameObject go = Instantiate(character1, spawnPos, character1.transform.rotation);
        go.transform.DOShakePosition(10f, new Vector3(0.1f, 0.1f, 0.1f),vibrato:v,randomness:r);
        go.transform.DORotate(new Vector3(20f, 180f, 60f),1f).SetLoops(-1, LoopType.Restart);
        Destroy(go, 5f);

        Vector3 spawnPos2 = character2.transform.position + new Vector3(Random.Range(-1f, 0.8f), 0, Random.Range(-1f, 1f));
        GameObject go2 = Instantiate(character2, spawnPos2, character2.transform.rotation);
        go2.transform.DOShakePosition(10f, new Vector3(0.12f, 0.12f, 0.12f), vibrato: v, randomness: r);
        go2.transform.DORotate(new Vector3(120f, 280f, 100f), 2f).SetLoops(-1, LoopType.Restart);
        Destroy(go2, 5+Random.Range(0,2f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
