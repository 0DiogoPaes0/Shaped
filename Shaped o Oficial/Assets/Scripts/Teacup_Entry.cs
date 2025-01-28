using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacup_Entry : MonoBehaviour
{
        [SerializeField] private Transform teacupExit;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.position = teacupExit.position;
            }
        }
}
