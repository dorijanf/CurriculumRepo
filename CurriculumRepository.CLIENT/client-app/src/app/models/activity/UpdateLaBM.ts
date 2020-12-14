import { TimeSpan } from 'src/app/helpers/timespan';
import { StrategyMethod } from '../StrategyMethod';
import { TeachingAid } from '../TeachingAid';

export class UpdateLaBM {
    OrdinalNumber: number; 
    iPerformanceId: number;
    LatypeId: number;
    DigitalTechnology: boolean; 
    Laduration: TimeSpan;
    Ladescription: string; 
    StrategyMethods: StrategyMethod[]; 
    CooperationId: number;
    LaTeachingAidUser: TeachingAid[];
    LaTeachingAidTeacher: TeachingAid[];
}