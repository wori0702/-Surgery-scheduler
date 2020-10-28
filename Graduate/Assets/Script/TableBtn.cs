using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBtn : MonoBehaviour
{
    public OperationData data;

    void OnClick()
    {
        GameObject obj = gameObject.GetComponentInParent<ScheduleMaker>().Sibal;

        obj.SetActive(true);

        GameObject obj2 = obj.transform.Find("ModifyPrefab/InputField").gameObject;

        if (data != null)
        {
            obj2.transform.Find("IFDoctorName").GetComponent<UILabel>().text = data.DoctorName;
            obj2.transform.Find("IFPatientName").GetComponent<UILabel>().text = data.PatientName;
            obj2.transform.Find("IFPrice").GetComponent<UILabel>().text = data.Price.ToString();
            obj2.transform.Find("IFOperationTime").GetComponent<UILabel>().text = data.OperationTime.ToString();
            obj2.transform.Find("IFImportance").GetComponent<UILabel>().text = data.importance.ToString();
        }
    }
}
