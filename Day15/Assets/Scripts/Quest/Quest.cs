using UnityEngine;


public enum QuestType { 

    nomal, daily, weekly
}
//일반 퀘스트, 일일 퀘스트, 주간 퀘스트

[CreateAssetMenu(fileName ="Quset", menuName = "quset/quset")]
public class Quest : ScriptableObject
{
    public QuestType qusetSample;
    public Reward rewardSample;
    public Requirment requirment;

    [Header("보상")]
    public string title;
    public string target;
    [TextArea] public string description;

    public bool clear;
    public bool questState;

}

[CreateAssetMenu(fileName = "Requirment", menuName = "quset/require")]
public class Requirment : ScriptableObject {
    public int targetMonster;
    public int currentMonster;
}


[SerializeField]
[CreateAssetMenu(fileName = "Reward", menuName = "quset/reward")]
public class Reward : ScriptableObject {
    public int money;
    public float exp;
}