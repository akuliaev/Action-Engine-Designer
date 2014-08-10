using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class VehicleComponent : MonoBehaviour
{

    private List<VehicleComponent> _children;

    protected virtual void Awake()
    {
        _children = new List<VehicleComponent>();
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Add(VehicleComponent component)
    {
        if (!_children.Contains(component))
            _children.Add(component);
    }

    public virtual void Remove(VehicleComponent component)
    {
        if (_children.Contains(component))
            _children.Remove(component);
    }

    public VehicleComponent this[int index]
    {
        get
        {
            if (index >= 0 && index < Count)
                return _children[index];
            return null;
        }
    }

    public int Count {
        get { return _children.Count; }
    }
}
