using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caesar_Cipher.UnitTests
{
    [TestClass]
    public class CipherTests
    {
        [TestMethod]
        public void Encrypt_Shift0_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Тестовая строка", result);
        }
        [TestMethod]
        public void Encrypt_Shift1_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 1);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Уётупгба тусплб", result);
        }
        [TestMethod]
        public void Encrypt_Shift2_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 2);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Фжуфрдвб уфтрмв", result);
        }
        [TestMethod]
        public void Encrypt_Shift3_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 3);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Хзфхсегв фхуснг", result);
        }
        
        [TestMethod]
        public void Encrypt_Shift6_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 6);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Шкчшфзёе чшцфрё", result);
        } 
        
        [TestMethod]
        public void Encrypt_Shift32_IsValid()
        {
            //Arrange
            var text = "Тестовая строка";

            //Act
            var result = Cipher.Encrypt(text, 32);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual("Сдрснбяю рспнйя", result);
        }
        
        [TestMethod]
        public void Encrypt_TwoShiftsInARow_IsValid()
        {
            //Arrange
            var text = Cipher.Encrypt("Тестовая строка", 19);
            Cipher.Encrypt(text, 0);
            //Act
            var result = Cipher.Encrypt("Тестовая строка", 32);
            result = Cipher.Encrypt(result, 19);
            Cipher.Encrypt(text, 0);
            //Assert
            Assert.AreEqual(text, result);
        }
        [TestMethod]
        public void GuessStep_Step_IsGuessedCorrectly()
        {
            //Arrange
            int expected = 9;
            
            //Act
            int result = Cipher.GuessStep("Ячшьза дьец и иёшёб ц жзаык ивщёяу ягть еёоа а ёйжзчщгхиу яч йёшёб ойё шт жкйу деь еь жзёзёоаг");
            
            //Assert
            Assert.AreEqual(expected, result);
        }
        
    }
}
