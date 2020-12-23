﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class TypeRepository : ITypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public TypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Type> AllTypes => _appDbContext.Types;
    }
}
