using UnityEngine;

public interface Enemy
{
    void Action();


}

public class Goblin : Enemy
{
    public void Action()
    {
        Debug.Log("고블린 공격");
    }
}


public class Slime : Enemy {
    public void Action()
    {
        Debug.Log("점프 공격");
    }
}

public class Wolf : Enemy {
    public void Action()
    {
        Debug.Log("늑대가 물어뜯기를 시전합니다");
    }
}