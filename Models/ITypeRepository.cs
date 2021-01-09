using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface ITypeRepository
    {
        IEnumerable<Type> AllTypes { get; }
        Type GetTypeById(int id);
        Type GetTypeByName(string typeName);
    }
}
