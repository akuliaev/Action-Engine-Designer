using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class CompositePart : VehicleComponent
{

    public Slot[] Slots;

    private List<Slot> _allSlots;

    protected override void Awake()
    {
        base.Awake();
        _allSlots = new List<Slot>();
        _allSlots.AddRange(Slots);
    }

    private void Start()
    {

    }

    public bool HasEmptySlot()
    {
        return _allSlots.Find(c => c.ConnectionType == SlotConnectionType.Parent && c.IsEmpty);
    }

    public bool HasEmptySlot(SlotType type)
    {
        return _allSlots.Find(c => c.ConnectionType == SlotConnectionType.Parent && c.IsEmpty && c.Type == type);
    }

    public List<Slot> GetSlots()
    {
        return _allSlots;
    }


    public override void Add(VehicleComponent component)
    {
        if (component != null && Slots != null && Slots.Length != 0)
        {
            List<Slot> parentSlots = Slots.ToList().FindAll(c => c.ConnectionType == SlotConnectionType.Parent);
            
            List<Slot> childSlots = component.GetComponentsInChildren<Slot>().ToList().FindAll(c=>c.ConnectionType == SlotConnectionType.Child);

            if (childSlots != null && childSlots.Count != 0 && parentSlots != null && parentSlots.Count != 0)
            {
                for (var i = 0; i < childSlots.Count; i++)
                {
                    if (childSlots[i] != null)
                    {
                        Slot slots = parentSlots.Find(c => c.Type == childSlots[i].Type && c.IsEmpty);
                        if (slots != null && slots.Set(childSlots[i]))
                        {
                            _allSlots.AddRange(parentSlots);

                            base.Add(component);
                            return;
                        }
                    }
                }
            }            
        }
        Debug.Log("Count = " + Count);
        for (var i = 0; i < Count; i++)
        {
            var child = this[i];
            Debug.Log("child = " + child);
            if (child != null) child.Add(component);

        }
    }

    public void Replace(VehicleComponent component)
    {
        
    }

    // Update is called once per frame
	void Update () {
	
	}
}
