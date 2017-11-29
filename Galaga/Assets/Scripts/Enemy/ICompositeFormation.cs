using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICompositeFormation {
    void AddShip();
    void RemoveShip();
    void AttackRandomComponents(int count);
    void GetChild();
}
