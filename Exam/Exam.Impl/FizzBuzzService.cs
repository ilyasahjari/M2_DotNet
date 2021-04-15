using System;
using System.Linq;


namespace Exam.Impl
{
    public class FizzBuzzService
    {
        public string Play(int upperBound)
        {
            string result = "";
            var list = System.Linq.Enumerable.Range(1, upperBound).Select(
                number => (number % 15 == 0) ? "FizzBuzz" : 
                          (number % 3 == 0) ? "Fizz" :
                          (number % 5 == 0) ? "Buzz" : 
                          number.ToString()).ToList();

            foreach (var t in list){ 
                result += t; 
            }

            return result;

        }
    }
}
