using static UnityEngine.InputSystem.InputAction;

public abstract class TouchMove : TouchBase
{
    protected virtual void Start()
    {
        touchControls.Player.Move.started += context => OnTouchMoved(context);
    }

    protected abstract void OnTouchMoved(CallbackContext context);
}
