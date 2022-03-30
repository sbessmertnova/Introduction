namespace OOP_lesson5
{
    public class Complex
    {
        public double im;
        public double re;
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        public static Complex Subtract(Complex minuend, Complex subtrahend)
        {
            return new Complex(minuend.re - subtrahend.re, minuend.im - subtrahend.im);
        }
        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Complex Multi(Complex multiplier, Complex multiplicand)
        {
            return new Complex(multiplicand.re * multiplier.re - multiplicand.im * multiplier.im,
                multiplicand.re * multiplier.im + multiplicand.im * multiplier.re);
        }
        /// <summary>
        /// Вывод результата арифметических вычислений с комплексными числами
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (im > 0) ? $"{re} + {im}i" : $"{re} - {-im}i";
        }

    }
}