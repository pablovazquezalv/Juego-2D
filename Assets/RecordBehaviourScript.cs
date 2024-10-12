using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            GetComponent<TextMeshProUGUI>().text += " Record: " + PlayerPrefs.GetInt("record");

    }



    // Update is called once per frame
    void Update()
    {

        
    }
}
