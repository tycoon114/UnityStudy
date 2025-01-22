using UnityEngine;
/// <summary>
/// 유니티 어트리뷰트
/// </summary>
/// 

[AddComponentMenu("customUtil/ScriptExample")]
public class scriptExample : MonoBehaviour
{
    [Range(1, 99)]
    public int level;

    [Range(0, 100)]
    public int volume;

    [Header("playerName")]
    public string playerName;

    [TextArea]
    public string talk01;

    [TextArea(1, 3)]
    public string talk02;

    [TextArea(5, 7)]
    public string talk03;

    [Tooltip("체크되면 사망")]
    public bool isDead = true;

    [ContextMenu("HelloEveyone")]
    void HelloEveyone() {
        Debug.Log("HI everyone");
    }

    void HelloSomeone(string someone)
    {

        Debug.Log($"{someone} hi");
    }

    //private void Update() {
    //    HelloEveyone();
    //    HelloSomeone("rrr ");
    //}


}
