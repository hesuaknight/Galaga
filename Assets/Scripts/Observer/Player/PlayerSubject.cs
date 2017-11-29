using System.Collections.Generic;

public class PlayerSubject {
    private List<IPlayerObserver> list;

    public PlayerSubject() {
        list = new List<IPlayerObserver>();
    }

    public void Add(IPlayerObserver o) {
        list.Add(o);
        UnityEngine.Debug.Log("Add!");
    }

    public void Remove(IPlayerObserver o) {
        list.Remove(o);
        UnityEngine.Debug.Log("Remove!");
    }

    public void NotiffyAll() {
        for(int i = list.Count - 1; i >= 0; i--) {
            list[i].notify();
        }
        UnityEngine.Debug.Log("Notify!!");
    }
}
