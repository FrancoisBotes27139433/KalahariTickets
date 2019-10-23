export interface Tickets {
    id: number;
    title: string;
    description: string;
    isUrgent: boolean;
    notes: string;
    dateIssue: Date;
    dateClosed: Date;
    open: boolean;
    clientId: number;
}
