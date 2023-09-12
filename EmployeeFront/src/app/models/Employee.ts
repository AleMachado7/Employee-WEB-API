export interface Employee {
    id? : string;
    name: string;
    surname: string;
    department: string;
    active: boolean;
    workShift: string;
    creationDate? : string;
    updateDate? : string;
}