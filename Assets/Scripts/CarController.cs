using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;
    CanvasManager _canvas;
    public GameObject exp;
    public bool CarMove = true;
    public int randomTime;
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
        _canvas = FindObjectOfType<CanvasManager>();
        Move();
        StartCoroutine(RandomDestroy());
    }
    public void Move()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 1.5f);
        transform.LookAt(transform.parent,new Vector3(0,0,0));       
    }
    public IEnumerator RandomDestroy()
    {
        randomTime = Random.Range(18, 24);
        yield return new WaitForSeconds(randomTime);
        _carSpawn.WaitedCars.Remove(gameObject);
        if (transform.parent.gameObject.tag == "Wait")
        {
            Destroy(gameObject);
            Instantiate(exp,new Vector3 (transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            _canvas.Fail();
        }
        
    }
}