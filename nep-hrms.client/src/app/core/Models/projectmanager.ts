export class Projectmanager {
    id: number = 0;
    projectName: string = '';
    name: string = '';  // ✅ Ensure 'name' is included
    description: string = '';
    startDate: string = '';
    endDate: string = '';
    status: string = '';
    empId: number = 0;  // ✅ Optional employee ID
    fname!: string;  // ✅ Optional first name
    createdBy: string = ''; // ✅ Ensure compatibility with API response
}
