using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject CanvasObj;

    public int keyInserted = 0;

    public GameObject BlockadeObj;

    public GameObject Key1OBJ;
    public GameObject Key2OBJ;
    public GameObject Key3OBJ;
    public GameObject Key4OBJ;

    public static bool Key1 = false;
    public static bool Key2 = false;
    public static bool Key3 = false;
    public static bool Key4 = false;

    void Start ()
    {
        CanvasObj.SetActive(true);
    }

    void Update()
    {
        if (keyInserted == 4 && BlockadeObj.transform.localPosition.x > 25.7)
        {
            BlockadeObj.transform.position = new Vector3(BlockadeObj.transform.position.x - Time.deltaTime * 5f, BlockadeObj.transform.position.y, BlockadeObj.transform.position.z);
        }
    }
}
