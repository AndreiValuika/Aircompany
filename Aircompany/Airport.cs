using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.Where(x => x.GetType() == typeof(PassengerPlane)).Select(x => (PassengerPlane)x).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(x => x.GetType() == typeof(MilitaryPlane)).Select(x => (MilitaryPlane)x).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.PlaneTypeIs() == MilitaryType.TRANSPORT).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return _planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", _planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
