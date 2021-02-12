using System;
using System.Collections.Generic;
using System.Linq;

public class Solution1
{
    //public static void Main()
    //{
    //    var n = int.Parse(Console.ReadLine());
    //    if (n <= 0)
    //    {
    //        Console.WriteLine(-1);
    //        return;
    //    }

    //    var graph = new Graph(n);
    //    for (var i = 0; i < n; i++)
    //    {
    //        var coords = Console.ReadLine().Split().Select(int.Parse).ToArray();
    //        var city = new City(i, coords);
    //        graph[i] = city;
    //    }
    //    var k = int.Parse(Console.ReadLine());
    //    for (var i = 0; i < n; i++)
    //    {
    //        for (var j = i + 1; j < n; j++)
    //        {
    //            if (graph[j].IsConnected(graph[i], k))
    //                graph[j].Connect(graph[i]);
    //        }
    //    }

    //    var cds = Console.ReadLine().Split().Select(int.Parse).ToArray();

    //    Solve1(graph, cds[0] - 1, cds[1] - 1, k);
    //}

    public static void Solve1(Graph graph, int from, int to, int limit)
    {
        if (from == to)
        {
            Console.WriteLine(0);
            return;
        }

        var visitedFrom = new Dictionary<int, int>();
        var queue = new Queue<int>();
        queue.Enqueue(from);
        while (queue.Count > 0)
        {
            var cityNumber = queue.Dequeue();
            if (cityNumber == to)
                break;
            var city = graph[cityNumber];
            foreach (var c in city.ConnectedCities)
            {
                if (!visitedFrom.ContainsKey(c.Number))
                {
                    visitedFrom[c.Number] = cityNumber;
                    queue.Enqueue(c.Number);
                }
            }
        }

        if (!visitedFrom.ContainsKey(to))
        {
            Console.WriteLine(-1);
            return;
        }

        var pathLength = 0;
        var cur = to;
        while (cur != from)
        {
            cur = visitedFrom[cur];
            pathLength++;
        }
        Console.WriteLine(pathLength);
    }
}

public class City
{
    public int Number;
    public int X;
    public int Y;
    public List<City> ConnectedCities;

    public City(int number, int[] coords)
    {
        Number = number;
        X = coords[0];
        Y = coords[1];
        ConnectedCities = new List<City>();
    }

    public void Connect(City another)
    {
        ConnectedCities.Add(another);
        another.ConnectedCities.Add(this);
    }

    public bool IsConnected(City another, int limit)
    {
        return Math.Abs(this.X - another.X) + Math.Abs(this.Y - another.Y) <= limit;
    }
}

public class Graph
{
    public City[] Cities;

    public City this[int key]
    {
        get { return Cities[key]; }
        set { Cities[key] = value; }
    }
    public Graph(int n)
    {
        Cities = new City[n];
    }
}