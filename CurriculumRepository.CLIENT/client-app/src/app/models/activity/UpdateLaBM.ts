import { TimeSpan } from 'src/app/helpers/timespan';
import { StrategyMethodBM } from '../StrategyMethodBM';
import { TeachingAidBM } from '../TeachingAidBM';

export class UpdateLaBM {
    OrdinalNumber: number; 
    iPerformanceId: number;
    LatypeId: number;
    DigitalTechnology: boolean; 
    Laduration: TimeSpan;
    Ladescription: string; 
    StrategyMethods: StrategyMethodBM[]; 
    CooperationId: number;
    LaTeachingAidUser: TeachingAidBM[];
    LaTeachingAidTeacher: TeachingAidBM[];
}