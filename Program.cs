using System;

namespace Aufgabe4
{
    class Program
    {
        
        static int input;
        static int Fbase;
        static int Tbase;
        static int sysnum;
        static int sum;

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertDecimalToHexal(15));
           Console.WriteLine(ConvertHexalToDezimal(23));
           Console.WriteLine(ConvertToBaseFromDecimal(6,231));
           Console.WriteLine(ConvertToDecimalFromBase(6,1023)); 
           
        }
        public static int ConvertDecimalToHexal(int dec)
        {
            if (dec >= 0 && dec <= 1023)
            {
                return ConvertToBaseFromDecimal(6, dec);
            }
            else
            {
                return -1;
            }

        }
        public static int ConvertHexalToDezimal(int hexal)
        { 
            return ConvertToDecimalFromBase(6, hexal);
        }
        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
          int divider;
            sysnum = 0;
            
            List<int> residuals = new List<int>();

                do{
                    int modulo = dec % toBase;
                    residuals.Add(modulo);
                    int dec_minus_modulo = dec - modulo;
                    divider = dec_minus_modulo/toBase;
                    dec = divider;
                }while(divider != 0);
            

            residuals.Reverse();
            for(int i = 0; i<=residuals.Count-1; i++){
                sysnum += residuals[i] * Convert.ToInt32(Math.Pow(10,residuals.Count-i-1));
            }

            return sysnum;
        }
        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            sum = 0;
            int[] digits = new int[1 + (int)Math.Log10(number)];

            for(int i = digits.Length-1; i >= 0; i--){
                int digit;
                number = Math.DivRem(number, 10, out digit);
                digits[i]=digit;
            }

            List<int> outputs = new List<int>();
            Array.Reverse(digits);
            for(int i= 0; i <= digits.Length-1; i++){
                int multiplication = digits[i] * (int)Math.Pow(fromBase,i);
                outputs.Add(multiplication);
            }

            for(int i= 0; i <= outputs.Count-1; i++){
                sum = sum + outputs[i];
            }
            return sum;
}
        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            sysnum=0;
            input = number;
            Tbase = toBase;
            Fbase = fromBase;

            if(2 <= toBase && 10 >= toBase && fromBase <= 10 && fromBase >=2){
                int dec=0;
                dec = (ConvertToDecimalFromBase(fromBase,number));
                sysnum = ConvertToBaseFromDecimal(toBase,dec); 
            }
            return sysnum;
        }
    }
}