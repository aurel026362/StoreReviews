export class UserModel {
    id: number;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    email: string;

    constructor(id:number, firstName: string, lastName: string, dateOfBirth: Date, email: string){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.email =email;

    }
}