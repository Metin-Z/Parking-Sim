using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;
    public bool CarMove = true;
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
       
    }
    private void Update()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 2.35f);
    }
   
}