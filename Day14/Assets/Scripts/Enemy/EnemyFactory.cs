using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE { 
        Goblion,Slime,Wolf
    }
    /// <summary>
    /// 팩토리에서 다루는 데이터 형태를 리턴
    /// </summary>
    /// <param name="type">생성할 객체의 형태 표현</param>
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
                throw new System.Exception("생성 실패");
        }
    }
}
