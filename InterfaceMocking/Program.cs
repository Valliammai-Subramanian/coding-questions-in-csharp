using System;
using Moq;

namespace MoqInterfaceMocking
{
    public interface ISecretService
    {
        int GetSecretNumber(string secretOne, string secretTwo);
        bool IsTheMeaningOfLife(int number);
    }

    public static class MoqDefinition
    {
        public static ISecretService GetMockedInMoqISecretService()
        {
            Mock<ISecretService> mock = new Mock<ISecretService>(MockBehavior.Strict);

            mock.Setup(service => service.IsTheMeaningOfLife(42)).Returns(true);
            mock.Setup(service => service.IsTheMeaningOfLife(It.Is<int>(n => n<200 && n != 42))).Returns(false);
            mock.Setup(service => service.IsTheMeaningOfLife(It.Is<int>(n => n>=200))).Throws(new NotSupportedException());

            mock.Setup(service => service.GetSecretNumber("Secret_10","Secret_10")).Returns(10);
            mock.Setup(service => service.GetSecretNumber("Secret_20",It.IsAny<string>())).Returns(20);
            mock.Setup(service => service.GetSecretNumber(It.Is<string>(s => s.Contains("los secretos")),null)).Returns(30);
            //mock.Setup(service => service.GetSecretNumber(It.IsAny,It.IsAny)).Returns(-1);

            return mock.Object;
        }
    }
}