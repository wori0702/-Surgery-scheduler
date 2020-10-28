using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] GameObject obj;

    void OnClick()
    {
        obj.SetActive(false);
    }
}
