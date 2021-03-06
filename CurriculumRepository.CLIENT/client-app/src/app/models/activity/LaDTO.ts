import { Byte } from '@angular/compiler/src/util';
import { TimeSpan } from 'src/app/helpers/timespan';
import { StrategyMethodBM } from '../StrategyMethodBM';
import { TeachingAid } from '../TeachingAid';

export class LaDTO {
    Idla: number;
    OrdinalNumber: number;
    Laperformance: string;
    Latype: string;
    DigitalTechnology: boolean;
    Laname: string;
    Laduration: TimeSpan;
    Ladescription: string;
    LastrategyMethod: StrategyMethodBM[];
    Lacollaboration: string;
    Lagrade: Byte;
    LateachingAids: TeachingAid[];
    Laacknowledgment: string;
}