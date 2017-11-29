using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFormationComponent {
    
    public abstract void Action(Enemy reference);


}

public class EnemyAttack : IFormationComponent
{
    public override void Action(Enemy reference)
    {
        reference.transform.parent = null;
        Vector3   _targetPursuitPosition = Enemy.player.transform.position;
                reference.transform.forward = Vector3.Lerp(
                reference.transform.forward,
                _targetPursuitPosition - reference.transform.position ,
                Time.deltaTime * 0.2f
                );
        reference.transform.localPosition += reference.transform.forward * reference.speedDisplacement * Time.deltaTime;
        reference.transform.position = new Vector3(reference.transform.position.x,reference.transform.position.y,0);
    }
}
public class BackToGridPositionEnemy : IFormationComponent
{
    public override void Action(Enemy reference)
    {
        reference.transform.SetParent(GridFormationRoot.instance.transform);
        reference.transform.eulerAngles = Vector3.zero;
        reference.transform.localPosition = Vector3.MoveTowards(reference.transform.localPosition, reference.cordGrid, reference.speedDisplacement * Time.deltaTime);
    }
}