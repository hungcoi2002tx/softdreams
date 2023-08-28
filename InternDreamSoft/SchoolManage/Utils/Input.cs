using SchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolManager.Utils
{
    class Input
    {
        private Input() { }
        public static Student StudentId(String mess, List<Student> list)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    result = IntegerInRange(mess, 0, Int32.MaxValue);
                    foreach (Student c in list)
                    {
                        if (result == c.Id)
                        {
                            return c;
                        }
                    }
                    throw new Exception();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Not id is matched");
                }
            }
            return null;
        }
        public static Class ClassID(String mess, List<Class> list)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    result = IntegerInRange(mess, 0, Int32.MaxValue);
                    foreach (Class c in list)
                    {
                        if(result == c.Id)
                        {
                            return c;
                        }
                    }                     
                    throw new Exception();

                }catch(Exception e) 
                {
                    Console.WriteLine("Not id is matched");
                }
            }
            return null;
        }

        public static DateTime Date(String mess)
        {
            Boolean check = true;
            String result = "";
            while (check)
            {
                try
                {
                    result = StringNotBlank(mess);
                    result.Trim();
                    if(Regex.Match(result, "^(0?[1-9]|[12][0-9]|3[01])[\\/\\-](0?[1-9]|1[012])[\\/\\-]\\d{4}$").Success )
                    {
                        
                        DateTime date = DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if (date > DateTime.Now)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            check = false;
                            return date;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input is not true. Please try again !");
                }
            }
            return DateTime.Now;
        }
        public static String StringNotBlank(String mess)
        {
            Boolean check = true;
            String result = "";
            while (check)
            {
                try
                {
                    Console.WriteLine(mess);
                    result = Console.ReadLine();
                    if (result == null || result.Equals(""))
                    {
                        throw new Exception();
                    }
                    check = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input must be not blank. Please try again !");
                }
            }
            return result;
        }
        public static int Integer(String mess)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    Console.WriteLine(mess);
                    result = Convert.ToInt32(Console.ReadLine());
                    check = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input is not valid. Please try again !");
                }
            }
            return result;
        }

        public static int IntegerInRange(String mess, int min, int max)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                result = Integer(mess);
                if(result >= min && result <= max)
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine($"Your input is not in range {min} to {max}");
                }
            }

            return result;

        }
    }
}
