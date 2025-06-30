using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.lhm232.Practica_02;

namespace PSS.lhm232.Practica
{
    [TestClass]
    public class TestUsuarioView
    {
        [TestMethod]
        public void EqualsIquality_DifferentObjectsSameId_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", true);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", false);
            UsuarioView user3 = new UsuarioView(6, "Sofia", "pss", "Estudiante", false);
            Assert.IsFalse(Equals(user1, user2));
           
        }
        [TestMethod]
        public void EqualsIEqualityReferenciasIguales_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", true);
            UsuarioView user2 = user1;
            Assert.AreEqual(true, Equals(user1, user2));
        }
        [TestMethod]
        public void EqualsIquality_DifferentObjectsSameId_False()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", true);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", false);

            Assert.AreEqual(false, Equals(user1, user2));

        }
        [TestMethod]
        public void EqualsIEquality_ParametrosNullYOtro_False()
        {
            UsuarioView user1 = new UsuarioView(5, "Laura", "hola", "estudiante", true);
            UsuarioView user2 = null;
            Assert.AreEqual(false, Equals(user1, user2));
        }
        [TestMethod]
        public void EqualsIEquality_ParametrosNull_True()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;

            Assert.AreEqual(true, Equals(user1, user2));
        }
        [TestMethod]
        public void EqualsIEquality_ParametrosNullYOtro_True()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;
            Assert.AreEqual(true, Equals(user1, user2));
        }
        [TestMethod]
        public void EqualsObject_DifferentObjectSameID_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", true);
            Assert.AreEqual(false, user1.Equals(user2 as object));
        }
        [TestMethod]
        public void EqualsObject_DifferentObjectSameID_False()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", true);
            Assert.IsFalse(user1.Equals(user2 as object));
        }
        [TestMethod]
        public void EqualsObject_ReferenciasIguales_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = user1;
            Assert.AreEqual(true, user1.Equals(user2 as object));
        }
        [TestMethod]
        public void EqualsObject_ParametrosNullYOtro_False()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = null;

            Assert.IsFalse(user1.Equals(user2 as object));
        }
        [TestMethod]
        public void OperadorIgualQue_DifferentObjectsSameId_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", true);
            Assert.AreEqual(false, user1 == user2);
        }
        [TestMethod]
        public void OperadorIgualQue_MismaReferencia_True()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = user1;
            Assert.AreEqual(true, user1 == user2);
        }
        [TestMethod]
        public void OperadorIgualQue_ParametrosNull_True()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;

            Assert.AreEqual(true, user1 == user2);
        }
        [TestMethod]
        public void OperadorIgualQue_DifferentObjectsSameId_False()
        {
            UsuarioView user1 = new UsuarioView(3, "Laura", "pss", "Estudiante", false);
            UsuarioView user2 = new UsuarioView(6, "Martina", "pss", "Estudiante", true);
            Assert.AreEqual(false, user1 == user2);
        }
    }
}

