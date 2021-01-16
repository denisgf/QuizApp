using System;
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

        public Type GetTypeById(int id)
        {
            return _appDbContext.Types.FirstOrDefault(t => t.TypeId == id);
        }

        public Type GetTypeByName(string typeDescription)
        {
            return _appDbContext.Types.FirstOrDefault(t => t.Description.Equals(typeDescription));
        }
    }
}
