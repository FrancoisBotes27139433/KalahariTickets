import { Tickets } from './tickets';

export interface Client {
    id: any;
    username: any;
    phone: any;
    email: any;
    dateAdded: Date;
    address: any;
    tickets?: Tickets[];
}
