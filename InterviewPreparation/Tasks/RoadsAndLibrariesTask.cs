using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Tasks
{
    /*
    Нужно посчитать минимум стоимости между двумя вариантами:
    1) Каждому городу по церкви
    2) Посчитать кол-во всех компонент связности, для каждой компоненты связности по 1 церкви.
    Просуммировать стоимость постройки дорог для всех компонент связности.
    */
    public class RoadsAndLibrariesTask
    {
        public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            var churchCostForEveryCity = c_lib * n;
            var graph = new Graph(n, cities);
            var roadsCountInEveryConnectedComponent = graph.CountRoadsCountInEveryConnectedComponent();
            var costForAllComponents = roadsCountInEveryConnectedComponent.Sum() * c_road + roadsCountInEveryConnectedComponent.Count * c_lib;
            return Math.Min(churchCostForEveryCity, costForAllComponents);
        }

        class Graph
        {
            public readonly City[] Cities;

            public Graph(int n, int[][] cities)
            {
                Cities = new City[n];
                for (var i = 0; i < n; i++)
                    Cities[i] = new City(i);
                foreach (var edge in cities)
                {
                    var first = edge[0] - 1;
                    var second = edge[1] - 1;
                    Cities[first].Connect(Cities[second]);
                }
            }

            public List<int> CountRoadsCountInEveryConnectedComponent()
            {
                var visited = new HashSet<int>();
                var roadsCountInComponent = new List<int>();
                while (true)
                {
                    var notVisited = Cities.FirstOrDefault(c => !visited.Contains(c.Number));
                    if (notVisited == null)
                        break;

                    var connectedCitiesNumbers = GetConnectedCitiesNumbers(notVisited.Number);
                    foreach (var connectedCitiesNumber in connectedCitiesNumbers)
                    {
                        visited.Add(connectedCitiesNumber);
                    }
                    roadsCountInComponent.Add(connectedCitiesNumbers.Count - 1);
                }

                return roadsCountInComponent;
            }

            public HashSet<int> GetConnectedCitiesNumbers(int source)
            {
                var visited = new HashSet<int>();
                var queue = new Queue<int>();
                queue.Enqueue(source);
                while (queue.Count > 0)
                {
                    var cityNumber = queue.Dequeue();
                    if (visited.Contains(cityNumber))
                        continue;
                    visited.Add(cityNumber);
                    var city = Cities[cityNumber];
                    foreach (var incCity in city.IncidentCities)
                    {
                        if (visited.Contains(incCity.Number))
                            continue;
                        queue.Enqueue(incCity.Number);
                    }
                }

                return visited;
            }
        }

        class City
        {
            public int Number;
            public List<City> IncidentCities = new List<City>();

            public City(int number)
            {
                Number = number;
            }

            public void Connect(City city)
            {
                IncidentCities.Add(city);
                city.IncidentCities.Add(this);
            }
        }
    }
}
