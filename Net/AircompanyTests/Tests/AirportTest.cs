using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> _planes = new List<Plane>(ListPlanes.planes);

        private PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);

        [Test]
        public void CheckExistsTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new Airport(_planes).GetTransportMilitaryPlanes().ToList();
            Assert.IsTrue(transportMilitaryPlanes.Count > 0);
        }

        [Test]
        public void CheckExistsPassengerPlaneWithMaxPassengersCapacity()
        {
            PassengerPlane expectedPlaneWithMaxPassengersCapacity = new Airport(_planes).GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));
        }

        [Test]
        public void CheckSortedByMaxLoadCapacity()
        {
            List<Plane> planesSortedByMaxLoadCapacity = new Airport(_planes).SortByMaxLoadCapacity().GetPlanes().ToList();
            Assert.That(planesSortedByMaxLoadCapacity.SequenceEqual(_planes.OrderBy(plane => plane.GetMaxLoadCapacity()).ToList()));
        }
    }
}
