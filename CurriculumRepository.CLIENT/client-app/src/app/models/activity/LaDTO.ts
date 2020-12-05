import { Byte } from '@angular/compiler/src/util';
import { TimeSpan } from 'src/app/helpers/timespan';
import { Lacollaboration } from '../Lacollaboration';
import { StrategyMethodBM } from '../StrategyMethodBM';
import { TeachingAidBM } from '../TeachingAidBM';

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
    LateachingAids: TeachingAidBM[];
    Laacknowledgment: string;
}