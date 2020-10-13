using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace UTS
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        #region Variables
        [SerializeField, Tooltip("If player is null, player will be assigned to the gameobjcet tagged as 'player'")]
        private GameObject player;
        [SerializeField]
        private Image backgroundImage;
        [SerializeField]
        private Image joystickImage;
        [Space(2)]
        [SerializeField]
        private Vector3 inputVector;
        #endregion

        #region Monobehaviours 
        void Awake()
        {
            if (!backgroundImage)
                backgroundImage = GetComponent<Image>();

            if (!joystickImage)
                joystickImage = transform.GetChild(0).GetComponent<Image>();

            inputVector = Vector3.zero;
        }

        private void Start()
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag("Player");
        }
        #endregion

        #region Methods
        public virtual void OnDrag(PointerEventData ped)
        {
            Vector2 position = Vector2.zero;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, ped.position, ped.pressEventCamera, out position))
            {
                position.x = (position.x / backgroundImage.rectTransform.sizeDelta.x);
                position.y = (position.y / backgroundImage.rectTransform.sizeDelta.y);

                float x = (backgroundImage.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
                float y = (backgroundImage.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

                inputVector = new Vector3(x, 0, y);
                inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

                // Move the Image Now
                joystickImage.rectTransform.anchoredPosition =
                    new Vector3(inputVector.x * (backgroundImage.rectTransform.sizeDelta.x / 3),
                                inputVector.z * (backgroundImage.rectTransform.sizeDelta.y / 3));

            }
        }

        public virtual void OnPointerDown(PointerEventData ped)
        {
            OnDrag(ped);
        }
        public virtual void OnPointerUp(PointerEventData ped)
        {
            inputVector = Vector3.zero;
            joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        }

        public Vector3 GetInputVector()
        {
            return inputVector;
        }
        #endregion
    }
}