using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gfigure
{
    
    public static class MathGfigure
    {
        ///вычисление площади круга по радиусу
        public static double AreaCircle(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        ///вычисление площади треугольника по 3-м сторонам
        public static double AreaTriangle(double sideA, double sideB, double sideC)
        {
            double halfP = (sideA + sideB + sideC) / 2d;
            return Math.Sqrt(halfP * (halfP - sideA) * (halfP - sideB) * (halfP - sideC));
        }

        ///вычисление площади треугольника с определением является ли треугольник прямоугольным
        public static string AreaAndCheckTriangle90(double sideA, double sideB, double sideC)
        {
            bool angle;
            string result;

            if ((sideA * sideA + sideB * sideB == sideC * sideC) || (sideA * sideA + sideC * sideC == sideB * sideB) || (sideC * sideC + sideB * sideB == sideA * sideA))
            {
                angle = true;
                result = angle.ToString() + " " + Convert.ToString(AreaTriangle(sideA, sideB, sideC)); //если треугольник прямоугольный, то возращаем true + площадь
            }
            else
            {
                angle = false;
                result = angle.ToString() + " " + Convert.ToString(AreaTriangle(sideA, sideB, sideC)); //в противном случае возращаем false + площадь
            }

                return result;
        }

        ///вычисление площади четырехугольника
        public static double AreaQuadangle(double sideA, double sideB, double sideC, double sideD)
        {
            double halfP;
            halfP = (sideA + sideB + sideC + sideD) / 2d;
            return Math.Sqrt((halfP - sideA) * (halfP - sideB) * (halfP - sideC) * (halfP - sideD));
        }

        ///вычисление площади элипса по 2 полуосям
        public static double AreaEllipse(double halfSA, double halfSB)
        {
            return Math.PI * halfSA * halfSB;
        }

        ///вычисление площади фигуры без знания типа фигуры
        public static double WhatAreaOtherFigure(List<double>side, List<double>angle)
        {
            double checkError;
            List<double> sideT = new List<double>(); 
            List<double> areaT = new List<double>();
            List<double> areaFigurein = new List<double>();
            double result;
            int numAngleT = 0; int a = 0; int b = 1;

            //исключаем работу с отрицательными углами т.к с невыпуклыми фигурами пока что не работаем =)
            for (int i = 0; i < angle.Count(); i++)
            {
                if (angle.ElementAt(i) < 0) { return 0; } //в подобных случаях можно возвращать код ошибки, а не просто return 0;
            }                                             //это упростит работу пользоателя с dll

            //Вычисляем площади элипса по двум полуосям
            if (angle.Any() == false & side.Count() == 2)
            {
                return AreaEllipse(side.ElementAt(0), side.ElementAt(1));
            }

            //если углов нет и количество сторон 3, то вычисляем площадь Треугольника по сторонам
            else if (angle.Any() == false & side.Count() == 3)
            {
                return AreaTriangle(side.ElementAt(0), side.ElementAt(1), side.ElementAt(2));
            }

            //если углов нет и количество сторон 4, то вычисляем площадь Четырехугольника по сторонам
            else if (angle.Any() == false & side.Count() == 4) 
            {
                return AreaQuadangle(side.ElementAt(0), side.ElementAt(1), side.ElementAt(2), side.ElementAt(3));
            }


            //обрабатываем исключение деления на 0, при отсутствии значений
            try
            {
                checkError = side.Count() / angle.Count(); //вычисляем соотношение количества сторон и углов между ними
            }
            catch
            {
                return 0; //если нашли исключение, то завершаем выполнение и возращаем 0
            }

            //если количество уголов, сторон или стоношение между ними неверно, то завершаем выполнение и возращаем 0
            if (side.Count() <= 2 || angle.Count() < 2 || checkError < 2 || checkError > 2.5)
            {
                return 0;
            }


            /*если никакое из условий выше не стработало,то переходм к вычислению многоугольника с 4 и более сторонами
              у вычисляемой фигуры необходимо указать все стороны и по 1 углу на каждые 2 стороны*/

            //находим все стороны между каждыми 2 сторонами и их углом (вычисляем треугольники внутри фигуры)
            do
            {
                sideT.Add(Math.Sqrt(Math.Pow(side.ElementAt(a), 2) + Math.Pow(side.ElementAt(b), 2)
                      - 2 * side.ElementAt(a) * side.ElementAt(b) * Math.Cos(angle.ElementAt(numAngleT) * Math.PI / 180)));

                a += 2;
                b += 2;

            } while (++numAngleT < angle.Count());


            int numSideT = 0; a = 0; b = 1; //сбрасываем переменные до исходного значения

            //находим площади всех вычесленных Треугольников внутри фигуры
            do
            {
                areaT.Add(MathGfigure.AreaTriangle(side.ElementAt(a), side.ElementAt(b), sideT.ElementAt(numSideT)));
                a += 2;
                b += 2;

            } while (++numSideT < sideT.Count());


            switch (side.Count())
            {

                case 5:
                    //площадь внутренней фигуры "Треугольник" (2 стороны внутренней и 1 внешней)
                    areaFigurein.Add(MathGfigure.AreaTriangle(sideT.ElementAt(0), sideT.ElementAt(1), side.Max()));
                    break;

                case 6:
                    //площадь внутренней фигуры "Треугольник" (3 стороны внутренние)
                    areaFigurein.Add(MathGfigure.AreaTriangle(sideT.ElementAt(0), sideT.ElementAt(1), sideT.ElementAt(2)));
                    break;

                case 7:
                    //площадь внутренней фигуры "Четырехугольник" (3 стороны втурнение и 1 внешняя)
                    areaFigurein.Add(AreaQuadangle(side.ElementAt(0), side.ElementAt(1), side.ElementAt(2), side.Max()));
                    break;

                case 8:
                    //площадь внутренней фигуры "Четырехугольник" (4 стороны внутренние)
                    areaFigurein.Add(AreaQuadangle(side.ElementAt(0), side.ElementAt(1), side.ElementAt(2), side.ElementAt(3)));
                    break;

                    /*в ТЗ нет конкретизированных требований куда именно добавить фигуру. Значит, легкостью добавления
                      другой фигуры будет являть добвление в следущую конструкцию case N: */

            }

            //общая площадь заданного многоугольника
            result = areaT.Sum() + areaFigurein.Sum();

            return result;
        }
    }
}
