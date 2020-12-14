using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.KeywordRepository
{
    public interface IKeywordRepository
    {
        Task<IEnumerable<Keyword>> GetAllKeywords();
        Task CreateKeywords(List<string> keywords, int lsId);
        Task RemoveKeywords(List<string> keywords, int lsId);
        Keyword GetKeyword(string name);
    }
}
