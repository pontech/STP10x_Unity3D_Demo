using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMotor : MonoBehaviour
{
    public enum OperationEnum {
        Move,
        Increment,
        HomePlus,
        HomeMinus,
        Halt,
        HaltImmendiatly
    }

    [SerializeField] OperationEnum operation = OperationEnum.Move;
    [SerializeField] int position;
    private STP10x stp10x;

    // Start is called before the first frame update
    void Start()
    {
        stp10x = FindObjectOfType<STP10x>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(operation)
        {
            case OperationEnum.Move:
                stp10x.Move(position);
                break;
            case OperationEnum.Increment:
                stp10x.Move(position);
                break;
            case OperationEnum.HomePlus:
                stp10x.HomePlus();
                break;
            case OperationEnum.HomeMinus:
                stp10x.HomeMinus();
                break;
            case OperationEnum.Halt:
                stp10x.Halt();
                break;
            case OperationEnum.HaltImmendiatly:
                stp10x.HaltImmediately();
                break;
        }
    }
}
