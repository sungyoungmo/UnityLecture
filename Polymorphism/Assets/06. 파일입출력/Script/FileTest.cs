using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using Newtonsoft.Json;


public class FileTest : MonoBehaviour
{
    public Text text;
    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();
    

    private void Start()
    {

        // �޸𸮸� ��ƸԱ� ������ �̷��� ���°� ������
        // �����ϰ� �ٿ��ְ� �����ϰ� �ٿ��ֱ� ����
        //string path = Application.dataPath;
        //path += "\n";
        //path += Application.persistentDataPath;
        //path += "\n";
        //path += Application.streamingAssetsPath;
        //
        //text.text = path;

        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path :");
        sb.AppendLine(Application.dataPath);
        sb.Append("Pers data path :");
        sb.AppendLine(Application.persistentDataPath);
        sb.Append("Str data path :");
        sb.AppendLine(Application.streamingAssetsPath);

        text.text = sb.ToString();




        //print(JsonUtility.ToJson(new PlayerData()));

        

        

        


    }

    public void Save()
    {
        // save
        foreach (PlayerData data in playerDatas)
        {
            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            //string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            //string json = JsonUtility.ToJson(data);
            // ���� ��� (���, ����)
            //File.WriteAllText(path, json);

            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            /*
            ���� �κ��̶� �Ʒ��� Load �κп� jsonConvert ����� �ڵ� �ű�� 
            */
            
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "����", "������" };


        // Streaming Assets ���� �ȿ� �ִ� Json ������ ��� �о 
        // readFromJson ����Ʈ�� Add�Ͻÿ�.
        // ��Ʈ
        //DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        //foreach (var item in di.GetFiles("*_Data.json"))
        //{
        //    if (di.Exists) 
        //    {

        //        //string path = $"{Application.streamingAssetsPath}/����_Data.json";
        //        //string json = File.ReadAllText(path);
        //        //print(json);

        //        //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
        //    }
                
        //    //readFromJson.Add(JsonUtility.FromJson<PlayerData>(item.ToString()));
        //}

        foreach (string name in names)
        {

            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {

                Debug.Log(1);
                Debug.Log(name);

                // ���Ϸκ��� Json �������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                // Json ������ �����͸� �Ľ��Ͽ� PlayerData �ν��Ͻ� ���� �� �� �Ҵ�.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
    }

}

// �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ���
// ����ȭ�� �ϸ� ȣȯ���� ������ ��� ���ȼ��� ����������
// ������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ�� �ߴ�.
[System.Serializable]
public class PlayerData
{
    public string name;
    public int level;
    public float exp;
    public int hp;
    public int attack;
    public int[] items;
    public List<SkilData> skills;
}

// �굵 ����ȭ ������ �Ǿ�� ���� Json ���·� ����Ʈ�� �� ������ ��
[System.Serializable]
public class SkilData
{
    public int id;
    public int level;
    public UpgradeType upgrade;
}

public enum UpgradeType
{
    Attack,
    Defence,
    Speed,
    Hp
}