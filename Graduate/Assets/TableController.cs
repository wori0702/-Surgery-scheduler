using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class TableController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<OperationData> OrderDatas;
    [SerializeField] GameObject SchedulePrefab;
    UITable table;

    void Start()
    {
        table = GetComponent<UITable>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MakeTable()
    {

        int NoneOpTime = 0;
        for (int i = 0; i < OrderDatas.Count; i++)
        {
            GameObject obj = NGUITools.AddChild(gameObject, SchedulePrefab);
            obj.transform.Find("DrName").GetComponent<UILabel>().text = OrderDatas[i].DoctorName;
            obj.transform.Find("PatientName").GetComponent<UILabel>().text = OrderDatas[i].PatientName;
            obj.transform.Find("Background").GetComponent<UISprite>().height = 75* OrderDatas[i].OperationTime;
            obj.GetComponent<TableBtn>().data = OrderDatas[i];
            obj.GetComponent<BoxCollider>().size = new Vector3(100, 75 * OrderDatas[i].OperationTime, 0);
            NoneOpTime += OrderDatas[i].OperationTime;
            Color color = DataManager.Instance.getColor(OrderDatas[i].DoctorName);

            obj.GetComponent<UIButtonColor>().defaultColor = color;
            obj.GetComponent<UIButtonColor>().hover = color;
            obj.GetComponent<UIButtonColor>().pressed = color;
        }


        if (NoneOpTime != 0 && OrderDatas[0].OperationTime != 8)
        {
            GameObject obj = NGUITools.AddChild(gameObject, SchedulePrefab);
            obj.GetComponent<UIButtonColor>().defaultColor = new Color(0, 0, 0);
            obj.GetComponent<UIButtonColor>().disabledColor = new Color(0, 0, 0);
            obj.GetComponent<UIButton>().isEnabled = false;
            obj.transform.Find("DrName").GetComponent<UILabel>().text = "";
            obj.transform.Find("PatientName").GetComponent<UILabel>().text = "";
            obj.transform.Find("Background").GetComponent<UISprite>().height = 75 * (8 - NoneOpTime);
            
        }

    }

    public void reposition()
    {
        table.Reposition();

    }

    public void reset()
    {
        if (table.transform.childCount != 0)
        {
            while (table.transform.childCount >0)
            {
                NGUITools.Destroy(table.transform.GetChild(0));
            }
            table.transform.DetachChildren();
        }
    }

}

