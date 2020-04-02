using UnityEngine;

[System.Serializable]   //[Serializable] をつけないとシリアライズできない
public struct SaveData
{
    public int x;
    public string y;
    public bool z;

}


public class Check_Save : MonoBehaviour
{
    //保存するファイルのパス
    private string PATH;

    void Start() {
        //SAVE_FILE_NAMEは　"hoge.json"　のようなファイル名
        PATH = Application.dataPath + "/SaveData/" + "saveTest";
    }

    //セーブしたいクラス or 構造体　をインスタンス化
    SaveData saveData = new SaveData();

    void Update() {
        //Sキーをおしてセーブ    
        if(Input.GetKeyDown(KeyCode.S)) {
            saveData.x = 10;
            saveData.y = "test";
            saveData.z = true;

            SaveSystem.Save(saveData, PATH);

            //Lキーをおしてロード
        } else if(Input.GetKeyDown(KeyCode.L)) {
            var Data
              = JsonUtility.FromJson<SaveData>(SaveSystem.Load(PATH));

            Debug.Log(Data.x);    //10
            Debug.Log(Data.y);    //test
            Debug.Log(Data.z);    //true
        }
    }
}