using UnityEngine;

namespace Systems.Input_Handling
{
    public interface IInputHandler
    {
        Vector3 GetInput();
    }
    
    public class PlayerInputService : IInputHandler
    {
        public Vector3 GetInput()
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
    
}