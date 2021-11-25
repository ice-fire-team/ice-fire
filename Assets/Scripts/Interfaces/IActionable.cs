using UnityEngine.Events;

namespace com.mlone.interfaces
{    
    public interface IActionable 
    {
        public float OnPressed();
        public float OnReleased();
    }
}