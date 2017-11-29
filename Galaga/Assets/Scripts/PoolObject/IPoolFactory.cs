using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolFactory<T> where T : IPoolObject {

    T Create();
}
