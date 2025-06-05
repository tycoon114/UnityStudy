using FoodyGo.Services.GoogleMaps;
using FoodyGo.Services.GPS;
using FoodyGO.Mapping;
using UnityEngine;

namespace FoodyGo.Mapping
{
    public class GoogleMapTile : MonoBehaviour
    {
        [Header("Map Settings")]
        [Tooltip("�� ����")]
        [Range(1, 20)]
        public int zoomLevel = 15;

        [Tooltip("�� �ؽ��� ������")]
        [Range(64, 1024)]
        public int size = 640;

        [Tooltip("���� �� ����")]
        public MapLocation worldCenterLocation;

        [Header("Tile Settings")]
        [Tooltip("Ÿ�ϸ��� ���� ������")]
        public Vector2Int tileOffset;

        [Tooltip("������ ������ ���� �߽� ��ġ")]
        public MapLocation tileCenterLocation;

        [Header("Map Services")]
        public GoogleStaticMapService googleStaticMapService;

        [Header("GPS Services")]
        public GPSLocationService gpsLocationService;

        private Renderer _renderer;


        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            gpsLocationService.onMapRedraw += RefreshMapTile;
        }

        private void OnDisable()
        {
            gpsLocationService.onMapRedraw -= RefreshMapTile;
        }

        private void Start()
        {
            RefreshMapTile();
        }

        public void RefreshMapTile()
        {
            // �����¿����� �߽���ġ ���
            tileCenterLocation.latitude = GoogleMapUtils.AdjustLatByPixels(
                worldCenterLocation.latitude,
                (int)(size * tileOffset.y),
                zoomLevel);

            tileCenterLocation.longitude = GoogleMapUtils.AdjustLonByPixels(
                worldCenterLocation.longitude,
                (int)(size * tileOffset.x),
                zoomLevel);

            // �� �ؽ��� ��û
            googleStaticMapService.LoadMap(tileCenterLocation.latitude,
                                           tileCenterLocation.longitude,
                                           zoomLevel,
                                           new Vector2(size, size),
                                           OnMapLoaded);
        }

        private void OnMapLoaded(Texture2D texture)
        {
            if (_renderer.material.mainTexture != null)
                Destroy(_renderer.material.mainTexture);

            _renderer.material.mainTexture = texture;
        }
    }
}
