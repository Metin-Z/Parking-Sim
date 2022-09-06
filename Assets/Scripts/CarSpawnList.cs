using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CarSpawnList : MonoBehaviour
{
    public List<GameObject> CarsList;
    public List<Transform> CarsSpawnPos;
    public List<Transform> WaitPos;
    public List<Transform> WaitFalsePos;
    int carCount = 6;
    public void Start()
    {
        StartCoroutine(CarSpawn());
    }
    public void Update()
    {     
             
    }
    public IEnumerator CarSpawn()
    {
        while (carCount > 0)
        {
            carCount--;
            GameObject obj = Instantiate(CarsList[Random.Range(0, 4)], CarsSpawnPos[Random.Range(0, 2)]);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
            obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
            if (WaitPos[0].GetComponent<WaitChecker>().IUsed == false)
            {
                WaitFalsePos.Add(WaitPos.FirstOrDefault());
                WaitPos.Remove(WaitPos.FirstOrDefault());
            }
            if (WaitFalsePos[0].GetComponent<WaitChecker>().IUsed == true)
            {
                WaitPos.Add(WaitFalsePos.FirstOrDefault());
                WaitFalsePos.Remove(WaitFalsePos.FirstOrDefault());
            }
            yield return new WaitForSeconds(6);
        }
    }
}
