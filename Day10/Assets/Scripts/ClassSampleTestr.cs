using UnityEngine;

class Unit {

    //���� ��ü�� ������ �ۼ�
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

    Unit unit; // Ŭ���� ����

    void Start()
    {
        unit.unitName = "asAs";
        //Ŭ���� ������.�ʵ� �� ���� Ŭ������ ���� ����(�ʵ�)��� ����

        unit.Cry();
        //�Լ� ȣ�� 

        //static�Լ��� ��ü�� �������� �ʰ� Ŭ�������� �ٷ� �� ����� �����ͼ� ���
        Unit.unitAction();


    }

    // Update is called once per frame
    void Update()
    {
        unit.Cry();
    }
}
