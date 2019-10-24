export interface Tickets {
    id: number;
    title: string;
    description: string;
    isUrgent: boolean;
    notes: string;
    dateIssued: Date;
    dateClosed: Date;
    open: boolean;
    clientId: number;
}
