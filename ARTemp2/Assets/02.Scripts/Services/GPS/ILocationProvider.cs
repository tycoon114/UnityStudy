using System;

namespace FoodyGo.Services.GPS
{
    public interface ILocationProvider
    {
        /// <summary>
        /// ������
        /// </summary>
        bool isRunning { get; }

        /// <summary>
        /// ����
        /// </summary>
        double latitude { get; }

        /// <summary>
        /// �浵
        /// </summary>
        double longitude { get; }

        /// <summary>
        /// ��
        /// </summary>
        double altitude { get; }

        /// <summary>
        /// latitude, longitude, altitude, horizontalAccuracy, timestamp
        /// </summary>
        event Action<double, double, double, float, double> onLocationUpdated;

        /// <summary>
        /// ��ġ ������ ���� ����
        /// </summary>
        void StartService();

        /// <summary>
        /// ��ġ ������ ���� ����
        /// </summary>
        void StopService();
    }
}