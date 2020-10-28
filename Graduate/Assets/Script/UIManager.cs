using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] public GameObject AddObject;
    [SerializeField] GameObject ModifyObject;
    [SerializeField] public GameObject btnAdd;
    [SerializeField] public GameObject btnModify;
    [SerializeField] UILabel DoctorName;
    [SerializeField] UILabel PatientName;
    [SerializeField] UILabel Importance;
    [SerializeField] UILabel OperationTime;
    [SerializeField] UILabel Price;
    [SerializeField] UIGrid grid;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;        
    }


    // Start is called before the first frame update
    void Start()
    {
        AddObject.SetActive(false);
        ModifyObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void OpenAddObject()
    {
        AddObject.SetActive(true);
        btnAdd.SetActive(true);
        btnModify.SetActive(false);
    }


    public void CloseAddObejct()
    {

        AddObject.SetActive(false);
    }

    public void OpenModifyObject()
    {
        ModifyObject.SetActive(true);
    }

    public void CloseModifyObject() 
    {
        ModifyObject.SetActive(false);
    }

    public void ModifyData()  //'
    {
        DataManager.Instance.OperationDatas[DataManager.Instance.modifyCnt].DoctorName = DoctorName.text;
        DataManager.Instance.OperationDatas[DataManager.Instance.modifyCnt].PatientName = PatientName.text;
        DataManager.Instance.OperationDatas[DataManager.Instance.modifyCnt].Price = int.Parse(Price.text);
        DataManager.Instance.OperationDatas[DataManager.Instance.modifyCnt].OperationTime = int.Parse(OperationTime.text);
        DataManager.Instance.OperationDatas[DataManager.Instance.modifyCnt].importance = float.Parse(Importance.text);


        while(grid.transform.childCount>0)
        {

            NGUITools.DestroyImmediate(grid.transform.GetChild(0).gameObject);
        }

        GameObject.Find("ModifyGrid").transform.DetachChildren();

        toJson();



        PrefabMaker.Instance.PrefabMake();

        ScheduleMaker.Instance.reset();
        DataManager.Instance.DataSorting();
        ScheduleMaker.Instance.Reset();

    }

    public void ResetModify()
    {
        while (grid.transform.childCount > 0)
        {

            NGUITools.DestroyImmediate(grid.transform.GetChild(0).gameObject);
        }

        GameObject.Find("ModifyGrid").transform.DetachChildren();
    }


    public void AddData()
    {

        if (DoctorName.text == "" || Importance.text == "" || OperationTime.text  == "" || Price.text == "")
        {
            Debug.LogError("데이터 부족");
            return;
        }

        OperationData newData = new OperationData();
        newData.num = DataManager.Instance.OperationDatas.Count;
        newData.DoctorName = DoctorName.text;
        newData.PatientName = PatientName.text;
        newData.importance = float.Parse(Importance.text);
        newData.OperationTime = int.Parse(OperationTime.text);
        newData.Price = int.Parse(Price.text);

        DataManager.Instance.OperationDatas.Add(newData);

        PrefabMaker.Instance.prefabMaker(DataManager.Instance.OperationDatas.Count-1);

        toJson();

        DoctorName.text = "";
        Importance.text = "";
        OperationTime.text = "";
        Price.text = "";


        ScheduleMaker.Instance.reset();
        DataManager.Instance.DataSorting();
         ScheduleMaker.Instance.Reset();

    }


    public void toJson()
    {
        DataManager.Instance.ResetNumering();
                


        string jsonData = "";

        for (int i = 0; i < DataManager.Instance.OperationDatas.Count; i++)
        {
            string jsonMsg = "";
            jsonMsg += JsonUtility.ToJson(DataManager.Instance.OperationDatas[i]);
            if (i != DataManager.Instance.OperationDatas.Count - 1)
                jsonMsg += ';';

            jsonData += jsonMsg;
        }


        string path = Path.Combine(Application.dataPath, "OperationData.json");
        File.WriteAllText(path, jsonData);

    }
}
