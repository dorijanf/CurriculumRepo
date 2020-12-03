using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.KeywordRepository
{
    class KeywordRepository : IKeywordRepository
    {
        private readonly CurriculumDatabaseContext context;

        public KeywordRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Keyword>> GetAllKeywords()
        {
            return await context.Keyword.ToListAsync();
        }

        public async Task CreateKeywords(List<string> keywords, int lsId)
        {
            Keyword kwrd = null;
            foreach (var keyword in keywords)
            {
                if (null != (kwrd = context.Keyword.FirstOrDefault(x => x.KeywordName == keyword)))
                {
                }
                else
                {
                    kwrd = new Keyword
                    {
                        KeywordName = keyword
                    };
                    context.Keyword.Add(kwrd);
                    await context.SaveChangesAsync();
                }
                await CreateLsKeyword(kwrd.Idkeyword, lsId);
            }
        }

        private async Task CreateLsKeyword(int keywordId, int lsId)
        {
            var lsKeywordExists = context.Lskeyword.Where(x => x.Keywordid == keywordId && x.Lsid == lsId);

            if (lsKeywordExists != null)
            {
                var lsKeyword = new Lskeyword
                {
                    Keywordid = keywordId,
                    Lsid = lsId
                };
                context.Lskeyword.Add(lsKeyword);
                await context.SaveChangesAsync();
            }
        }

        public void RemoveKeywords(List<string> keywords, int lsId)
        {
            var lsKeywords = context.Lskeyword.Where(x => x.Idlskeyword == lsId);
            context.RemoveRange(lsKeywords);
            context.SaveChanges();
        }

        public Keyword GetKeyword(string name)
        {
            return context.Keyword.FirstOrDefault(x => x.KeywordName == name);
        }
    }
}
