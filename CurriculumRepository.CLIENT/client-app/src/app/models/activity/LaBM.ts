import { StrategyMethodBM } from '../StrategyMethodBM';
import { TeachingAid } from '../TeachingAid';

export class LaBM {
    OrdinalNumber: number;
    PerformanceId: number;
    LatypeId: number;
    DigitalTechnology: boolean;
    Laname: string;
    LadurationMinute: number;
    Ladescription: string;
    StrategyMethods: StrategyMethodBM[];
    CooperationId: number;
    LaTeachingAidUser: TeachingAid[];
    LaTeachingAidTeacher: TeachingAid[];
}