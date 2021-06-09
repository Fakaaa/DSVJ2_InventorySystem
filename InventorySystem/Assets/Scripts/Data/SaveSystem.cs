using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    public static int cantOfIterations;

    public static void SaveItem(Item item, int index)
    {
        string jsonData = JsonUtility.ToJson(item);
        //Debug.Log("data" + jsonData);
        PlayerPrefs.SetString("inventoryData" + index.ToString(), jsonData);
        cantOfIterations = index+1;
        PlayerPrefs.SetInt("amountItemsSaved", cantOfIterations);
    }

    public static void LoadItem(Item item, int index)
    {
        //Debug.Log(index);
        string jsonData = PlayerPrefs.GetString("inventoryData" + index.ToString());
        //Debug.Log(jsonData);
        JsonUtility.FromJsonOverwrite(jsonData, item);
    }

    public static int GetPreviusCountItemsSaved()
    {
        return cantOfIterations = PlayerPrefs.GetInt("amountItemsSaved", 0);
    }

    public static void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
