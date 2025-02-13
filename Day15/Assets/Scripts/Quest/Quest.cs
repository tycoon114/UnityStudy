using UnityEngine;


public enum QuestType { 

    nomal, daily, weekly
}
//�Ϲ� ����Ʈ, ���� ����Ʈ, �ְ� ����Ʈ

[CreateAssetMenu(fileName ="Quset", menuName = "quset/quset")]
public class Quest : ScriptableObject
{
    public QuestType qusetSample;
    public Reward rewardSample;
    public Requirment requirment;

    [Header("����")]
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