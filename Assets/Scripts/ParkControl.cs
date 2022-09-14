using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
public class ParkControl : MonoBehaviour
{
    CarSpawnList _carSpawn;
    int parkRange;
    public void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            other.transform.DORotate(new Vector3(0, 0, 0), 1.7f, RotateMode.Fast);
            _carSpawn.WaitedCars.Remove(other.gameObject);
            StartCoroutine(TrafficController());
            other.transform.parent = null;
            parkRange = Random.Range(0, _carSpawn.ParkPos.Count);
            other.transform.parent = _carSpawn.ParkPos[parkRange];
            _carSpawn.ParkPos.Remove(_carSpawn.ParkPos[parkRange]);
            other.GetComponent<CarController>().Move();          
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public IEnumerator TrafficController()
    {
        yield return new WaitForSeconds(1.3f);
        if (_carSpawn.WaitedCars.Count != 0)
        {
            for (int i = 0; i < _carSpawn.WaitedCars.Count; i++)
            {
                _carSpawn.WaitedCars[i].transform.parent = _carSpawn.WaitPos[i];
                _carSpawn.WaitedCars[i].GetComponent<CarController>().Move();
                yield return new WaitForSeconds(0.3f);
            }
            
        }
    }
}