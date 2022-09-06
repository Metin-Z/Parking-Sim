using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarSpawnList : MonoBehaviour
{
    public List<GameObject> CarsList;
    public List<Transform> CarsSpawnPos;
    public List<Transform> CarWaitPos;
    int carCount = 6;

    private void Start()
    {

        StartCoroutine(CarSpawn());
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
            yield return new WaitForSeconds(6);
        }
    }
}
