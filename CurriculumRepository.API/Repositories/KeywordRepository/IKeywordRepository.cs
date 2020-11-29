using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.KeywordRepository
{
    public interface IKeywordRepository
    {
        IEnumerable<Keyword> GetAllKeywords { get; }
        Task CreateKeywords(List<string> keywords, int lsId);
    }
}
