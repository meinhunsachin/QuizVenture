﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizVenture.Data
{
    internal class Quiz
    {
        public class Question
        {
            public string question { get; set; }
            public string category { get; set; }
            public List<string> options { get; set; }
            public string answer { get; set; }
        }
    }
}
