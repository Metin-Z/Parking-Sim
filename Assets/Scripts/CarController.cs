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
        Move();
    }
    public void Move()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 2.1f);
        transform.LookAt(transform.parent,new Vector3(0,0,0));
        
    }
}