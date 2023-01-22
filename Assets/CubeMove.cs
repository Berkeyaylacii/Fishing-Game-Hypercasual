using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Camera mainCamera;

    //public GameObject cash;
    public Transform cashUI;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = GetIconPosition(transform.position);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 1f);

    }

    public Vector3 GetIconPosition(Vector3 target)
    {
        Vector3 uiPos = cashUI.position;
        uiPos.z = (target - mainCamera.transform.position).z;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);

        return result;
    }
}
