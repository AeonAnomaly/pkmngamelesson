﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class element
    {
        public enum elements { normal, fight, flying, poison, ground, rock, bug, ghost, steel, fire, water, grass, electric, psychic, ice, dragon, dark, fairy};
        public enum statusconditions { normal, poison, burn };
        public float[,] elementGrid = new float[18, 18]
        {
            { 1, 1, 1, 1, 1, 0.5f, 1, 0, 0.5f, 1, 1, 1, 1, 1, 1, 1, 1, 1 } ,
            { 2, 1, 0.5f, 0.5f, 1, 2, 0.5f, 0, 2, 1, 1, 1, 1, 0.5f, 2, 1, 2, 0.5f },
            { 1, 2, 1, 1, 1, 0.5f, 2, 1, 0.5f, 1, 1, 2, 0.5f, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0.5f, 0.5f, 0.5f, 1, 0.5f, 0, 1, 1, 2, 1, 1, 1, 1, 1, 2 },
            { 1, 1, 0, 2, 1, 2, 0.5f, 1, 2, 2, 1, 0.5f, 2, 1, 1, 1, 1, 1 },
            { 1, 0.5f, 2, 1, 0.5f, 1, 2, 1, 0.5f, 2, 1, 1, 1, 1, 2, 1, 1, 1 },
            { 1, 0.5f, 0.5f, 0.5f, 1, 1, 1, 0.5f, 0.5f, 0.5f, 1, 2, 1, 2, 1, 1, 2, 0.5f },
            { 0, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0.5f, 1 },
            { 1, 1, 1, 1, 1, 2, 1, 1, 0.5f, 0.5f, 0.5f, 1, 0.5f, 1, 2, 1, 1, 2 },
            { 1, 1, 1, 1, 1, 0.5f, 2, 1, 2, 0.5f, 0.5f, 2, 1, 1, 2, 0.5f, 1, 1 },
            { 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 0.5f, 0.5f, 1, 1, 1, 0.5f, 1, 1 },
            { 1, 1, 0.5f, 0.5f, 2, 2, 0.5f, 1, 0.5f, 0.5f, 2, 0.5f, 1, 1, 1, 0.5f, 1, 1 },
            { 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 2, 0.5f, 0.5f, 1, 1, 0.5f, 1, 1 },
            { 1, 2, 1, 2, 1, 1, 1, 1, 0.5f, 1, 1, 1, 1, 0.5f, 1, 1, 0, 1 },
            { 1, 1, 2, 1, 2, 1, 1, 1, 0.5f, 0.5f, 0.5f, 2, 1, 1, 0.5f, 2, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 0.5f, 1, 1, 1, 1, 1, 1, 2, 1, 0 },
            { 1, 0.5f, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0.5f, 0.5f },
            { 1, 2, 1, 0.5f, 1, 1, 1, 1, 0.5f, 0.5f, 1, 1, 1, 1, 1, 2, 2, 1 },

        };
    }
}
