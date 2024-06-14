using System.Collections.Generic;
using UnityEngine;
namespace OtusProject.View
{
    public class WaveTextView : MonoBehaviour
    {
        [SerializeField] private List<string> StartMessages = new List<string>();
        [SerializeField] private List<string> EndMessages = new List<string>();
        [SerializeField] private List<string> LastMessage = new List<string>();
        public string GetStartMessage() => StartMessages[Random.Range(0, StartMessages.Count)];
        public string GetEndMessage() => EndMessages[Random.Range(0, EndMessages.Count)];
        public string GetLastMessage() => LastMessage[Random.Range(0, LastMessage.Count)];
    }
}