using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Helpers.Sort
{
    public interface ISort<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities,
                                string orderBy);
    }
}
