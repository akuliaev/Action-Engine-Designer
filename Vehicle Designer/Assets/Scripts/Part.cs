using UnityEngine;
using System.Collections;

public class Part : VehicleComponent
{

    public Slot Slot;

    private void Awake()
    {
        if (Slot != null) Slot.ConnectionType = SlotConnectionType.Child;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Add(VehicleComponent component)
    {
        
    }

    public override void Remove(VehicleComponent component)
    {
        
    }
}
