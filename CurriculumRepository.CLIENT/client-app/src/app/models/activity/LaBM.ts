import { TimeSpan } from 'src/app/helpers/timespan';
import { TeachingAidBM } from '../TeachingAidBM';

export class LaBM {
    OrdinalNumber: number;
    PerformanceId: number;
    LatypeId: number;
    DigitalTechnology: boolean;
    Laname: string;
    Laduration: TimeSpan;
    Ladescription: string;
    StrategyMethods: string;
    CooperationId: number;
    LaTeachingAidUser: TeachingAidBM[];
    LaTeachingAidTeacher: TeachingAidBM[];
}