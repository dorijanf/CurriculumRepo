import { TimeSpan } from '../../helpers/timespan';
import { LaDTO } from '../activity/LaDTO';
import { StrategyMethod } from '../StrategyMethod';
import { TeachingAid } from '../TeachingAid';

export class LsDTO {
    UserId: number;
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
    StrategyMethods: StrategyMethod[];
    CollaborationNames: string[];
    TeachingAids: TeachingAid[];
    Las: LaDTO[];
}