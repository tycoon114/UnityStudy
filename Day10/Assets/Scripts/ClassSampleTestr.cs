using UnityEngine;

class Unit {

    //만들 객체의 정보를 작성
    public string unitName;

    public static void unitAction() {
        
        
        Debug.Log("Test");
    }


    public void Cry() {

        Debug.Log("cry");
    }

}




public class ClassSampleTestr : MonoBehaviour
{

    Unit unit; // 클래스 선언

    void Start()
    {
        unit.unitName = "asAs";
        //클래스 변수명.필드 를 통해 클래스가 가진 변수(필드)사용 가능

        unit.Cry();
        //함수 호출 

        //static함수는 객체를 생성하지 않고 클래스에서 바로 그 기능을 가져와서 사용
        Unit.unitAction();


    }

    // Update is called once per frame
    void Update()
    {
        unit.Cry();
    }
}
