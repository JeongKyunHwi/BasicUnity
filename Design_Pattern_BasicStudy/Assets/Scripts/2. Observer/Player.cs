using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            //ü�� ���� �̺�Ʈ �߻�
            EventManager.Instance.TriggerEvent("PlayerHealthChanged", _health);

            if(_health <= 0)
            {
                //�÷��̾� ��� �̺�Ʈ �߻�
                EventManager.Instance.TriggerEvent("PlayerDied");
            }
        }
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�׽�Ʈ�� : �����̽� Ű�� ������ ������ �ޱ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
