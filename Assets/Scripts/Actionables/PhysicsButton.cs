using UnityEngine;
using UnityEngine.Events;
using com.mlone.interfaces;

namespace com.mlone.actioanbles
{
    public class PhysicsButton : MonoBehaviour, IActionable
    {
        public Rigidbody buttonTopRigid;
        public Transform buttonTop;
        public Transform buttonLowerLimit;
        public Transform buttonUpperLimit;
        public float threshHold;
        public float force = 10;
        public bool isPressed;

        public AudioSource pressedSound;
        public AudioSource releasedSound;
        public Collider[] CollidersToIgnore;
        public UnityEvent onPressed;
        public UnityEvent onReleased;

        private float upperLowerDiff;
        private bool prevPressedState;

        public bool IsPressed { get { return prevPressedState; } }

        // Start is called before the first frame update
        void Start()
        {
            //Debug.Log("Start");

            Collider localCollider = GetComponent<Collider>();
            if (localCollider != null)
            {
                Physics.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider>());

                foreach (Collider singleCollider in CollidersToIgnore)
                {
                    Physics.IgnoreCollision(localCollider, singleCollider);
                }
            }

            //Collider thisCollider = GetComponent<Collider>();
            //Physics.IgnoreCollision(thisCollider, buttonTop.GetComponent<Collider>());

            if (transform.eulerAngles != Vector3.zero)
            {
                var savedAngle = transform.eulerAngles;
                transform.eulerAngles = Vector3.zero;

                transform.eulerAngles = savedAngle;
            }
            upperLowerDiff = Mathf.Abs(buttonUpperLimit.position.y) - Mathf.Abs(buttonLowerLimit.position.y);

        }

        // Update is called once per frame
        void Update()
        {
            // Top: (0.0, -1.1, 0.0)  UpperLimit: (0.0, 1.2, 5.6) LowerLimit: (0.0, -1.1, 0.0)
            //Debug.Log(string.Format("Top: {0}  UpperLimit: {1},{2} {3} LowerLimit: {4} Distance:  {5}",
            //    buttonTop.transform.localPosition,
                
            //    buttonUpperLimit.position,
            //    buttonUpperLimit.transform.position,
            //    buttonUpperLimit.localPosition,

            //    buttonLowerLimit.localPosition,
            //    Vector3.Distance(buttonTop.localPosition, buttonLowerLimit.localPosition)
            //    ));


            buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
            buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);


            //===========================================================================
            if (buttonTop.localPosition.y >= buttonUpperLimit.localPosition.y)
                buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
                
            else
            {
                if (buttonTopRigid != null)
                    buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);
                else
                    buttonTop.GetComponent<Rigidbody>().AddForce(buttonTop.transform.up * force * Time.deltaTime);
            }

            if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
                buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^



            if (Vector3.Distance(buttonTop.localPosition, buttonLowerLimit.localPosition) < upperLowerDiff * threshHold + .05)
                isPressed = true;
            else
                isPressed = false;

            if (isPressed && prevPressedState != isPressed)
                OnPressed();
            if (!isPressed && prevPressedState != isPressed)
                OnReleased();
        }


        public float OnPressed()
        {
            prevPressedState = isPressed;
            pressedSound.pitch = 1;
            pressedSound.Play();
            onPressed.Invoke();

            return 0f;
        }

        public float OnReleased()
        {
            prevPressedState = isPressed;
            releasedSound.pitch = Random.Range(1.1f, 1.2f);
            releasedSound.Play();
            onReleased.Invoke();

            return 0f;
        }
    }

}