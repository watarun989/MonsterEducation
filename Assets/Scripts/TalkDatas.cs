using UnityEngine;

[System.Serializable]
public class TalkData
{
    [TextArea(3,10)]
    public string text; 
}

[CreateAssetMenu(fileName = "Talks",menuName = "CreateTalkDatas")]
public class TalkDatas : ScriptableObject
{
    public TalkData[] datas; 
}