using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.Learn.BuildingLibrary
{


    /// <summary>
    /// Класс Здание
    /// </summary>
    internal sealed class Building
    {
        private static int _maxHouseNumber = 0;
        private int _houseNumber = 0;
        private int _houseHigh = 0;
        private int _floorCount = 0;
        private int _flatCount = 0;
        private int _entranceCount = 0;

        /// <summary>
        /// ctor
        /// </summary>
        internal Building()
        {
            HouseNumber = ++_maxHouseNumber;
        }

        /// <summary>
        /// Номер дома. Генерируется автоматически
        /// </summary>
        public int HouseNumber { get => _houseNumber; private set => _houseNumber = value; }

        /// <summary>
        /// Высота дома
        /// </summary>
        public int HouseHigh
        {
            get => _houseHigh;
            set
            {
                if (value > 0)
                {
                    _houseHigh = value;
                }
            }
        }

        /// <summary>
        /// Количество этажей
        /// </summary>
        public int FloorCount
        {
            get => _floorCount;
            set
            {
                if (value > 0)
                {
                    _floorCount = value;
                }
            }
        }

        /// <summary>
        /// Количество квартир
        /// </summary>
        public int FlatCount
        {
            get => _flatCount;
            set
            {
                if (value > 0)
                {
                    _flatCount = value;
                }
            }
        }

        /// <summary>
        /// Количество подъездов
        /// </summary>
        public int EntranceCount
        {
            get => _entranceCount;
            set
            {
                if (value > 0)
                {
                    _entranceCount = value;
                }
            }
        }

        /// <summary>
        /// Высота одного этажа
        /// </summary>
        public double GetFloorHigh()
        {
            if (FloorCount > 0)
            {
                return (double)HouseHigh / FloorCount;
            }

            return 0;
        }

        /// <summary>
        /// Среднее количество квартир в подъезде
        /// </summary>
        public double GetAvgFlatCountPerEntrance()
        {
            if (EntranceCount > 0)
            {
                return (double)FlatCount / EntranceCount;
            }

            return 0;
        }

        /// <summary>
        /// Среднее количество квартир на этаже подъезда
        /// </summary>
        public double GetAvgFlatPerFloor()
        {
            if (EntranceCount > 0 && FloorCount > 0)
            {
                return FlatCount / EntranceCount / FloorCount;
            }

            return 0;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("HouseNumber: ").Append(HouseNumber)
                .Append(", HouseHigh: ").Append(HouseHigh)
                .Append(", FloorCount: ").Append(FloorCount)
                .Append(", FlatCount: ").Append(FlatCount)
                .Append(", EntranceCount: ").Append(EntranceCount);

            return stringBuilder.ToString();
        }
    }
}
