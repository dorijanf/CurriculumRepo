using CurriculumRepository.API.Helpers;

namespace CurriculumRepository.API.Extensions.Parameters
{
    public class ScenarioParameters : QueryStringParameters
    {
        public ScenarioParameters()
        {
            OrderBy = "Lsname";
        }
        public int? Lsgrade { get; set; }
        public int TeachingSubjectId { get; set; }
        public string Lsname { get; set; }
        public string Keyword { get; set; }
    }
}
