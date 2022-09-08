using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    RaycastHit collision;
    Vector3 Cursor;
    ParkControl _ParkControl;
    public GameObject Barrier;
    private void Start()
    {
        _ParkControl = FindObjectOfType<ParkControl>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Point = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer = 7;
            if (Physics.Raycast(Point, out collision,Mathf.Infinity, 1 << layer))
            {                
                Barrier.transform.DORotate(new Vector3(0, 0, -60), 1.5f, RotateMode.Fast).OnComplete(
                () =>
                   {
                       Barrier.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast);
                   });
                collision.transform.parent = null;
                collision.transform.parent = _ParkControl.transform;
                collision.transform.GetComponent<CarController>().Move();             
            }
            Debug.DrawRay(Point.origin, Point.direction * 10f, Color.cyan);
        }
    }
}
