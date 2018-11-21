export class EmployeeInfoDto {
    id!: number;
    name?: string | undefined;
    email?: string | undefined;
    salary!: number;
    hired!: Date;
    departmentId!: number;
    departmentName?: string | undefined;

    constructor(data?: EmployeeInfoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.email = data["email"];
            this.salary = data["salary"];
            this.hired = data["hired"] ? new Date(data["hired"].toString()) : <any>undefined;
            this.departmentId = data["departmentId"];
            this.departmentName = data["departmentName"];
        }
    }

    static fromJS(data: any): EmployeeInfoDto {
        data = typeof data === 'object' ? data : {};
        let result = new EmployeeInfoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["email"] = this.email;
        data["salary"] = this.salary;
        data["hired"] = this.hired ? this.hired.toISOString() : <any>undefined;
        data["departmentId"] = this.departmentId;
        data["departmentName"] = this.departmentName;
        return data;
    }
}

export class AllEmployeesDto {
    allEmployees!: number;
    employees?: EmployeeInfoDto[] | undefined;

    constructor(data?: AllEmployeesDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.allEmployees = data["allEmployees"];
            if (data["employees"] && data["employees"].constructor === Array) {
                this.employees = [];
                for (let item of data["employees"])
                    this.employees.push(EmployeeInfoDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): AllEmployeesDto {
        data = typeof data === 'object' ? data : {};
        let result = new AllEmployeesDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["allEmployees"] = this.allEmployees;
        if (this.employees && this.employees.constructor === Array) {
            data["employees"] = [];
            for (let item of this.employees)
                data["employees"].push(item.toJSON());
        }
        return data;
    }
}

export class GetAllEmployeesQuery {
    page!: number;
    rowsOnPage!: number;
    departmentId!: number;
    nameFilter?: string | undefined;
    emailFilter?: string | undefined;
    salaryFilter!: number;
    hiredFilter!: Date;

    constructor(data?: GetAllEmployeesQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.page = data["page"];
            this.rowsOnPage = data["rowsOnPage"];
            this.departmentId = data["departmentId"];
            this.nameFilter = data["nameFilter"];
            this.emailFilter = data["emailFilter"];
            this.salaryFilter = data["salaryFilter"];
            this.hiredFilter = data["hiredFilter"] ? new Date(data["hiredFilter"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): GetAllEmployeesQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetAllEmployeesQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["page"] = this.page;
        data["rowsOnPage"] = this.rowsOnPage;
        data["departmentId"] = this.departmentId;
        data["nameFilter"] = this.nameFilter;
        data["emailFilter"] = this.emailFilter;
        data["salaryFilter"] = this.salaryFilter;
        data["hiredFilter"] = this.hiredFilter ? this.hiredFilter.toISOString() : <any>undefined;
        return data;
    }
}

export class AddEmployeeCommand {
    name?: string | undefined;
    email?: string | undefined;
    salary!: number;
    hired!: Date;
    departmentId!: number;

    constructor(data?: AddEmployeeCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.name = data["name"];
            this.email = data["email"];
            this.salary = data["salary"];
            this.hired = data["hired"] ? new Date(data["hired"].toString()) : <any>undefined;
            this.departmentId = data["departmentId"];
        }
    }

    static fromJS(data: any): AddEmployeeCommand {
        data = typeof data === 'object' ? data : {};
        let result = new AddEmployeeCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["email"] = this.email;
        data["salary"] = this.salary;
        data["hired"] = this.hired ? this.hired.toISOString() : <any>undefined;
        data["departmentId"] = this.departmentId;
        return data;
    }
}

export class UpdateEmployeeCommand {
    id!: number;
    name?: string | undefined;
    email?: string | undefined;
    salary!: number;
    hired!: Date;
    departmentId!: number;

    constructor(data?: UpdateEmployeeCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.email = data["email"];
            this.salary = data["salary"];
            this.hired = data["hired"] ? new Date(data["hired"].toString()) : <any>undefined;
            this.departmentId = data["departmentId"];
        }
    }

    static fromJS(data: any): UpdateEmployeeCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateEmployeeCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["email"] = this.email;
        data["salary"] = this.salary;
        data["hired"] = this.hired ? this.hired.toISOString() : <any>undefined;
        data["departmentId"] = this.departmentId;
        return data;
    }
}
