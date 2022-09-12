using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParkTween : MonoBehaviour
{
    public GameObject Car;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        other.transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
        Car = other.gameObject;
        Debug.Log("Araba Geldi");
        StartCoroutine(Rotate());
    }
    public IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.5f);
        int randomPark;
        randomPark = Random.Range(0, 2);
        if (randomPark ==1)
        {
            Car.transform.DORotate(new Vector3(0, 180, 0), 1, RotateMode.FastBeyond360);
        }     
        Car.transform.GetComponent<BoxCollider>().enabled = false;
    }
}
