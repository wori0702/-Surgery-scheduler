using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int modifyCnt;
    
    public List<OperationData> OperationDatas= new List<OperationData>();

    public List<OperationData> OrderDatas = new List<OperationData>();


    [SerializeField]public List<OperationData> MonOrderDatas = new List<OperationData>();
    [SerializeField]public List<OperationData> TueOrderDatas = new List<OperationData>();
    [SerializeField]public List<OperationData> WedOrderDatas = new List<OperationData>();
    [SerializeField]public List<OperationData> ThuOrderDatas = new List<OperationData>();
    [SerializeField]public List<OperationData> FriOrderDatas = new List<OperationData>();


    public List<Color32> colors;
    public List<string> Names;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        colors.Add(new Color32(251, 103, 103,255));
        colors.Add(new Color32(223, 0, 255,255));
        colors.Add(new Color32(255, 181, 7, 255));
        colors.Add(new Color32(250, 123, 161, 255));
        colors.Add(new Color32(122, 142, 250, 255));
        colors.Add(new Color32(172, 122, 250, 255));
        colors.Add(new Color32(250, 123, 235, 255));
        colors.Add(new Color32(255, 119, 0, 255));
        colors.Add(new Color32(122, 142, 250, 255));
        colors.Add(new Color32(6, 60, 255, 255));
        colors.Add(new Color32(123, 207, 250, 255));
        colors.Add(new Color32(251, 171, 122, 255));
        colors.Add(new Color32(122, 142, 250, 255));
        colors.Add(new Color32(100, 0, 255, 255));
        colors.Add(new Color32(255, 0, 96, 255));
        colors.Add(new Color32(154, 122, 250, 255));
        colors.Add(new Color32(6, 222, 255, 255));
        GetOperationDatas();

        PrefabMaker.Instance.PrefabMake();

        DataSorting();
    }





    public void DataSorting()
    {
        OrderDatas = OperationDatas.OrderByDescending(x => (x.importance * x.OperationTime * x.Price) / OperationDatas.Count).ToList();

        DayMatching();
    }


    public void GetOperationDatas()                                                 //json의 데이터를 OperationDatas로 만듬
    {
        string path = Path.Combine(Application.dataPath, "OperationData.json");
        string jsonData = File.ReadAllText(path);
        string[] jsonDatas = jsonData.Split(';');


        if (jsonDatas[0] != "")
        {
            for (int i = 0; i < jsonDatas.Length; i++)
            {
                OperationDatas.Add(JsonUtility.FromJson<OperationData>(jsonDatas[i]));
            }
        }
    }   

    public void ResetNumering()
    {
        for(int i =0; i <OperationDatas.Count; i++)
        {
            OperationDatas[i].num = i;
        }
    }

    public void DayMatching()
    {
        int dayCheck = 0;
        int i = 0;


        MonOrderDatas = new List<OperationData>();
        TueOrderDatas = new List<OperationData>();
        WedOrderDatas = new List<OperationData>();
        ThuOrderDatas = new List<OperationData>();
        FriOrderDatas = new List<OperationData>();


        for (; i < OrderDatas.Count; i++)
        {
            dayCheck += OrderDatas[i].OperationTime;
            if (dayCheck <= 8)
            {
                MonOrderDatas.Add(OrderDatas[i]);
            }
            else
            {
                dayCheck = 0;
                break;
            }
        }

        for (; i < OrderDatas.Count; i++)
        {
            dayCheck += OrderDatas[i].OperationTime;
            if (dayCheck <= 8)
            {
                TueOrderDatas.Add(OrderDatas[i]);
            }
            else
            {
                dayCheck = 0;
                break;
            }   
        }

        for (; i < OrderDatas.Count; i++)
        {
            dayCheck += OrderDatas[i].OperationTime;
            if (dayCheck <= 8)
            {
                WedOrderDatas.Add(OrderDatas[i]);
            }
            else
            {
                dayCheck = 0;
                break;
            }
        }

        for (; i < OrderDatas.Count; i++)
        {
            dayCheck += OrderDatas[i].OperationTime;
            if (dayCheck <= 8)
            {
                ThuOrderDatas.Add(OrderDatas[i]);
            }
            else
            {
                dayCheck = 0;
                break;
            }
        }

        for (; i < OrderDatas.Count; i++)
        {
            dayCheck += OrderDatas[i].OperationTime;
            if (dayCheck <= 8)
            {
                FriOrderDatas.Add(OrderDatas[i]);
            }
            else
            {
                break;
            }
        }

        ScheduleMaker.Instance.Maker();
    }


    public Color32 getColor(string docName)
    {
        int colornum=-1;

        for(int i =0; i < Names.Count; i++)
        {

            if(Names[i] == docName)
            {

                colornum = i;
                break;
            }
        }

        if (colornum == -1)
        {
            Names.Add(docName);
            colornum = Names.Count-1;
        }

        return colors[colornum];
    }

}
