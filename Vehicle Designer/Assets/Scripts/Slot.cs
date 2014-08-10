using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour
{
    public SlotConnectionType ConnectionType;
    public SlotType Type;

    public Transform Parent;

    public SlotVectorDirectionType VectorDirectionOne;
    public SlotVectorDirectionType VectorDirectionTwo;

    private Slot _slot;


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool Set(Slot slot)
    {        
        if (slot != null && IsEmpty 
            && ConnectionType == SlotConnectionType.Parent 
            && slot.ConnectionType == SlotConnectionType.Child 
            && (Type == slot.Type || Type == SlotType.Multi))
        {
            _slot = slot;
            var parentTransform = _slot.Parent;
            var scale = parentTransform.localScale;

            //parentTransform.localRotation = Quaternion.FromToRotation(parentTransform.up, VectorDirection);
            parentTransform.parent = transform;
            parentTransform.localPosition = Vector3.zero;
            parentTransform.localScale = scale;
            //parentTransform.localRotation = Quaternion.RotateTowards(parentTransform.localRotation, Parent.localRotation,0);
            //parentTransform.LookAt(VectorDirection);// = Quaternion.LookRotation(VectorDirection);//Quaternion.identity);
            parentTransform.localRotation = Quaternion.identity;

            var angle = Vector3.Angle(parentTransform.up, VectorDirection1);
            //Debug.Log("a1 = " + angle);
            //Debug.Log(Vector3.Angle(parentTransform.right, VectorDirection2));

            //parentTransform.localRotation = Quaternion.AngleAxis(angle, transform.up);

            //parentTransform.RotateAroundLocal(VectorRotation(parentTransform, VectorDirectionOne),Vector3.Angle(parentTransform.up, VectorDirection(VectorDirectionOne)));

            //parentTransform.localEulerAngles = GetLocalEulerAngles(Vector3.Angle(parentTransform.up, VectorDirection(VectorDirectionOne)),parentTransform, VectorDirectionOne);
            //parentTransform.localRotation = Quaternion.Euler(0, 180, -90);

            //Debug.Log(Vector3.Angle(parentTransform.right, VectorDirection2) + "  " + transform.forward);
            //parentTransform.L
            //parentTransform.localEulerAngles = GetLocalEulerAngles(Vector3.Angle(parentTransform.right, VectorDirection(VectorDirectionTwo)), VectorDirectionTwo);

            //parentTransform.LookAt(VectorDirection1);

            //parentTransform.localRotation = new Quaternion(0,180,90,0);



            var v = Vector3.Cross(parentTransform.up, parentTransform.right);


            Debug.Log("up " + parentTransform.up + " right " + parentTransform.right + "  forward " + parentTransform.forward + "  " + v + " " + Vector3.Dot(v, parentTransform.up));

            parentTransform.RotateAround(transform.position, Vector3.Cross(parentTransform.up ,VectorDirection(VectorDirectionOne)), Vector3.Angle(VectorDirection(VectorDirectionOne), parentTransform.up));
            parentTransform.RotateAround(transform.position, Vector3.Cross(parentTransform.right, VectorDirection(VectorDirectionTwo)), Vector3.Angle(VectorDirection(VectorDirectionTwo), parentTransform.right));

            //Debug.Log(transform.InverseTransformDirection(parentTransform.forward));
            //parentTransform.localRotation = Quaternion.AngleAxis(Vector3.Angle(parentTransform.up, VectorDirection(VectorDirectionOne)), transform.InverseTransformDirection(parentTransform.forward));

            //Debug.Log(parentTransform.InverseTransformDirection(transform.right));

            //parentTransform.localRotation = Quaternion.AngleAxis(Vector3.Angle(parentTransform.right, VectorDirection(VectorDirectionTwo)), transform.InverseTransformDirection(parentTransform.right));

            return true;
        }
        return false;
    }

    public bool IsEmpty {
        get { return _slot == null; }
    }

    private Vector3 VectorDirection1 {
        get
        {
            return VectorDirection(VectorDirectionOne);
        }
    }
    private Vector3 VectorDirection2
    {
        get
        {
            return VectorDirection(VectorDirectionTwo);
        }
    }

    private Vector3 VectorDirection(SlotVectorDirectionType directionType)
    {
        switch (directionType)
        {
            case SlotVectorDirectionType.Up:
                return transform.up;
            case SlotVectorDirectionType.Down:
                return -transform.up;
            case SlotVectorDirectionType.Right:
                return transform.right;
            case SlotVectorDirectionType.Left:
                return -transform.right;
            case SlotVectorDirectionType.Forward:
                return transform.forward;
            case SlotVectorDirectionType.Backward:
                return -transform.forward;
        }

        return Vector3.zero;
    }
    private Vector3 GetAxisToRotateOnUp(SlotVectorDirectionType directionType)
    {
        switch (directionType)
        {
            case SlotVectorDirectionType.Right:
                return transform.forward;
            case SlotVectorDirectionType.Left:
                return -transform.forward;
            case SlotVectorDirectionType.Forward:
                return transform.right;
            case SlotVectorDirectionType.Backward:
                return -transform.right;
        }

        return Vector3.zero;
    }

    private Vector3 GetAxisToRotateOnRight(SlotVectorDirectionType directionType)
    {
        switch (directionType)
        {
            case SlotVectorDirectionType.Up:
                return transform.forward;
            case SlotVectorDirectionType.Down:
                return -transform.forward;
            case SlotVectorDirectionType.Forward:
                return transform.up;
            case SlotVectorDirectionType.Backward:
                return -transform.up;
        }

        return Vector3.zero;
    }
}

public enum SlotConnectionType
{
    Parent,
    Child
}

public enum SlotType
{
    Wheel,    //означает что в слот можно поставить колесо
    Weap,    //означает что в слот можно поставить оружие
    Arm,     //слот под броню
    Eng,     //слот под усилители двигателя или сам двигатель
    Abil,    //слот под предмет, дающий спец абилку
    Misc,    //слот для моделек “украшений”
    Multi, 
}

public enum SlotVectorDirectionType
{
    Up,
    Down,
    Left,
    Right,
    Forward,
    Backward

}
