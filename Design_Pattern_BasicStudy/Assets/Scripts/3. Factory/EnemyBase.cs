using UnityEngine;

//���丮 ������ ��ü ���� ������
//ĸ��ȭ�Ͽ� Ŭ���̾�Ʈ �ڵ�� �и��ϴ� �����̴�.
//����Ƽ������ �پ��� ��, ������, ȿ�� ���� ������ �� �����ϴ�.

public enum EnemyType
{
    Grunt,
    Runner,
    Tank,
    Boss
}

//��� ���� �⺻ �������̽�
public interface IEnemy
{
    void Initialize(Vector3 position);
    void Attack();
    void TakeDamage(float damage);

}

//�⺻�� Ŭ����
public abstract class EnemyBase : MonoBehaviour , IEnemy
{

    public abstract void Attack();

    public float health;
    public float speed;
    public float damage;
    

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    

    
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
