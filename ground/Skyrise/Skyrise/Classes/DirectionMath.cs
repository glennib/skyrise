using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrise
{
    class DirectionMath
    {
        /// <summary>
        /// Radius of Earth. Source is Wikipedia.
        /// </summary>
        public const double EARTH_RADIUS = 6378100;

        /// <summary>
        /// Calculates the angle relative to north between two points on Earth. Positive eastwards.
        /// </summary>
        /// <param name="myLat">Observer's latitude.</param>
        /// <param name="myLon">Observer's longitude.</param>
        /// <param name="objLat">Object's latitude.</param>
        /// <param name="objLon">Object's longitude.</param>
        /// <returns>Angle in radians. Between -Pi and Pi.</returns>
        public static double Azimuth(double myLat, double myLon, double objLat, double objLon) // Tar koordinater og gir tilbake azimuth.
        {
            double dLong = objLon - myLon;
            double y = Math.Sin(dLong) * Math.Cos(objLat);
            double x = Math.Cos(myLat) * Math.Sin(objLat) - Math.Sin(myLat) * Math.Cos(objLat) * Math.Cos(dLong);
            double azi = Math.Atan2(y, x);

            return azi;
        }

        /// <summary>
        /// Calculates the angle above the horizon of an object.
        /// </summary>
        /// <param name="myLat">Observer's latitude.</param>
        /// <param name="myLon">Observer's longitude.</param>
        /// <param name="myAlt">Observer's altitude.</param>
        /// <param name="objLat">Object's latitude.</param>
        /// <param name="objLon">Object's longitude.</param>
        /// <param name="objAlt">Object's altitude.</param>
        /// <returns>Angle in radians.</returns>
        public static double Elevation(double myLat, double myLon, double myAlt, double objLat, double objLon, double objAlt)
        {

            double a = EarthCenterAngle(myLat, myLon, objLat, objLon);
            double LDirect = Math.Sqrt(2 * EARTH_RADIUS * EARTH_RADIUS * (1 - Math.Cos(a)));

            double L1 = LDirect * Math.Cos(a / 2);
            double L2 = LDirect * Math.Sin(a / 2);
            double L3 = objAlt * Math.Sin(a);
            double L4 = (objAlt * Math.Cos(a)) - L2;

            double vRad = Math.Atan2(L4 - myAlt, L1 + L3);

            return vRad;
        }

        /// <summary>
        /// Calculates the angle between two points on Earth and Earth's center.
        /// </summary>
        /// <param name="myLat">Observer's latitude.</param>
        /// <param name="myLon">Observer's longitude.</param>
        /// <param name="objLat">Object's latitude.</param>
        /// <param name="objLon">Object's longitude.</param>
        /// <returns>Angle in radians.</returns>
        public static double EarthCenterAngle(double myLat, double myLon, double objLat, double objLon)
        {
            double dLat = objLat - myLat;
            double dLon = objLon - myLon;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(myLat) * Math.Cos(objLat);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return c;
        }
    }
}