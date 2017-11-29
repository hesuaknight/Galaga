using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp {
    void OnTakePowerUP(Player player);
    void Displacement();
}
