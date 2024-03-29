using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class CarSpawnList : MonoBehaviour
{
    public List<GameObject> CarsList;
    public List<GameObject> WaitedCars;
    public List<Transform> CarsSpawnPos;
    public List<Transform> ParkPos;
    public List<Transform> WaitPos;
    public List<Transform> ExitPos;
    public List<Transform> EndPos;
    int carCount = 6;
    int parentNumber = 0;
    public bool control = false;
    public void Start()
    {
        StartCoroutine(CarSpawn());
        StartCoroutine(StartControl());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N ye bas�ld�");
            NewCar();
        }

    }
    public IEnumerator StartControl()
    {
        yield return new WaitForSeconds(0.3f);
        control = true;
    }
    public IEnumerator CarSpawn()
    {
        while (carCount > 0)
        {
            carCount--;
            GameObject obj = Instantiate(CarsList[Random.Range(0, 4)], CarsSpawnPos[Random.Range(0, 2)]);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
            obj.transform.DOScale(scale, 0.45f).SetEase(Ease.InBounce);
            if (WaitPos[parentNumber].GetComponent<WaitChecker>().IUsed == false)
            {
                obj.transform.parent = WaitPos[parentNumber];
            }
            else if (WaitPos[parentNumber + 1].GetComponent<WaitChecker>().IUsed == false)
            {
                obj.transform.parent = WaitPos[parentNumber + 1];
            }
            parentNumber += 1;
            WaitedCars.Add(obj);
            if (parentNumber % 6 == 0)
            {
                parentNumber = 0;
            }
            yield return new WaitForSeconds(0.85f);
        }
    }
    public void NewCar()
    {
        Debug.Log("Araba Olu�tur");
        GameObject obj = Instantiate(CarsList[Random.Range(0, 4)], CarsSpawnPos[Random.Range(0, 2)]);
        obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
        obj.transform.DOScale(scale, 0.45f).SetEase(Ease.InBounce);
        obj.transform.parent = WaitPos[WaitedCars.Count];
        WaitedCars.Add(obj);
    }

}