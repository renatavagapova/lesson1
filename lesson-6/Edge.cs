﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_6
{
    class Edge
    {
        public Vertex From { get; set; }

        public Vertex To { get; set; }

        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From};{To})";
        }
    }
}
