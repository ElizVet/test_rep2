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

        public Airport(IEnumerable<Plane> planes) => this._planes = planes.ToList();
        

        public List<PassengerPlane> GetPassengersPlanes() => _planes.
            Where(plane => plane.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>().ToList();

        public List<MilitaryPlane> GetMilitaryPlanes() => _planes.
            Where(plane => plane.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>().ToList();

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity() => 
            GetPassengersPlanes().Aggregate((passengersPlane, passengersPlaneNext) => 
            passengersPlane.PassengersCapacityIs() > passengersPlaneNext.PassengersCapacityIs() ? passengersPlane : passengersPlaneNext);             

        public List<MilitaryPlane> GetTransportMilitaryPlanes() => GetMilitaryPlanes().
            Where(militaryPlane => militaryPlane.PlaneTypeIs() == MilitaryType.Transport).ToList();
        

        public Airport SortByMaxDistance() => new Airport(_planes.OrderBy(plane => plane.GetMaxFlightDistance()));

        public Airport SortByMaxSpeed() => new Airport(_planes.OrderBy(plane => plane.GetMaxSpeed()));

        public Airport SortByMaxLoadCapacity() => new Airport(_planes.OrderBy(plane => plane.GetMaxLoadCapacity()));
        
        public IEnumerable<Plane> GetPlanes() => _planes;

        public override string ToString() => "Airport{" + "planes=" + 
            string.Join(", ", _planes.Select(plane => plane.GetModel())) + '}';
    }
}
