using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Threading;
using System.Text;
using System;
using UnityEngine.UI;
using TMPro;


[Serializable]
public class LoginPacket
{
    public string code;
    public string id;
    public string password;
}

[Serializable]
public class SignupPacket
{
    public string code;
    public string id;
    public string password;
    public string name;
    public string email;
}



public class NetworkManager : MonoBehaviour
{
    private Socket serverSocket;
    private IPEndPoint serverEndPoint;
    private Thread recvThread;

    public TMP_InputField nameUI;
    public TMP_InputField passwordUI;
    public TMP_InputField idUI;
    public TMP_InputField emailUI;

    public TMP_InputField newPasswordUI;
    public TMP_InputField newIdUI;

    void Start()
    {
        OnConnectedToServer();
    }

    void RecvPacket()
    {

        while (true)
        {
            byte[] lengthBuffer = new byte[2];

            int RecvLength = serverSocket.Receive(lengthBuffer, 2, SocketFlags.None);
            ushort length = BitConverter.ToUInt16(lengthBuffer, 0);
            length = (ushort)IPAddress.NetworkToHostOrder((short)length);
            byte[] recvBuffer = new byte[4096];
            RecvLength = serverSocket.Receive(recvBuffer, length, SocketFlags.None);

            string jsonString = Encoding.UTF8.GetString(recvBuffer);

            Debug.Log(jsonString);
            Thread.Sleep(10);

            //여기서 절대 gameobject.find 하지 말것
            //밖에 변수로 데이터(큐)로 빼놓고 이것을 바라보도록
            // 이 스레드는 유니티 메인 스레드와 별개임
        }

    }

    private void OnConnectedToServer()
    {
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
        serverSocket.Connect(serverEndPoint);
        recvThread = new Thread(new ThreadStart(RecvPacket));
        recvThread.IsBackground = true;
        recvThread.Start();

    }

    void SendPacket(string message)
    {
        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
        ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

        byte[] headerBuffer = BitConverter.GetBytes(length);

        byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];
        Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
        Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

        int SendLength = serverSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);

    }

    public void OnLogin()
    {
        LoginPacket loginPacket = new LoginPacket();
        loginPacket.code = "Login";
        loginPacket.id = idUI.text;
        loginPacket.password = passwordUI.text;

        SendPacket(JsonUtility.ToJson(loginPacket));
    }

    public void OnSignup()
    {
        SignupPacket signupPacket = new SignupPacket();
        signupPacket.code = "Signup";
        signupPacket.id = newIdUI.text;
        signupPacket.password = newPasswordUI.text;
        signupPacket.email = emailUI.text;
        signupPacket.name = nameUI.text;

        SendPacket(JsonUtility.ToJson(signupPacket));
    }

    private void OnApplicationQuit()
    {
        if (recvThread != null)
        {
            recvThread.Abort();
        }
        if (serverSocket != null)
        {
            serverSocket.Shutdown(SocketShutdown.Both);
            serverSocket.Close();
        }

    }

}
