using FoodyGo.Services.GoogleMaps;
using FoodyGo.Services.GPS;
using FoodyGO.Mapping;
using System;
using System.Collections;
using UnityEngine;

namespace FoodyGo.Mapping
{
    /// <summary>
    /// MapTile 생성, 갱신. 제거 등의 관리
    /// GPS 데이터가 범위를 벗어날때 타일맵 확장 및 반대방향 타일 제거
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
        /// 현재 GPS 기반으로 중심 타일 인덱스 계산
        /// 3X3 배열로  MapTile 틀 생성
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
        /// 타일 인덱스로 게임월드 포지션 산출
        /// </summary>
        /// <param name="coord"> 타일 인덱스</param>
        /// <returns>월드 위치</returns>
        Vector3 CalcWorldPosition(Vector2Int coord)
        {
            float spacing = 10;
            return new Vector3(-coord.x * spacing, 0f, coord.y * spacing);
        }

        /// <summary>
        /// 특정 위도 경도에 해당하는 맵타일의 인덱스 계산
        /// </summary>
        /// <param name="center"></param>
        /// <returns></returns>
        Vector2Int CalcTileCoordinate(MapLocation center)
        {
            //메르카토르 픽셀 좌표 (zoom =21)
            int pixelX21 = GoogleMapUtils.LonToX(center.longitude);
            int pixelY21 = GoogleMapUtils.LatToY(center.latitude);

            //Google Map Zoomlevel 1당 2배씩 값이 작아지기 때문에 (공식문서 참조)
            // 줌레벨 차이만큼 오른쪽으로 bit-shift하면 원하는 픽셀값을 구할 수 있다.
            int shift = 21 - _gpsLocationService.mapTileZoomLevel;
            int pixelX = pixelX21 >> shift;
            int pixelY = pixelY21 >> shift;

            //타일맵  당 픽셀 수로 나누면 인덱스를 구할 수 있다.
            return new Vector2Int(Mathf.RoundToInt(pixelX / (float)_gpsLocationService.mapTileSizePixels),
                           Mathf.RoundToInt(pixelY / (float)_gpsLocationService.mapTileSizePixels));

        }

    }
}
