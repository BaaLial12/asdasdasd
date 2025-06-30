using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static PSS.lhm232.ConectaCuatro.Ficha;

namespace PSS.lhm232.ConectaCuatro
{
    [TestClass]
    public class TestFicha
    {
        [TestMethod]
        public void Constructor_SinParametros_NoNulo()
        {
            Ficha ficha = new Ficha();
            Assert.IsNotNull(ficha);
        }
        [TestMethod]
        public void Constructor_Color_EsCorrecto()
        {
            Ficha ficha = new Ficha(ColorEnum.Amarillo);
            bool resultado = ficha.Color == ColorEnum.Amarillo;
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Constructor_SinParametros_ColorSinColor()
        {
            Ficha ficha = new Ficha();
            bool resultado = ficha.Color == ColorEnum.SinColor;
            Assert.IsTrue(resultado);
        }
    }
    }


