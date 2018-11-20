import { User } from "./User";

export class Project {
    public ProjectId: number;
    public ProjectName: string;
    public ClientName: string;
    public TeamLeaderId: number;
    public DevelopersHours: number;
    public QaHours: number;
    public UiUxHours: number;
    public StartDate: Date;
    public FinishDate: Date;
    public User: User;

        constructor(){}
        
    }




