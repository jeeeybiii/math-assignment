namespace MathAssignmentTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestComputeAreaMethod()
        {
            //Arrange
            double expectedResult = 30;
            //Act
            double actualResult = MathAssignment.Program.ComputeArea(5, 6);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
