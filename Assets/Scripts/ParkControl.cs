using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParkControl : MonoBehaviour
{
    CarSpawnList _carSpawn;
    public void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            _carSpawn.WaitedCars.Remove(_carSpawn.WaitedCars.FirstOrDefault());
            StartCoroutine(TrafficController());
            other.transform.parent = null;
            other.transform.parent = _carSpawn.ParkPos[0];
            _carSpawn.ParkPos.Remove(_carSpawn.ParkPos.FirstOrDefault());
        }
    }
    public IEnumerator TrafficController(){
        yield return new WaitForSeconds(1.5f);
        _carSpawn.WaitedCars[0].transform.parent = _carSpawn.WaitPos[0];
    }
}
