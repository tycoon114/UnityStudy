using UnityEngine;

public interface Enemy
{
    void Action();


}

public class Goblin : Enemy
{
    public void Action()
    {
        Debug.Log("��� ����");
    }
}


public class Slime : Enemy {
    public void Action()
    {
        Debug.Log("���� ����");
    }
}

public class Wolf : Enemy {
    public void Action()
    {
        Debug.Log("���밡 �����⸦ �����մϴ�");
    }
}