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
        Vector3   _targetPursuitPosition = reference.currentTarget.transform.position;
                reference.transform.up = Vector3.Lerp(
                reference.transform.up,
                _targetPursuitPosition - reference.transform.position ,
                Time.deltaTime * 0.2f
                );
        reference.transform.localPosition += reference.transform.up * reference.speedDisplacement * Time.deltaTime;
        //  reference.transform.position = new Vector3(reference.transform.position.x, 0, reference.transform.position.z);
      //  reference.transform.rotation = new Quaternion(0, reference.transform.rotation.x, reference.transform.rotation.z,0);
    }
}
public class BackToGridPositionEnemy : IFormationComponent
{
    public override void Action(Enemy reference)
    {
        reference.transform.SetParent(GridFormationRoot.instance.transform);
        reference.transform.eulerAngles =reference.startRotation;
        reference.transform.localPosition = Vector3.MoveTowards(reference.transform.localPosition, reference.cordGrid, reference.speedDisplacement * Time.deltaTime);
    }
}