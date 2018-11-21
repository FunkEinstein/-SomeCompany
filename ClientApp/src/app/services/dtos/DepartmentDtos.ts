export class DepartmentInfoDto {
    id!: number;
    departmentName?: string | undefined;

    constructor(data?: DepartmentInfoDto) {
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
            this.departmentName = data["departmentName"];
        }
    }

    static fromJS(data: any): DepartmentInfoDto {
        data = typeof data === 'object' ? data : {};
        let result = new DepartmentInfoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["departmentName"] = this.departmentName;
        return data;
    }
}

export class AllDepartmentsDto {
    allDepartments!: number;
    departments?: DepartmentInfoDto[] | undefined;

    constructor(data?: AllDepartmentsDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.allDepartments = data["allDepartments"];
            if (data["departments"] && data["departments"].constructor === Array) {
                this.departments = [];
                for (let item of data["departments"])
                    this.departments.push(DepartmentInfoDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): AllDepartmentsDto {
        data = typeof data === 'object' ? data : {};
        let result = new AllDepartmentsDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["allDepartments"] = this.allDepartments;
        if (this.departments && this.departments.constructor === Array) {
            data["departments"] = [];
            for (let item of this.departments)
                data["departments"].push(item.toJSON());
        }
        return data;
    }
}

export class GetAllDepartmentsQuery {
    page!: number;
    rowsOnPage!: number;
    nameFilter?: string | undefined;

    constructor(data?: GetAllDepartmentsQuery) {
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
            this.nameFilter = data["nameFilter"];
        }
    }

    static fromJS(data: any): GetAllDepartmentsQuery {
        data = typeof data === 'object' ? data : {};
        let result = new GetAllDepartmentsQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["page"] = this.page;
        data["rowsOnPage"] = this.rowsOnPage;
        data["nameFilter"] = this.nameFilter;
        return data;
    }
}

export class AddDepartmentCommand {
    departmentName?: string | undefined;

    constructor(data?: AddDepartmentCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.departmentName = data["departmentName"];
        }
    }

    static fromJS(data: any): AddDepartmentCommand {
        data = typeof data === 'object' ? data : {};
        let result = new AddDepartmentCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["departmentName"] = this.departmentName;
        return data;
    }
}

export class UpdateDepartmentCommand {
    id!: number;
    departmentName?: string | undefined;

    constructor(data?: UpdateDepartmentCommand) {
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
            this.departmentName = data["departmentName"];
        }
    }

    static fromJS(data: any): UpdateDepartmentCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateDepartmentCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["departmentName"] = this.departmentName;
        return data;
    }
}
