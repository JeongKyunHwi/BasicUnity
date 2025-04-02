using UnityEngine;

//팩토리 패턴은 객체 생성 로직을
//캡슐화하여 클라이언트 코드와 분리하는 패턴이다.
//유니티에서는 다양한 적, 아이템, 효과 등을 생성할 때 유용하다.

public enum EnemyType
{
    Grunt,
    Runner,
    Tank,
    Boss
}

//모든 적의 기본 인터페이스
public interface IEnemy
{
    void Initialize(Vector3 position);
    void Attack();
    void TakeDamage(float damage);

}

//기본적 클래스
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
