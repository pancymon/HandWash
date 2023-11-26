using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
  public Slider kindSlider;
  public Slider intervalSlider;
  public Slider timeSlider;
  public Button startButton;

  public Vector3 QRPos = Vector3.zero;
  public int kinds = 10;
  public GameObject[] viruses;
  public float difficultyLevel = 1f;
  public float totalTime = 60f;
  private float startTime = -1;
  private float lastSpawnTime = -1f;
  private bool started = false;

  public void KindSliderValueChange()
  {
    kinds = (int)kindSlider.value;
  }

  public void TimeSliderValueChange()
  {
    totalTime = timeSlider.value;
  }

  public void IntervalSliderChange()
  {
    difficultyLevel = intervalSlider.value;
  }

  public void OnButton()
  {
    started = true;
  }

  private void Start()
  {
    KindSliderValueChange();
    TimeSliderValueChange();
    IntervalSliderChange();
  }

  public void SpawnRandom()
  {
    int kind = Random.Range(0, kinds);
    var prefab = viruses[kind];

    Vector3 spawnPos = QRPos + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1, 1f));
    GameObject go = Instantiate(prefab, spawnPos, prefab.transform.rotation);
    go.AddComponent<Virus>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!started)
    {
      return;
    }

    if (startTime < 0)
    {
      startTime = Time.time;
    }

    if (Time.time - lastSpawnTime > difficultyLevel)
    {
      SpawnRandom();
      lastSpawnTime = Time.time;
    }

    if (Time.time - startTime > totalTime)
    {
      started = false;
      var all = FindObjectsOfType<Virus>();
      foreach (var d in all)
      {
        d.gameObject.active = false;
      }
    }
  }
}
