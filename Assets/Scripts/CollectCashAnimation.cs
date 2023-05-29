using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCashAnimation : MonoBehaviour
{
    [SerializeField] private GameObject PileOfCashParent;
    [SerializeField] private TextMeshProUGUI Counter;

    [SerializeField] private Vector3[] InitialPos;
    [SerializeField] private Quaternion[] InitialRotation;
    [SerializeField] public int CashNumber;

    public GameObject cashPrefab;
    public bool completed = false;
    void Start()
    {
        CashNumber = PileOfCashParent.transform.childCount;
        InitialPos = new Vector3[CashNumber];
        InitialRotation = new Quaternion[CashNumber];

        for(int i=0; i< CashNumber; i++) //PileOfCashParent.transform.childCount
        {
            InitialPos[i] = PileOfCashParent.transform.GetChild(i).position;
            InitialRotation[i] = PileOfCashParent.transform.GetChild(i).rotation;
        }
    }

    private void Reset()
    {
        for(int i=0; i < PileOfCashParent.transform.childCount; i++)
        {
            PileOfCashParent.transform.GetChild(i).position = InitialPos[i];
            PileOfCashParent.transform.GetChild(i).rotation = InitialRotation[i];
        }
    }

    public void RewardPileOfCash()
    {
        Reset();

        var delay = 0f;

        //PileOfCashParent.SetActive(true);

        for (int i = 0; i < CashNumber; i++)  //PileOfCashParent.transform.childCount
        {
            PileOfCashParent.transform.GetChild(i).gameObject.SetActive(true);
            PileOfCashParent.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            PileOfCashParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(-261f, 760f), 1f).SetDelay(delay + 0.5f)
                .SetEase(Ease.OutBack);

            PileOfCashParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1f).SetEase(Ease.OutBack);

            delay += 0.2f;
        }
    }

    void CountCashesByComplete()
    {
        
    }

    /*public void SpawnCashObjectAtCanvas()
    {   
        for(int i =0; i < 2; i++)
        {
            GameObject cashObj = GameObject.Instantiate(cashPrefab, GameObject.FindGameObjectWithTag("CashGroup").transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("CashGroup").transform);
        }
        CashNumber = PileOfCashParent.transform.childCount;
        InitialPos = new Vector3[CashNumber];
        InitialRotation = new Quaternion[CashNumber];
    }*/

}
