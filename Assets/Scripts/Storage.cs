using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        _filePath = directory + "/GameSave.save";
        InitBinatyFormatter();
    }

    private void InitBinatyFormatter()
    {
        _formatter = new BinaryFormatter();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(_filePath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(_filePath);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
