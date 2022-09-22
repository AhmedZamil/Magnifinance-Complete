import { ISubject } from "./Subject";
import { ITeacher } from "./Teacher";

export class ITeacherSubject {
    subjectTeacherId: number;
    note: string;
    teacherId: number;
    subjectId: number;
    teacher: ITeacher[];
    subject: ISubject[]
}