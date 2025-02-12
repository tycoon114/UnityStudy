using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE { 
        Goblion,Slime,Wolf
    }
    /// <summary>
    /// ���丮���� �ٷ�� ������ ���¸� ����
    /// </summary>
    /// <param name="type">������ ��ü�� ���� ǥ��</param>
    /// <returns></returns>
    public Enemy Create(ENEMYTYPE type) {
        switch (type) {
            case ENEMYTYPE.Goblion:
                return new Goblin();
            case ENEMYTYPE.Slime:
                return new Slime();
            case ENEMYTYPE.Wolf:
                return new Wolf();
            default:
                throw new System.Exception("���� ����");
        }
    }
}
