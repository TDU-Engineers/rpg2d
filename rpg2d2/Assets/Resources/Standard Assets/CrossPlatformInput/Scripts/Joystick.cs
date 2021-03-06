using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public enum AxisOption
        {
            // Options for which axes to use
            Both, // Use both 0
            OnlyHorizontal, // Only horizontal suihei 1
            OnlyVertical // Only vertical suityokju 2
        }

        bool isDrag;
        int MovementRange;
        public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
        public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
        public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

        GameObject joystic;
        GameObject joysticRange;
        Vector2 m_StartPos;
        Camera camera;
        bool m_UseX; // Toggle for using the x axis
        bool m_UseY; // Toggle for using the Y axis
        CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
        CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
     
        void Start()
        {
            CreateVirtualAxes();
            camera = Camera.main;
            joystic = GameObject.Find("MobileJoystick");
            joysticRange = GameObject.Find("MobileJoystickRange");
            MovementRange = (int)(joysticRange.GetComponent<RectTransform>().sizeDelta.x / 2 - joystic.GetComponent<RectTransform>().sizeDelta.x / 2);
        }

        void UpdateVirtualAxes(Vector2 delta)
        {
            delta /= MovementRange;
            if (m_UseX)
            {
                m_HorizontalVirtualAxis.Update(delta.x);
            }

            if (m_UseY)
            {
                m_VerticalVirtualAxis.Update(delta.y);
            }
        }

        void CreateVirtualAxes()
        {

            // set axes to use
            m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
            m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);
            // create new axes based on axes to use
            if (m_UseX)
            {
                if (CrossPlatformInputManager.AxisExists(horizontalAxisName))
                {
                    CrossPlatformInputManager.UnRegisterVirtualAxis(horizontalAxisName);
                }
                m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
                CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
            }
            if (m_UseY)
            {
                if (CrossPlatformInputManager.AxisExists(verticalAxisName))
                {
                    CrossPlatformInputManager.UnRegisterVirtualAxis(verticalAxisName);
                }
                m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
                CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
            }
        }


        public void OnDrag(PointerEventData data)
        {
            joystic.GetComponent<Image>().enabled = true;
            joysticRange.GetComponent<Image>().enabled = true;

            Vector2 deltaXY = Vector2.zero;
            float deltaX = data.position.x - m_StartPos.x;
            float deltaY = data.position.y - m_StartPos.y;
            float angle = (float)Math.Atan2(deltaY, deltaX);

            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (distance <= MovementRange)
            {
                if (m_UseX)
                {
                    deltaXY.x = deltaX;
                }

                if (m_UseY)
                {
                    deltaXY.y = deltaY;
                }
            }
            else
            {
                if (m_UseX)
                {
                    deltaXY.x = (float)(MovementRange * Math.Cos(angle));
                }

                if (m_UseY)
                {
                    deltaXY.y = (float)(MovementRange * Math.Sin(angle)); ;
                }
            }
            Vector3 newPos = camera.ScreenToWorldPoint(m_StartPos + deltaXY);
            newPos.z = joystic.transform.position.z;
            joystic.transform.position = newPos;
            UpdateVirtualAxes(deltaXY);

            isDrag = true;
        }


        public void OnPointerUp(PointerEventData data)
        {
            joystic.GetComponent<Image>().enabled = false;
            joysticRange.GetComponent<Image>().enabled = false;

            UpdateVirtualAxes(Vector2.zero);
            if (!isDrag)
            {
                GameObject.Find("Player").GetComponent<PlayerContoroller>().CheckObject();
            } 
        }


        public void OnPointerDown(PointerEventData data)
        {
            m_StartPos = data.position;
            Vector3 newPos = camera.ScreenToWorldPoint(data.position);
            newPos.z = joystic.transform.position.z;
            joystic.transform.position = newPos;

            newPos = camera.ScreenToWorldPoint(data.position);
            newPos.z = joysticRange.transform.position.z;
            joysticRange.transform.position = newPos;
            isDrag = false;
        }

        void OnDisable()
        {
            // remove the joysticks from the cross platform input
            if (m_UseX)
            {
                m_HorizontalVirtualAxis.Remove();
            }
            if (m_UseY)
            {
                m_VerticalVirtualAxis.Remove();
            }
        }

        void OnEnable()
        {
            CreateVirtualAxes();
        }
    }
}