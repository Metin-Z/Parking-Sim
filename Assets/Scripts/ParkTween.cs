using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParkTween : MonoBehaviour
{
    public GameObject Car;
    CarSpawnList _carSpawn;
    private void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        other.transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
        Car = other.gameObject;
        Debug.Log("Araba Geldi");
        Car.layer = 8;
        StartCoroutine(Rotate());
    }
    public IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.5f);
        Car.transform.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.FastBeyond360);
    }
    private void OnTriggerExit(Collider other)
    {
        _carSpawn.ParkPos.Add(gameObject.transform);
        Car = null;
    }
}
