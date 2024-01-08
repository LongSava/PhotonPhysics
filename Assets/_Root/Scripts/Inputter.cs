using Fusion;

public class Inputter : NetworkBehaviour
{
    [Networked] private InputNetwork _inputNetwork { get; set; }
    public InputNetwork InputNetwork => _inputNetwork;

    public override void Spawned()
    {
        if (HasInputAuthority)
        {
            var events = Runner.GetComponent<NetworkEvents>();
            events.OnInput = new NetworkEvents.InputEvent();
            events.OnInput.AddListener(OnInput);
        }
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var inputNetwork = new InputNetwork();
        input.Set(inputNetwork);
    }

    public override void FixedUpdateNetwork()
    {
        if (Runner.IsServer)
        {
            if (GetInput(out InputNetwork inputNetwork))
            {
                _inputNetwork = inputNetwork;
            }
        }
    }
}
