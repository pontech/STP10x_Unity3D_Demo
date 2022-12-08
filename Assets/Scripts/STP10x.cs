using UnityEngine;
using System.IO.Ports;

public class STP10x : MonoBehaviour
{
    //public static STP10x instance { get; private set; }

    [SerializeField] string comPort = "COM10";
    [SerializeField] int baudRate = 9600;

    private SerialPort serialPort;

    private void Awake()
    {
        //if(instance != null && instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    instance = this;
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        serialPort = new SerialPort(comPort, baudRate, Parity.None, 8, StopBits.One);
        Debug.Log("Serial Port Object Created");
        Open();
    }

    public void Open()
    {
        if(serialPort.IsOpen)
            Debug.Log("Already Open");
        else
            serialPort.Open();
            Debug.Log("Opened");
    }
    private void Command(string command)
    {
        serialPort.Write(command + "\r");
        Debug.Log("STP10x:" + command);
    }
    public void Move(int position)
    {
        Command("MI" + position.ToString());
    }
    public void Increment(int offset)
    {
        Command("II" + offset.ToString());
    }
    public void HomePlus()
    {
        Command("H+");
    }
    public void HomeMinus()
    {
        Command("H-");
    }
    public void Halt()
    {
        Command("H0");
    }
    public void HaltImmediately()
    {
        Command("HI");
    }
    public void Home(int position)
    {
        Command("HM"+position.ToString());
    }
}
