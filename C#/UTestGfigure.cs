using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gfigure.test
{
    [TestClass]
    public class UTestGfigure
    {

        ///Тесты методов отдельных фигур
        [TestMethod]
        public void AriaCircle_Radius5Return78x()
        {
            double radius = 5;
            double expected = 78.539;
            double delta = 0.001;

            double actual = MathGfigure.AreaCircle(radius);

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void AreaTriangle_sideA5sideB5sideC3_return7x()
        {
            double sideA = 5;
            double sideB = 5;
            double sideC = 3;
            double expected = 7.154;
            double delta = 0.001;

            double actual = MathGfigure.AreaTriangle(sideA, sideB, sideC);
            Assert.AreEqual(expected, actual, delta);

        }

        [TestMethod]
        public void AreaAndCheckTriangle90_sideA3sideB4sideC5_returnTrue_and_6()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            string expected = "True 6";

            string actual = MathGfigure.AreaAndCheckTriangle90(sideA, sideB, sideC);
            Assert.AreEqual(expected, actual, true);

        }

        [TestMethod]
        public void AreaQuadangle_sideA5sideB5sideC5sideC5_return25()
        {
            double sideA = 5;
            double sideB = 5;
            double sideC = 5;
            double sideD = 5;
            double expected = 25;

            double actual = MathGfigure.AreaQuadangle(sideA, sideB, sideC, sideD);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreaEllipse_halfA2halfB8_return50x()
        {
            double halfA = 2;
            double halfB = 8;
            double expected = 50.265;
            double delta = 0.001;

            double actual = MathGfigure.AreaEllipse(halfA, halfB);
            Assert.AreEqual(expected, actual, delta);
        }


        ///Тесты метода на вычисление площади фигуры неизвестного типа
        //тест вычисления площади элипса
        [TestMethod]
        public void WhatAreaOtherFigure_halfSA2B8andAngleNo_return50x()
        {
            List<double> side = new List<double>() { 2,8 };
            List<double> angle = new List<double>();

            double expected = 50.265;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);

        }

        //тест расчета площади треугольника
        [TestMethod]
        public void WhatAreaOtherFigure_side3andAngleNo_return7x()
        {
            List<double> side = new List<double>() { 5, 5, 3 };
            List<double> angle = new List<double>();
            
            double expected = 7.154;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);
        }

        //тест расчета четырехугольника без известных углов
        [TestMethod]
        public void WhatAreaOtherFigure_side4andAngleNo_return25()
        {
            List<double> side = new List<double>() { 5, 5, 5, 5};
            List<double> angle = new List<double>();

            double expected = 25;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);
        }

        //тест расчета соответствия количества углов к количеству сторон
        [TestMethod]
        public void WhatAreaOtherFigure_ratioSideToAngle()
        {
            List<double> side = new List<double>() { 5, 5,  5, 5,  5, 5};
            List<double> angle = new List<double>() { 90, 90 , 90, 90 };

            double expected = 0;

            double actualA = MathGfigure.WhatAreaOtherFigure(side, angle);

            angle.Clear();
            double[] b = { 90, 90 };
            angle.AddRange(b);
            double actualB = MathGfigure.WhatAreaOtherFigure(side, angle);

            double actual = actualA + actualB;

            Assert.AreEqual(expected, actual);
        }

        //тест расчета площадей всех треугольников внутри фигуры
        [TestMethod]
        public void WhatAreaOtherFigure_allAriaTriangleinFiguge()
        {
            List<double> side = new List<double>() { 5, 5, 5, 5 };
            List<double> angle = new List<double>() { 90, 90 };

            double expected = 25;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual);
        }

        //тест расчета площади пятиугольника
        [TestMethod]
        public void WhatAreaOtherFigure_area5Angle()
        {
            List<double> side = new List<double>() { 8, 8, 8, 8, 8};
            List<double> angle = new List<double>() { 108, 108 };

            double expected = 110.110;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);

        }

        //тест расчета площади шестиугольника
        [TestMethod]
        public void WhatAreaOtherFigure_area6angle()
        {
            List<double> side = new List<double>() { 6, 6, 6, 6, 6, 6 };
            List<double> angle = new List<double>() { 120, 120, 120 };

            double expected = 93.530;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);
        }

        //тест расчета площади симиугольника
        [TestMethod]
        public void WhatAreaOtherFigure_area7angle()
        {
            List<double> side = new List<double>() { 7, 7, 7, 7, 7, 7, 7 };
            List<double> angle = new List<double>() { 128, 128, 128 };

            double expected = 106.918;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);
        }

        //тест расчета площади восьмиугольника
        [TestMethod]
        public void WhatAreaOtherFigure_area8angle()
        {
            List<double> side = new List<double>() { 8, 8, 8, 8, 8, 8, 8, 8};
            List<double> angle = new List<double>() { 135, 136, 135, 135 };

            double expected = 154.111;
            double delta = 0.001;

            double actual = MathGfigure.WhatAreaOtherFigure(side, angle);
            Assert.AreEqual(expected, actual, delta);
        }

    }
}
