using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.Learn.BuildingLibrary
{

    /// <summary>
    /// Factory of <see cref="Building"/>
    /// </summary>
    internal sealed class BuildingFactory
    {
        private static readonly int _houseHighDefault = 10;
        private static readonly int _floorCountDefault = 3;
        private static readonly int _flatPerFloorCountDefault = 4;
        private static readonly int _entranceCountDefault = 1;
        private static readonly HashSet<string> _hashSet = new();

        /// <summary>
        /// Удаляет здание из списка
        /// </summary>
        /// <param name="building">Здание</param>
        /// <returns>true if success otherwise false</returns>
        public static bool Remove(Building building)
        {
            if (!Find(building))
            {
                _hashSet.Remove(building.ToString());
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return <see cref="Building"/>
        /// </summary>
        public static Building Create(int houseHigh, int floorCount, int flatCount, int entranceCount)
        {
            Building building = new()
            {
                HouseHigh = houseHigh,
                FloorCount = floorCount,
                FlatCount = flatCount,
                EntranceCount = entranceCount,
            };

            Add(building);
            return building;
        }

        /// <summary>
        /// Return <see cref="Building"/>
        /// </summary>
        public static Building Create(int houseHigh, int floorCount, int flatCount)
        {
            return Create(houseHigh, floorCount, flatCount, _entranceCountDefault);
        }

        /// <summary>
        /// Return <see cref="Building"/>
        /// </summary>
        public static Building Create(int houseHigh, int floorCount)
        {
            return Create(houseHigh, floorCount, _flatPerFloorCountDefault * floorCount * _entranceCountDefault, _entranceCountDefault);
        }

        /// <summary>
        /// Return <see cref="Building"/>
        /// </summary>
        public static Building Create(int houseHigh)
        {
            return Create(houseHigh, _floorCountDefault, _flatPerFloorCountDefault * _floorCountDefault * _entranceCountDefault, _entranceCountDefault);
        }

        /// <summary>
        /// Return <see cref="Building"/>
        /// </summary>
        public static Building Create()
        {
            return Create(_houseHighDefault, _floorCountDefault, _flatPerFloorCountDefault * _floorCountDefault * _entranceCountDefault, _entranceCountDefault);
        }

        public static bool Find(Building building)
        {
            return _hashSet.Contains(building.ToString());
        }

        private static bool Add(Building building)
        {
            if (!Find(building))
            {
                _hashSet.Add(building.ToString());
                return true;
            }

            return false;
        }
    }
}
