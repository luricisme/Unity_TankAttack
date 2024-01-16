using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
    public SaveALL saveSystem;
    public GameObject prefab;
    public List<GameObject> createPrefabs=new List<GameObject>();
    public void Clear()
    {
        foreach(var item in createPrefabs)
        {
            Destroy(item);
        }
        createPrefabs.Clear();
    }
    public void SaveGame()
    {
        SaveData data = new SaveData();
        foreach (var item in createPrefabs)
        {
            data.Add(item.transform.position);
        }
        var dataToSave = JsonUtility.ToJson(data);
        saveSystem.SaveData(dataToSave);
    }

    public void LoadGame()
    {
        Clear();
        string dataToLoad = "";
        dataToLoad = saveSystem.LoadData();
        if (String.IsNullOrEmpty(dataToLoad) == false)
        {
            SaveData data = JsonUtility.FromJson<SaveData>(dataToLoad);
            foreach (var positionData in data.positionData)
            {
                createPrefabs.Add(Instantiate(prefab, positionData.GetValue(), Quaternion.identity));
            }
        }
    }

    public class SaveData
    {
        public List<Vector3Serialization> positionData; 
        public SaveData()
        {
            positionData= new List<Vector3Serialization>();

        }
        public void Add(Vector2 position)
        {
            positionData.Add(new Vector3Serialization(position));
        }
    }
    [Serializable]
    public class Vector3Serialization
    {
        public float x, y;
        public Vector3Serialization(Vector2 position)
        {
            this.x = position.x;
            this.y = position.y;
            
        }
        public Vector2 GetValue()
        {
            return new Vector2(x, y);
        }
    }
}
