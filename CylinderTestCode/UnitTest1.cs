using CylinderProject.Models;

namespace CylinderTestCode
{
    public class UnitTest1
    {
        [Fact]
        public void TestSettingRadiusAndHeight()
        {
            Cylinder cylinder = new(10, 20);
            Assert.Equal(10, cylinder.Radius);
            Assert.Equal(20, cylinder.Height);
        }

        [Fact]
        public void TestRadiusAndHeightLessThan0()
        {
            Assert.Throws<ArgumentException>(() => new Cylinder(-10, 20));
            Assert.Throws<ArgumentException>(() => new Cylinder(10, -20));
            Assert.Throws<ArgumentException>(() => new Cylinder(5, 0));
            Assert.Throws<ArgumentException>(() => new Cylinder(0, 5));
        }

        [Fact]
        public void TestGetVolumeAndGetSurfaceArea() 
        {
            Cylinder cylinder = new(1, 1);
            Assert.Equal(Math.PI * Math.Pow(1, 2) * 1, cylinder.GetVolume(), precision: 2);
            Assert.Equal(2 * Math.PI * Math.Pow(1, 2) + 2 * Math.PI * 1 * 1, cylinder.GetSurfaceArea(), precision: 2);

            cylinder = new(1/3.0, 1/5.0);
            Assert.Equal(Math.PI * Math.Pow((1/3.0), 2) * (1/5.0), cylinder.GetVolume(), precision: 2);
            Assert.Equal(2 * Math.PI * Math.Pow((1/3.0), 2) + 2 * Math.PI * (1/3.0) * (1/5.0), cylinder.GetSurfaceArea(), precision: 2);
        }

        [Fact]
        public void TestResize()
        {
            Cylinder cylinder = new(1, 1);
            cylinder.Resize(2,2);
            Assert.Equal(2, cylinder.Radius);
            Assert.Equal(2, cylinder.Height);
            Assert.Throws<ArgumentException>(() => cylinder.Resize(-2, 2));
            Assert.Throws<ArgumentException>(() => cylinder.Resize(0, 2));
        }

        [Fact]
        public void TestIfCylinderIsNotNull()
        {
            Cylinder cylinder = new(1,1);
            Assert.NotNull(cylinder);
        }

        [Fact]
        public void TestCheckIfRadiusIsInRange()
        {
            Cylinder cylinder = new(1, 100);
            Assert.InRange(cylinder.Radius, 1, 100);
        }
    }
}