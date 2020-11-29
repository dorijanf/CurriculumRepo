using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.KeywordRepository
{
    class KeywordRepository : IKeywordRepository
    {
        private readonly CurriculumDatabaseContext curriculumDatabaseContext;

        public KeywordRepository(CurriculumDatabaseContext curriculumDatabaseContext)
        {
            this.curriculumDatabaseContext = curriculumDatabaseContext;
        }

        public IEnumerable<Keyword> GetAllKeywords
        {
            get
            {
                return curriculumDatabaseContext.Keyword;
            }
        }

        public async Task CreateKeywords(List<string> keywords, int lsId)
        {
            Keyword kwrd = null;
            foreach (var keyword in keywords)
            {
                if (null != (kwrd = curriculumDatabaseContext.Keyword.FirstOrDefault(x => x.KeywordName == keyword)))
                {
                }
                else
                {
                    kwrd = new Keyword
                    {
                        KeywordName = keyword
                    };
                }
                curriculumDatabaseContext.Keyword.Add(kwrd);
                await CreateLsKeyword(kwrd.Idkeyword, lsId);
            }
            await curriculumDatabaseContext.SaveChangesAsync();
        }

        private async Task CreateLsKeyword(int keywordId, int lsId)
        {
            var lsKeyword = new Lskeyword
            {
                Keywordid = keywordId,
                Lsid = lsId
            };
            curriculumDatabaseContext.Lskeyword.Add(lsKeyword);
            await curriculumDatabaseContext.SaveChangesAsync();
        }
    }
}
