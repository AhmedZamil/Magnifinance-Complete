import { ITeacherSubject } from "./TeacherSubject";

export class ITeacher {
    teacherId: number;
    firstName: string;
    lastName: string;
    age: number;
    isActive: boolean;
    teacherSubjects: ITeacherSubject[]
}