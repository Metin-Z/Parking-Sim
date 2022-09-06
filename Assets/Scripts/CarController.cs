using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;  
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
        if (_carSpawn.WaitFalsePos[0].GetComponent<WaitChecker>().IUsed == false)
        {
            transform.DOMove(new Vector3(
           _carSpawn.WaitFalsePos[0].position.x,
           _carSpawn.WaitFalsePos[0].position.y,
           _carSpawn.WaitFalsePos[0].position.z),
           3.25f);
        }
    }
}