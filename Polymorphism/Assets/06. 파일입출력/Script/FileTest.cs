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

        // 메모리를 잡아먹기 때문에 이렇게 쓰는거 안좋음
        // 복사하고 붙여넣고 복사하고 붙여넣기 때문
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
            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            //string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            //string json = JsonUtility.ToJson(data);
            // 파일 출력 (경로, 내용)
            //File.WriteAllText(path, json);

            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            /*
            여기 부분이랑 아래에 Load 부분에 jsonConvert 사용한 코드 옮기기 
            */
            
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "전사", "마법사" };


        // Streaming Assets 폴더 안에 있는 Json 파일을 모두 읽어서 
        // readFromJson 리스트에 Add하시오.
        // 힌트
        //DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        //foreach (var item in di.GetFiles("*_Data.json"))
        //{
        //    if (di.Exists) 
        //    {

        //        //string path = $"{Application.streamingAssetsPath}/전사_Data.json";
        //        //string json = File.ReadAllText(path);
        //        //print(json);

        //        //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
        //    }
                
        //    //readFromJson.Add(JsonUtility.FromJson<PlayerData>(item.ToString()));
        //}

        foreach (string name in names)
        {

            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // 유효성 검사
            if (File.Exists(path))
            {

                Debug.Log(1);
                Debug.Log(name);

                // 파일로부터 Json 포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                // Json 포맷의 데이터를 파싱하여 PlayerData 인스턴스 생성 후 값 할당.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
    }

}

// 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요함
// 직렬화를 하면 호환성이 오르는 대신 보안성이 떨어지지만
// 데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화를 했다.
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

// 얘도 직렬화 과정이 되어야 위에 Json 형태로 프린트할 때 포함이 됨
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