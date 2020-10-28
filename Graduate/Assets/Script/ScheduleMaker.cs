using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleMaker : MonoBehaviour
{
    public static ScheduleMaker Instance;

    [SerializeField] TableController Mon;
    [SerializeField] TableController Tue;
    [SerializeField] TableController Wed;
    [SerializeField] TableController Thu;
    [SerializeField] TableController Fri;

    public GameObject Sibal;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Maker()
    {

        Mon.OrderDatas = DataManager.Instance.MonOrderDatas;
        Mon.MakeTable();
        Tue.OrderDatas = DataManager.Instance.TueOrderDatas;
        Tue.MakeTable();
        Wed.OrderDatas = DataManager.Instance.WedOrderDatas;
        Wed.MakeTable();
        Thu.OrderDatas = DataManager.Instance.ThuOrderDatas;
        Thu.MakeTable();
        Fri.OrderDatas = DataManager.Instance.FriOrderDatas;
        Fri.MakeTable();
    }

    public void Reset()
    {
        Mon.reposition();
        Tue.reposition();
        Wed.reposition();
        Thu.reposition();
        Fri.reposition();
    }


    public void reset()
    {
        Mon.reset();
        Tue.reset();
        Wed.reset();
        Thu.reset();
        Fri.reset();
    }
}
