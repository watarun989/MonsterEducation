using UnityEngine;

[System.Serializable]
public class TalkData
{
    public string text; 
}

[CreateAssetMenu(fileName = "Talks",menuName = "CreateTalkDatas")]
public class TalkDatas : ScriptableObject
{
    public TalkData[] datas; 
}