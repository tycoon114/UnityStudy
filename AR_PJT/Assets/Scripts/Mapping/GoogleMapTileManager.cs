using FoodyGo.Services.GoogleMaps;
using FoodyGo.Services.GPS;
using FoodyGO.Mapping;
using System;
using System.Collections;
using UnityEngine;

namespace FoodyGo.Mapping
{
    /// <summary>
    /// MapTile ����, ����. ���� ���� ����
    /// GPS �����Ͱ� ������ ����� Ÿ�ϸ� Ȯ�� �� �ݴ���� Ÿ�� ����
    /// </summary>
    public class GoogleMapTileManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] GPSLocationService _gpsLocationService;
        [SerializeField] GoogleMapTile _mapTilePrefab;
        [SerializeField] Transform _mapTilesParent;
        [Serializable] GoogleStaticMapService _googleStaticMapService;

        [Header("debug")]
        Vector2Int _currentCenterTile;

        [Header("mannaged maptiles")]
        GoogleMapTile[,] _mapTiles;
        readonly int[] TILE_OFFSETS = { -1, 0, 1 };

        IEnumerator Start()
        {
            yield return new WaitUntil(() => _gpsLocationService.isReady);
            InitializeTiles();
        }


        /// <summary>
        /// ���� GPS ������� �߽� Ÿ�� �ε��� ���
        /// 3X3 �迭��  MapTile Ʋ ����
        /// </summary>
        void InitializeTiles()
        {
            _currentCenterTile = CalcTileCoordinate(_gpsLocationService.mapCenter);

            CreateTiles(_currentCenterTile);
        }

        void CreateTiles(Vector2Int center)
        {
            for (int i = 0; i < TILE_OFFSETS.Length; i++)
            {
                for (int j = 0; j < TILE_OFFSETS.Length; j++)
                {
                    Vector2Int coord = new Vector2Int(center.x + TILE_OFFSETS[i],
                                                      center.y + TILE_OFFSETS[j]);
                    GoogleMapTile tile = Instantiate(_mapTilePrefab, _mapTilesParent);
                    tile.tileOffset = new Vector2Int(i-1,j-1);
                    tile.googleStaticMapService = _googleStaticMapService;
                    tile.zoomLevel = _gpsLocationService.mapTileZoomLevel;
                    tile.gpsLocationService = _gpsLocationService;
                    tile.name = $"MapTile _{coord}_{coord.y}";
                    tile.transform.position = CalcWorldPosition(coord);
                    tile.RefreshMapTile();
                }
            }
        }

        /// <summary>
        /// Ÿ�� �ε����� ���ӿ��� ������ ����
        /// </summary>
        /// <param name="coord"> Ÿ�� �ε���</param>
        /// <returns>���� ��ġ</returns>
        Vector3 CalcWorldPosition(Vector2Int coord)
        {
            float spacing = 10;
            return new Vector3(-coord.x * spacing, 0f, coord.y * spacing);
        }

        /// <summary>
        /// Ư�� ���� �浵�� �ش��ϴ� ��Ÿ���� �ε��� ���
        /// </summary>
        /// <param name="center"></param>
        /// <returns></returns>
        Vector2Int CalcTileCoordinate(MapLocation center)
        {
            //�޸�ī�丣 �ȼ� ��ǥ (zoom =21)
            int pixelX21 = GoogleMapUtils.LonToX(center.longitude);
            int pixelY21 = GoogleMapUtils.LatToY(center.latitude);

            //Google Map Zoomlevel 1�� 2�辿 ���� �۾����� ������ (���Ĺ��� ����)
            // �ܷ��� ���̸�ŭ ���������� bit-shift�ϸ� ���ϴ� �ȼ����� ���� �� �ִ�.
            int shift = 21 - _gpsLocationService.mapTileZoomLevel;
            int pixelX = pixelX21 >> shift;
            int pixelY = pixelY21 >> shift;

            //Ÿ�ϸ�  �� �ȼ� ���� ������ �ε����� ���� �� �ִ�.
            return new Vector2Int(Mathf.RoundToInt(pixelX / (float)_gpsLocationService.mapTileSizePixels),
                           Mathf.RoundToInt(pixelY / (float)_gpsLocationService.mapTileSizePixels));

        }

    }
}
