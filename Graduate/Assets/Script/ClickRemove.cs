using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickRemove : MonoBehaviour
{
    public int num;

    void OnClick()
    {
        DataManager.Instance.OperationDatas.RemoveAt(num);
        DataManager.Instance.ResetNumering();
        UIManager.Instance.ResetModify();
        PrefabMaker.Instance.PrefabMake();
        UIManager.Instance.toJson();
        ScheduleMaker.Instance.reset();
        DataManager.Instance.DataSorting();
        ScheduleMaker.Instance.Reset();
     }
}
