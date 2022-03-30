using System;
namespace OOP_lesson5
{
    public class RationalNumber
    {
        private readonly int _numerator;
        private readonly int _denominator;
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            _numerator = numerator;
            _denominator = denominator;
        }
        public int Numerator { get; set; }

        public static bool operator ==(RationalNumber a, RationalNumber b) =>
             a.Equals(b);
        public static bool operator !=(RationalNumber a, RationalNumber b) =>
             !a.Equals(b);
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            CommonDenominator(a, b, out var numeratorOfFirstFraction, out var numeraturOfSecondFraction);
            return numeratorOfFirstFraction > numeraturOfSecondFraction;
        }
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            CommonDenominator(a, b, out var numeratorOfFirstFraction, out var numeraturOfSecondFraction);
            return numeratorOfFirstFraction < numeraturOfSecondFraction;
        }
        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            CommonDenominator(a, b, out var numeratorOfFirstFraction, out var numeraturOfSecondFraction);
            return numeratorOfFirstFraction >= numeraturOfSecondFraction;
        }
        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            CommonDenominator(a, b, out var numeratorOfFirstFraction, out var numeraturOfSecondFraction);
            return numeratorOfFirstFraction <= numeraturOfSecondFraction;
        }
        public static RationalNumber operator +(RationalNumber a, RationalNumber b) =>
            Reduce(new RationalNumber(a._numerator * b._denominator + b._numerator * a._denominator,
                a._denominator * b._denominator));
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            int generalDenominator = CommonDenominator(a, b, out int minuendNumerator, out int subtrahendNumeratur);
            return Reduce(new RationalNumber(minuendNumerator - subtrahendNumeratur, generalDenominator));
        }
        public static RationalNumber operator ++(RationalNumber a)
        {
            if (a._numerator > a._denominator)
            {
                throw new ArgumentException("Знаменатель не должен быть меньше числительного");
            }
            while (a.Numerator != a._denominator)
            {
                a.Numerator++;
            }
            return new RationalNumber(a.Numerator, a._denominator);
        }
        public static RationalNumber operator --(RationalNumber a)
        {
            if (a._numerator > a._denominator)
            {
                throw new ArgumentException("Знаменатель не должен быть меньше числительного");
            }
            while (a.Numerator != 0)
            {
                a.Numerator--;
            }
            return new RationalNumber(a.Numerator, a._denominator);
        }
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            int generalNumerator = a.Numerator * b.Numerator;
            int generalDenominator = a._denominator * b._denominator;
            return Reduce(new RationalNumber(generalNumerator, generalDenominator));
        }
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            int generalNumerator = a._numerator * b._denominator;
            int generalDenominator = a._denominator * b._numerator;
            return Reduce(new RationalNumber(generalNumerator, generalDenominator));
        }

        public override bool Equals(object userFraction)
        {
            if (userFraction is RationalNumber)
            {
                var b = (RationalNumber)userFraction;
                if (_numerator == b._numerator && _denominator == b._denominator)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                throw new ArgumentException("Неподходящий тип объекта");
        }
        public static explicit operator float(RationalNumber a) => a._numerator / a._denominator;

        public static explicit operator int(RationalNumber a) => a._numerator / a._denominator;

        /// <summary>
        /// Приведение дробей к общему знаменателю
        /// </summary>
        /// <param name="firstFraction">первая дробь</param>
        /// <param name="secondFraction">вторая дробь</param>
        /// <param name="numeratorOfFirstFraction">числитель первой дроби, умноженный на знаменатель второй</param>
        /// <param name="numeraturOfSecondFraction">числитель второй дроби, умноженный на знаменатель первой/param>
        /// <returns></returns>
        public static int CommonDenominator(RationalNumber firstFraction, RationalNumber secondFraction, out int numeratorOfFirstFraction, out int numeraturOfSecondFraction)
        {
            numeratorOfFirstFraction = firstFraction._numerator * secondFraction._denominator;
            numeraturOfSecondFraction = secondFraction._numerator * firstFraction._denominator;
            int generalDenominator = firstFraction._denominator * secondFraction._denominator;
            return generalDenominator;
        }
        /// <summary>
        /// Упрощение дроби
        /// </summary>
        /// <param name="fraction">дробь, которую необходимо упростить</param>
        /// <returns></returns>
        static RationalNumber Reduce(RationalNumber fraction)
        {
            int minCommonDivisor = GetBiggestDivisor(fraction._numerator, fraction._denominator);
            return new RationalNumber(fraction._numerator / minCommonDivisor, fraction._denominator / minCommonDivisor);
        }
        /// <summary>
        /// Нахождение наименьшего общего делителя
        /// </summary>
        /// <param name="firstValue">первое число</param>
        /// <param name="secondValue">второе число</param>
        /// <returns></returns>
        static int GetBiggestDivisor(int firstValue, int secondValue)
        {
            firstValue = Math.Abs(firstValue);
            secondValue = Math.Abs(secondValue);
            if (firstValue == secondValue)
            {
                return firstValue;
            }
            if (firstValue > secondValue)
            {
                int tempValue = firstValue;
                firstValue = secondValue;
                secondValue = tempValue;
            }
            return GetBiggestDivisor(firstValue, secondValue - firstValue);
        }
        public double Quotient => (Convert.ToDouble(_numerator) / Convert.ToDouble(_denominator));

        public override string ToString()
        {
            return $"{_numerator}/{_denominator} ({Quotient:F2})";
        }
    }
}
