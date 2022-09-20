using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;
    CanvasManager _canvas;
    public GameObject exp;
    public GameObject Canvas;
    public bool CarMove = true;
    public int randomTime;
    public TextMeshProUGUI destroyTime;
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
        _canvas = FindObjectOfType<CanvasManager>();
        Move();
        StartCoroutine(RandomDestroy());    
    }
    private void Update()
    {
        destroyTime.text = randomTime.ToString();
        if (transform.parent.gameObject.tag != "Wait")
        {
            Canvas.SetActive(false);
        }
    }
    public void Move()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 1.5f);
        transform.LookAt(transform.parent,new Vector3(0,0,0));       
    }
    public IEnumerator RandomDestroy()
    {
        randomTime = Random.Range(20, 26);
        StartCoroutine(Time());
        yield return new WaitForSeconds(randomTime);
        _carSpawn.WaitedCars.Remove(gameObject);
        if (transform.parent.gameObject.tag == "Wait")
        {
            Destroy(gameObject);
            Instantiate(exp,new Vector3 (transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            _canvas.Fail();
        }      
    }
    public IEnumerator Time()
    {
        while (randomTime>0)
        {
            yield return new WaitForSeconds(1);
            randomTime--;
        }
    }
}