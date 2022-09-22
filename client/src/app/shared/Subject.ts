import { ICourse } from "./Course";
import { ISubjectGrade } from "./SubjectGrade";
import { ITeacher } from "./Teacher";

export class ISubject {
    subjectId: number;
    subjectName: string;
    subjectTitle: string;
    isMajor: boolean;
    courseId: number;
    subjectGrade: ISubjectGrade[];
    course: ICourse;
    teacherId: number;
    subjectTeacher: ITeacher;
    totalStudents: number;

}