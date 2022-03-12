using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class ClockScript : MonoBehaviour
    {
        public Image fill;

        private void Awake()
        {
            transform.SetParent(GameObject.Find("Canvas").transform, false);
        }

        public void ChangeState(float fraction, Vector3 position)
        {
            fill.fillAmount = fraction;
            transform.position = Camera.main.WorldToScreenPoint(position);
        }

        public void ChangeState(float portion, float total, Vector3 position)
        {
            ChangeState(portion / total, position);
        }

        public void ChangeState(int portion, int total, Vector3 position)
        {
            ChangeState((float)portion, (float)total, position);
        }
    }
}

