using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ConstructorManager : MonoBehaviour
{

    public GameObject BodyPref;
    public GameObject WheelPref;

    public GameObject PlatformPref;

    public Transform Container;

    private CompositePart _body;

    private List<Part> _wheels;

    private CompositePart _platform;
    
    // Use this for initialization
	void Start () {

        _wheels = new List<Part>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BuildBody()
    {
        if (_body == null && BodyPref != null)
        {
            var go = (GameObject)Instantiate(BodyPref);
            
            if (go != null)
            {
                _body = go.GetComponent<CompositePart>();

                if (Container != null)
                {
                    _body.transform.parent = Container;
                    _body.transform.localPosition = new Vector3(1,-17,-120);
                    _body.transform.localScale = new Vector3(300, 100, 100);
                    _body.transform.localRotation = Quaternion.LookRotation(new Vector3(0, -45, -45));
                } 
            }
        }
    }

    public void AddWheel()
    {

        if (_body != null && WheelPref != null)// && _body.HasEmptySlot(SlotType.Wheel))
        {
            var go = Instantiate(WheelPref) as GameObject;
            if (go != null)
            {
                var wheel = go.GetComponent<Part>();

                
                _body.Add(wheel);

                _wheels.Add(wheel);
            }
        }
    }

    public void AddPlatform()
    {
        if (_body != null && PlatformPref != null && _body.HasEmptySlot(SlotType.Misc))
        {
            var go = Instantiate(PlatformPref) as GameObject;
            if (go != null)
            {
                _platform = go.GetComponent<CompositePart>();
                _body.Add(_platform);
            }
        }
    }


}
