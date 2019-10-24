import { Tickets } from './tickets';

export interface Technition {
    id: number;
    firstName: string; 
    lastName: string; 
    monthlySalary: string;
    age: string;
    tickets: Tickets[];
}
