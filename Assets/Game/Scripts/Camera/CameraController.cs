using Cinemachine;
using UnityEngine; 

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    public void WinGameTransition()
    {
        CinemachineTransposer transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0, 0, 0);
    }
}