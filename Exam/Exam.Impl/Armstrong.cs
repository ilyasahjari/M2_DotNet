using System;

namespace Exam.Impl
{
    public class Armstrong
    {
        public bool IsArmstrong(int input)
        { 
            int n, c, result = 0, temp;
            n = input;
            temp = n;
            while (n > 0)
            {
                c = n % 10;
                result = result + (c * c * c);
                n = n / 10;
            }
            if (temp == result)
                return true;
            else
                return false;
        }
    }
}
