using System.Collections.Generic;
using UnityEngine;
namespace OtusProject.View
{
    public class WaveTextView : MonoBehaviour
    {
        [SerializeField] private List<string> StartWaveMessages = new List<string>();
        [SerializeField] private List<string> EndVaweMessages = new List<string>();

        //������� ��������� ����� ��� ������ � � ����� �����
        public string GetStartMessage() => StartWaveMessages[Random.Range(0, StartWaveMessages.Count)];
        public string GetEndMessage() => EndVaweMessages[Random.Range(0, EndVaweMessages.Count)];
    }
}