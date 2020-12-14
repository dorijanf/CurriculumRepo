import { outcome } from './outcome';

export class Ls {
    Lsname: string;
    Lsdescription: string;
    LsTypeId: number = 2;
    TeachingSubjectId: number = 0;
    Lsgrade: number = 0;
    LearningOutcomeCts: outcome[] = [];
    LearningOutcomeSubjects: outcome[] = [];
    Keywords: string[];
    CorrelationSubjectIds: number[];
}