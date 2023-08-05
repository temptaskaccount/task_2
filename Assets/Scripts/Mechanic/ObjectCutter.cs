using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutter : MonoBehaviour
{
    public GameObject cutObject;
    [ContextMenu("Test")]
    public void CutObject()
    {
        cutObject = gameObject;
        float objecSize = cutObject.transform.localScale.x;
        GameObject generated = Instantiate(cutObject);
        generated.transform.localScale = new Vector3(objecSize / 2, objecSize / 2, objecSize / 2);
        generated.transform.position =
            new Vector3(cutObject.transform.position.x + generated.transform.localScale.x / 2, cutObject.transform.position.y, cutObject.transform.position.z);
        GameObject generated2 = Instantiate(cutObject);
        generated2.transform.localScale = new Vector3(objecSize / 2, objecSize / 2, objecSize / 2);
        generated2.transform.position =
            new Vector3(-(cutObject.transform.position.x + generated2.transform.localScale.x / 2), cutObject.transform.position.y, cutObject.transform.position.z);
    }
}
