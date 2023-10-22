using UnityEngine;
using DG.Tweening;

public class Virus : MonoBehaviour
{
    public int v = 6;
    public float r = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(10f, new Vector3(0.1f, 0.1f, 0.1f), vibrato: v, randomness: r);
        transform.DORotate(new Vector3(20f, 180f, 60f), 1f).SetLoops(-1, LoopType.Restart);
        // Destroy(gameObject, 5f);
    }

    // void OnDisable()
    // {
    //     var spawner = FindObjectOfType<Spawner>();
    //     if (spawner)
    //     {
    //         spawner.SpawnRandom();
    //     }

    // }
}
