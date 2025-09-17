/* Assignment 4.3.1
Write a program in C# Sharp to calculate and print the Electricity bill of a given customer. 
The customer id., name and unit consumed by the user should be taken from the keyboard and display the total amount to pay to the customer. 

The formula for calculating the total amount to pay in the electricity bill is as follows:

Unit -> Charge/unit
upto 199 -> @1.20
200 and above but less than 400 -> @1.50
400 and above but less than 600 -> @1.80
600 and above -> @2.00
If bill exceeds $ 400 then a surcharge of 15% will be charged.

As the number of units used the cost increases as per the above slab. 

Test Data :
1001
James
800
Expected Output :
Customer IDNO :1001
Customer Name :James
unit Consumed :800
Amount Charges @$ 2.00 per unit : 1600.00
Surcharge Amount : 240.00
Net Amount Paid By the Customer : 1840.00
*/
public class Program
{
    public static void Main(string[] args)
    {
        // variables declaration
        double units, charges = 0, surcharge = 0, netAmount = 0;

        // maximum charges for each tier
        const double firstTierMax = 199 * 1.20;
        const double secondTierMax = 199 * 1.50;
        const double thirdTierMax = 199 * 1.80;

        // Input customer details
        Console.Write("Input Customer ID : ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input Customer Name : ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Write("Input the units consumed : ");
        units = Convert.ToDouble(Console.ReadLine());

        if (units < 200 && units >= 0) // upto 199 units
        {
            charges = units * 1.20;
        }
        else if (units >= 200 && units < 400) // 200 to 399 units
        {
            charges = firstTierMax + ((units - 199) * 1.50);
        }
        else if (units >= 400 && units < 600) // 400 to 599 units
        {
            charges = firstTierMax + secondTierMax + ((units - 399) * 1.80);
        }
        else if (units >= 600) // 600 and above units
        {
            charges = firstTierMax + secondTierMax + thirdTierMax + ((units - 599) * 2.00);
        }
        // Calculate surcharge if applicable
        if (charges > 400)
        {
            surcharge = charges * 0.15;
        }

        netAmount = charges + surcharge;

        Console.WriteLine("Customer IDNO :{0}", id);
        Console.WriteLine("Customer Name :{0}", name);
        Console.WriteLine("Units Consumed :{0}", units);
        Console.WriteLine("Surcharge Amount : {0:F2}", surcharge);
        Console.WriteLine("Net Amount Paid By the Customer : {0:F2}", netAmount);
    }
}