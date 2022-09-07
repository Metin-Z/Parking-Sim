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
    public List<Transform> WaitFalsePos;
    int carCount = 6;
    bool control =false;
    public void Start()
    {
        StartCoroutine(CarSpawn());
        StartCoroutine(StartControl());
    }
    private void Update()
    {
        if (WaitPos.Count != 0 && control==true)
        {
            if (WaitPos[0].GetComponent<WaitChecker>().IUsed == true)
            {
                WaitFalsePos.Add(WaitPos.FirstOrDefault());
                WaitPos.Remove(WaitPos.FirstOrDefault());
            }
        }
        if (WaitPos.Count >= 0 && control==true)
        {
            if (WaitFalsePos[0].GetComponent<WaitChecker>().IUsed == false)
            {
                WaitPos.Add(WaitFalsePos.FirstOrDefault());
                WaitFalsePos.Remove(WaitFalsePos.FirstOrDefault());
            }
        }
    }
    public IEnumerator StartControl()
    {
        yield return new WaitForSeconds(2.35f);
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
            obj.transform.parent = WaitPos[0];
            WaitedCars.Add(obj);
            //obj.transform.DOMove(new Vector3(0,0,0),2.75f);
            //obj.transform.localPosition = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(2.4f);
        }
    }
}