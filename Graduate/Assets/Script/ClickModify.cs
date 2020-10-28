using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickModify : MonoBehaviour
{
    public GameObject btnAdd;
    public GameObject btnModify;
    public GameObject InsertPage;
    public int num;

    void OnClick()
    {
        InsertPage.SetActive(true);
        btnAdd.SetActive(false);
        btnModify.SetActive(true);

        DataManager.Instance.modifyCnt = num;

        InsertPage.transform.Find("AddWindow").Find("DoctorName").Find("InsertLabel").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].DoctorName;
        InsertPage.transform.Find("AddWindow").Find("Price").Find("InsertLabel").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].Price.ToString();
        InsertPage.transform.Find("AddWindow").Find("OperationTime").Find("InsertLabel").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].OperationTime.ToString();
        InsertPage.transform.Find("AddWindow").Find("Importance").Find("InsertLabel").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].importance.ToString();
    }

}
