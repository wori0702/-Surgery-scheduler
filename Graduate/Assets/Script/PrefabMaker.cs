using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabMaker : MonoBehaviour
{
    public static PrefabMaker Instance;
    [SerializeField] GameObject ModifyPrefab;
    [SerializeField] GameObject Page;
    [SerializeField] GameObject btnAdd;
    [SerializeField] GameObject btnModify;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrefabMake()
    {

        if (DataManager.Instance.OperationDatas == null)
            return;

        for (int i = 0; i < DataManager.Instance.OperationDatas.Count; i++)
        {
            prefabMaker(i);
        }
    }

    public void prefabMaker(int num)
    {

        GameObject obj = NGUITools.AddChild(GameObject.Find("ModifyGrid"), ModifyPrefab);

        obj.transform.Find("InputField").transform.Find("IFDoctorName").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].DoctorName;
        obj.transform.Find("InputField").transform.Find("IFPatientName").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].PatientName;
        obj.transform.Find("InputField").transform.Find("IFPrice").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].Price.ToString();
        obj.transform.Find("InputField").transform.Find("IFOperationTime").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].OperationTime.ToString();
        obj.transform.Find("InputField").transform.Find("IFImportance").GetComponent<UILabel>().text = DataManager.Instance.OperationDatas[num].importance.ToString();



        obj.transform.Find("Button").transform.Find("btnModify").GetComponent<ClickModify>().btnAdd = btnAdd;
        obj.transform.Find("Button").transform.Find("btnModify").GetComponent<ClickModify>().InsertPage = Page;
        obj.transform.Find("Button").transform.Find("btnModify").GetComponent<ClickModify>().btnModify = btnModify;
        obj.transform.Find("Button").transform.Find("btnModify").GetComponent<ClickModify>().num = num;


        obj.transform.Find("Button").transform.Find("btnRemove").GetComponent<ClickRemove>().num = num;


        Reposition();
    }

    public void Reposition()
    {

        GetComponent<UIGrid>().Reposition();
    }

}
 