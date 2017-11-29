using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolObject {

    private int _initialStock;
    private List<T> _stack;
    private IPoolFactory<T> _factory;

    public ObjectPool(int initialStock, IPoolFactory<T> factory) {
        _initialStock = initialStock;
        _factory = factory;
        _stack = new List<T>();
        CreateStock();
    }

    private void CreateStock() {
        for (int i = 0; i < _initialStock; i++) {
            T obj = _factory.Create();
            _stack.Add(obj);
        }
    }

    public T Acquiere() {
        if (_stack.Count <= 0)
            CreateStock();

        T obj = _stack[0];
        _stack.RemoveAt(0);
        obj.OnAdquiere();

        return obj;
    }

    public void Release(T obj) {
        obj.OnRelease();
        _stack.Add(obj);
    }

}
