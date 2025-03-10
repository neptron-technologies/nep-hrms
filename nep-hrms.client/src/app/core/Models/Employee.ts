export class Employee {
    id: number;
    employeeCode: string;
    employeeFirstName: string;
    employeeLastName: string;
    dob: string; // Format: YYYY-MM-DD
    gender: string;
    doj: string; // Format: YYYY-MM-DD//
    bloodGroup: string;
    designation: string;//
    grade: string;//
    active: string;
    email: string;
    contractor: string;
    address: string;
    city: string;
    state: string;
    country: string;
    pinCode: string;
    tel: string;
    jobTitle: string;
    startDate: Date;
    endDate: Date;
    jobLocation: string;
    salary: string;
    skills: string;
    // Constructor to initialize values (optional)
    constructor(
        id: number,
        employeeCode: string,
        employeeFirstName: string,
        employeeLastName: string,
        dob: string,
        gender: string,
        doj: string,
        bloodGroup: string,
        designation: string,
        grade: string,
        active: string,
        email: string,
        contractor: string,
        address: string,
        city: string,
        state: string,
        country: string,
        pinCode: string,
        tel: string,
        jobTitle: string,
        startDate: Date,
        endDate: Date,
        jobLocation: string,
        salary: string,
        skills: string
    ) {
        this.id = id;
        this.employeeCode = employeeCode;
        this.employeeFirstName = employeeFirstName;
        this.employeeLastName = employeeLastName;
        this.dob = dob;
        this.gender = gender;
        this.doj = doj;
        this.bloodGroup = bloodGroup;
        this.designation = designation;
        this.grade = grade;
        this.active = active;
        this.email = email;
        this.contractor= contractor;
        this.address = address;
        this.city = city;
        this.state = state;
        this.country = country;
        this.pinCode = pinCode;
        this.tel = tel;
        this.jobTitle = jobTitle;
        this.startDate = startDate;
        this.endDate = endDate;
        this.jobLocation = jobLocation;
        this.salary = salary;
        this.skills = skills;
    }
}

