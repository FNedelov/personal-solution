using System;

namespace CustomUsing
{
    class CustomUsing
    {
        static void Main(string[] args)
        {
            try
            {
                using (CustomObject cObj = new CustomObject(2, "Word"))
                {
                    Console.WriteLine($"Number: {cObj.Num}, Text: {cObj.Text}");
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}