using UnityEngine;

public class Grunt : EnemyBase
{

    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        health = 50;
        speed = 3f;
        damage = 10f;
    }
    public override void Attack()
    {
        Debug.Log("Grunt이(가) 근접공격을 한다.");
    }
}
