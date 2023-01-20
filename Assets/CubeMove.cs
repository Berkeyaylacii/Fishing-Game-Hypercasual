using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public static CatchFish catchFish;

    Camera mainCamera;

    public GameObject cashUI;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cashUI = catchFish.cashUI;
    }

    // Update is called once per frame
    void Update()
    {
     

    }
    
    public Vector3 GetIconPosition(Vector3 target)
    {
        Vector3 uiPos = cashUI.transform.position;
        uiPos.z = (target - mainCamera.transform.position).z;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);

        return result;
    }
}
