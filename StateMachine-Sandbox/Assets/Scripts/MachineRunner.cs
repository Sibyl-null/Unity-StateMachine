using StateMachine.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class MachineRunner : MonoBehaviour
{
    [SerializeField] private Button _btnState1;
    [SerializeField] private Button _btnState2;
    [SerializeField] private Text _text;
    
    private StateMachine<MachineRunner> _stateMachine;

    private void Awake()
    {
        _text.text = "None";
        _stateMachine = new StateMachine<MachineRunner>(this);
        
        _btnState1.onClick.AddListener(OnStateOneClick);
        _btnState2.onClick.AddListener(OnStateTwoClick);
    }

    private void Update()
    {
        _stateMachine.OnTick(Time.deltaTime);
    }

    private void OnStateOneClick()
    {
        _stateMachine.SwitchState<OneState>();
    }

    private void OnStateTwoClick()
    {
        _stateMachine.SwitchState<TwoState>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}