using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParkTween : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Araba Geldi");
        other.transform.DORotate(new Vector3(0, 180, 0), 1, RotateMode.FastBeyond360);
        other.transform.GetComponent<BoxCollider>().enabled = false;
    }
}
