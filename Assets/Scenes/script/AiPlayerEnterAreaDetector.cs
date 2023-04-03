using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AiPlayerEnterAreaDetector : MonoBehaviour
    {
        // Start is called before the first frame update
        [field : SerializeField]

        public bool PlayerInArea { get; private set; }

        public Transform Player { get; private set; }

        [SerializeField]
        private string detectionTag = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(detectionTag)) 
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(detectionTag))
            {
                PlayerInArea = false;
                Player = null;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
