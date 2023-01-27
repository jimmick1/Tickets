
using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] data = Console.ReadLine().Split(' ').ToArray();
        switch (data[0])
        {
            case "viewer":
                Visitor vis = new Visitor();
                vis.AlreadyVisits = Convert.ToInt32(data[1]);
                vis.TicketCost = Convert.ToInt32(data[2]);
                vis.Qty = Convert.ToInt32(data[3]);
                Console.WriteLine(vis.TotalCostWithSale());
                break;
            case "regular":
                var regular = new Regular();
                regular.AlreadyVisits = Convert.ToInt32(data[1]);
                regular.TicketCost = Convert.ToInt32(data[2]);
                regular.Qty = Convert.ToInt32(data[3]);
                Console.WriteLine(regular.TotalCostWithSale());
                break;
            case "student":
                var student = new Student();
                student.AlreadyVisits = Convert.ToInt32(data[1]);
                student.TicketCost = Convert.ToInt32(data[2]);
                student.Qty = Convert.ToInt32(data[3]);
                Console.WriteLine(student.TotalCostWithSale());
                break;
            case "pensioner":
                var pensioner = new Pensioner();
                pensioner.AlreadyVisits = Convert.ToInt32(data[1]);
                pensioner.TicketCost = Convert.ToInt32(data[2]);
                pensioner.Qty = Convert.ToInt32(data[3]);
                Console.WriteLine(pensioner.TotalCostWithSale());
                break;
            default:
                Console.WriteLine("Введи нормально");
                break;
        }

    }
}

public class Visitor
{
    public virtual int AlreadyVisits { get; set; }
    public int TicketCost { get; set; }
    public int Qty { get; set; }
    
    public int TotalCostWithSale()
    {
        return TicketCost * Qty;
    }
}

public class Regular : Visitor
{
    public new double TotalCostWithSale()
    {
        double cost = 0.0;
        for (int i = 0; i < Qty; i++)
        {
            AlreadyVisits++;
            int flag = AlreadyVisits / 10;
            if (flag > 20)
            {
                flag = 20;
            }
            double sale = Convert.ToDouble((100.0 - flag) / 100.0);
            cost += sale * TicketCost;
        }
        return Math.Round(cost, 2);
    }
}

public class Student : Visitor
{
    public new double TotalCostWithSale()
    {
        double cost = 0.0;
        for (int i = 0; i < Qty; i++)
        {
            AlreadyVisits++;
            int flag = AlreadyVisits % 3;
            if (flag == 0)
            {
                cost += 0.5 * TicketCost;
            }
            else
            {
                cost += TicketCost;
            }            
        }
        return Math.Round(cost, 2);
    }
}

public class Pensioner : Visitor
{
    public new double TotalCostWithSale()
    {
        double cost = 0.0;
        for (int i = 0; i < Qty; i++)
        {
            AlreadyVisits++;
            int flag = AlreadyVisits % 5;
            if (flag == 0)
            {
                continue;
            }
            else
            {
                cost += 0.5*TicketCost;
            }
        }
        return Math.Round(cost, 2);
    }
}