import { Tickets } from './tickets';

export interface Client {
    id: number;
    username: string;
    phoneNumber: number;
    email: string;
    dateAdded: Date;
    address: string;
    tickets: Tickets[];
}
