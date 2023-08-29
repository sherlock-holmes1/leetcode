using System.Net.Http.Headers;

public class Solution {
    bool cycleDetected = false;
    public bool CanFinish(int numCourses, int[][] prerequisites) {

        Dictionary<int, List<int>> graph = new();

        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (!graph.ContainsKey(prerequisites[i][1]))
            {
                graph[prerequisites[i][1]] = new List<int>();
            }

            graph[prerequisites[i][1]].Add(prerequisites[i][0]); 
        }

        bool[] visited = new bool[numCourses];
        bool[] stack = new bool[numCourses];

        for (int j = 0; j < numCourses; j++)
        {
            if (!graph.ContainsKey(j))
            {
                continue;
            }

            if (LookForCycles(graph, j, ref visited, ref stack))
            {
                break;
            }
        }

        return !this.cycleDetected;
    }

    private bool LookForCycles(Dictionary<int, List<int>> graph, int elem, ref bool[] visited, ref bool[] stack)
    {
        if (this.cycleDetected)
        {
            return true;
        }

        if (stack[elem])
        {
            this.cycleDetected = true;
            return true;
        }
        
        if (visited[elem])
        {
            return false;
        }

        stack[elem] = true;

        if (graph.ContainsKey(elem))
        {
            foreach (var next in graph[elem])
            {
                if (LookForCycles(graph, next, ref visited, ref stack))
                {
                    this.cycleDetected = true;
                    return true;
                }
            }
        }

        visited[elem] = true;
        stack[elem] = false;

        return false;
    }
}