import { TimeSpan } from 'src/app/helpers/timespan';
import { LaDTO } from '../activity/LaDTO';
import { StrategyMethodBM } from '../StrategyMethodBM';
import { TeachingAid } from '../TeachingAid';

export class LsDTO {
    UserId: string;
    Firstname: string;
    Lastname: string;
    Lsname: string;
    Lsdescription: string;
    LstypeName: string;
    TeachingSubjectName: string;
    Lsgrade: number;
    LearningOutcomeSubjects: string;
    LearningOutcomeCts: string;
    CorrelationInterdisciplinaritySubjects: string[];
    Lsduration: TimeSpan;
    StrategyMethods: StrategyMethodBM[];
    CollaborationNames: string[];
    TeachingAids: TeachingAid[];
    Las: LaDTO[];
}