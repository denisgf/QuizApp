﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Statement { get; set; }
        public Question Question { get; set; }
        public Boolean IsCorrectAnswer { get; set; }
    }
}
