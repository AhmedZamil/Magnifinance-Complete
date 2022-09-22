import { IStudent } from "./Student";
import { ISubject } from "./Subject";

export class ISubjectGrade {
    subjectGradeId: number;
    studentId: number;
    student: IStudent;
    grade: string;
    gradePoint: number;
    subjectId: number;
    subject: ISubject
}