using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class SaveALL : MonoBehaviour
{
    public string saveName = "SaveData_";
    [Range(0,10)]
    public int saveDataIndex = 0;
    public void SaveData(string datatoSave)
    {
        if(WriteToFile(saveName+saveDataIndex,datatoSave))
        {
            Debug.Log("Successfully saved Data");
        }
    }
    public string LoadData()
    {
        string data = "";
        if(ReadFromFile(saveName+saveDataIndex,out data))
        {
            Debug.Log("Successfully Loaded Data");
        }
        return data;
    }
    private bool WriteToFile(string name, string content)
    {
        var fullpath=Path.Combine(Application.persistentDataPath,name);
        try
        {
            File.WriteAllText(fullpath, content);
            return true;
        }
        catch(Exception e)
        {
            Debug.LogError("Error saving to File"+e.Message);
        }
        return false;
    }
    private bool ReadFromFile(string name, out string content)
    {
        var fullpath=Path.Combine(Application.persistentDataPath, name);
        try
        {
            content = File.ReadAllText(fullpath);
            return true;
        }
        catch(Exception e)
        {
            Debug.LogError("Error when loading the file" + e.Message);
            content = "";
        }
        return false;
    }
}
