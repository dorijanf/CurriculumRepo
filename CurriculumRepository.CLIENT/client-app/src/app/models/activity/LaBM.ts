import { TimeSpan } from 'src/app/helpers/timespan';
import { TeachingAid } from '../TeachingAid';

export class LaBM {
    OrdinalNumber: number;
    PerformanceId: number;
    LatypeId: number;
    DigitalTechnology: boolean;
    Laname: string;
    Laduration: TimeSpan;
    LadurationMinute: number;
    Ladescription: string;
    StrategyMethods: string;
    CooperationId: number;
    LaTeachingAidUser: TeachingAid[];
    LaTeachingAidTeacher: TeachingAid[];
}